using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class LineManager : MonoBehaviour
{
    [Header ("Importables")]
    [SerializeField] LineRenderer lineRenderer;
    [SerializeField] Canvas canvas;
    [SerializeField] Transform[] vertex;
    Vector3[] vertexPositions;

    [Header ("Attributes")]
    [SerializeField] float distanceToCamera;
    [SerializeField] float ledgeOffset;

    [Header("ManualLineRenderer")]
    Vector3[] currentList;
    [SerializeField] bool activateDrawLine;
    [SerializeField][Range(0,1)] float drawLine;

    [Header ("Courutine Renderer")]
    [SerializeField] float animationDuration;


    private void Awake()
    {
        if (lineRenderer == null)
            lineRenderer = GetComponent<LineRenderer>();

        manageLineRenderer();
    }

    private void Start()
    {
        //StartForwardAnimation();
        //animateLinesForwardManual();
    }

    private void LateUpdate()
    {
        if (activateDrawLine)
        {
            animateLinesForwardManual();
        }
    }

    private void OnDrawGizmos()
    {
        for (int i = 0; i < vertex.Length - 1; i++)
        {
            Gizmos.DrawLine(vertex[i].position, vertex[i + 1].position);
        }
    }
    
    void manageLineRenderer()
    {
        vertexPositions = new Vector3[vertex.Length];

        for (int i = 0; i < vertex.Length; i++)
        {
            vertexPositions[i] = vertex[i].position;
            vertexPositions[i] = convertRelativeToMainCamera(vertexPositions[i]);
            
            if (i== vertex.Length - 1)
            {
                addLedge();
            }
        }
    }

    Vector3 convertRelativeToMainCamera(Vector3 initialPosition)
    {
        //Put all vertex on a plane that always faces the camera
        Plane plane = new Plane(Camera.main.transform.forward, Camera.main.transform.position+distanceToCamera * Camera.main.transform.forward);
        return plane.ClosestPointOnPlane(initialPosition);
    }

    void addLedge()
    {
        Vector3 target = vertexPositions[vertex.Length - 1];
        Vector3 ledge = target+ new Vector3 (-ledgeOffset,0,0);
        ledge = convertRelativeToMainCamera(ledge);
        Vector3[] newVertexPositions = new Vector3[vertexPositions.Length+1];
        
        for (int i= 0; i<vertexPositions.Length;i++)
        {
            newVertexPositions[i] = vertexPositions[i];
        }


        newVertexPositions[vertexPositions.Length-1] = ledge;
        newVertexPositions[vertexPositions.Length] = target;
        vertexPositions = newVertexPositions;
    }

    public void StartForwardAnimation()
    {
        StartCoroutine(animateLinesForward());
    }

    public void StartBackwardAnimation()
    {
        StartCoroutine(animateLinesBackward());
    }
    IEnumerator animateLinesForward()
    {
        //Set origin
        if (vertex.Length > 0)
            lineRenderer.SetPosition(0, vertexPositions[0]);

        for (int i = 1; i < vertexPositions.Length; i++)
        {
            float startTime = Time.time;
            Vector3 target = vertexPositions[i];
            Vector3 start = vertexPositions[i - 1];
            Vector3 current = start;
            lineRenderer.positionCount = i + 1;
            while (current != target)
            {
                float t = (Time.time - startTime) / animationDuration;
                current = Vector3.Lerp(start, vertexPositions[i], t);
                lineRenderer.SetPosition(i, current);
                yield return null;
            }
        }
    }

    IEnumerator animateLinesBackward()
    {
        for (int i = vertexPositions.Length - 1; i > 0; i--)
        {
            float startTime = Time.time;
            Vector3 start = vertexPositions[i];
            Vector3 target = vertexPositions[i - 1];
            Vector3 current = start;
 
            while (current != target)
            {
                float t = (Time.time - startTime) / animationDuration;
                current = Vector3.Lerp(start, target, t);
                for (int j = i; j < lineRenderer.positionCount; j++)
                {
                    lineRenderer.SetPosition(j, current);
                }

                yield return null;
            }
            if (lineRenderer.positionCount != 0)
            lineRenderer.positionCount--;
        }
    }

    public void animateLinesForwardManual()
       {
        //DrawLine Berechnungen
        float[] distancesToPrevious = new float[vertexPositions.Length];
        float totalDistance=0;
        
        //Calculate Distances
        for (int i = 1; i < vertexPositions.Length; i++)
        {
            distancesToPrevious[i] = Vector3.Distance(vertexPositions[i], vertexPositions[i - 1]);
            totalDistance += distancesToPrevious[i];
        }

        Vector3[]currentList = new Vector3[vertexPositions.Length];
        float totalDistanceLeft = totalDistance*drawLine;

        //Set origin
        if (vertex.Length > 0)
            lineRenderer.SetPosition(0, vertexPositions[0]);


        //Set Positions
        for (int i = 1; i < vertexPositions.Length; i++)
        {
            Vector3 endPosition;
            Vector3 direction = (vertexPositions[i] - vertexPositions[i - 1]).normalized;

            if (distancesToPrevious[i] >= totalDistanceLeft)
            {
                float availableLength = totalDistanceLeft;
                totalDistanceLeft = 0;
                endPosition = vertexPositions[i-1] + direction * availableLength;

                if (lineRenderer.positionCount<i+1)
                    lineRenderer.positionCount++;
                lineRenderer.SetPosition(i, endPosition);
                lineRenderer.positionCount = i+1;
                break;
            }

            else
            {
                totalDistanceLeft -= distancesToPrevious[i];
                endPosition = vertexPositions[i - 1] + direction*distancesToPrevious[i];
                if (lineRenderer.positionCount < i + 1)
                    lineRenderer.positionCount++;
                lineRenderer.SetPosition(i, endPosition);
            }

        }
    }

}


