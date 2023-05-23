using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class LineManager : MonoBehaviour
{
    [SerializeField]LineRenderer lineRenderer;
    [SerializeField]Transform[] vertex;
    Vector3[] vertexPositions;
    [SerializeField] float animationDuration;
    [SerializeField]float distanceToCamera;
    [SerializeField]Canvas canvas;

    private void Awake()
    {
        if (lineRenderer == null)
            lineRenderer = GetComponent<LineRenderer>();

        manageLineRenderer();
    }

    private void Start()
    {
        StartCoroutine(animateLines());
    }
    private void Update()
    {

    }

    private void OnDrawGizmos()
    {
        for (int i = 0; i < vertex.Length-1; i++)
        {
            Gizmos.DrawLine(vertex[i].position, vertex[i + 1].position);
        }
    }
    void updateVertexPositions(int index)
    {
        //Put all vertex on a plane and always face the camera
        vertexPositions[index] = Vector3.ProjectOnPlane(vertexPositions[index], Camera.main.transform.forward);
        Vector3 vertexToCamera = Camera.main.transform.position - vertexPositions[index];
        vertexPositions[index] = vertexPositions[index] + vertexToCamera.normalized / distanceToCamera;
    }
    void manageLineRenderer() {

        float planeDistance = canvas.planeDistance;
        vertexPositions = new Vector3[vertex.Length];

        for (int i = 0; i < vertex.Length; i++) {
            vertexPositions[i] = vertex[i].position;
            updateVertexPositions(i);
        }
    }
    IEnumerator animateLines()
    {
        //Set origin
        if (vertex.Length>0) 
            lineRenderer.SetPosition(0, vertexPositions[0]);

        for (int i = 1; i < vertexPositions.Length; i++)
        {
            float startTime  = Time.time;
            Vector3 target = vertexPositions[i];
            Vector3 start = vertexPositions[i - 1];
            Vector3 current = start;
            lineRenderer.positionCount = i + 1;
            while (current!=target)
            {
                float t = (Time.time - startTime) / animationDuration;
                current = Vector3.Lerp(start, vertexPositions[i], t);
                lineRenderer.SetPosition(i, current);
                yield return null;
            }
        }
    }


}
