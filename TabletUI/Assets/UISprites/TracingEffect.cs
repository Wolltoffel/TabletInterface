using UnityEngine;
using UnityEngine.UI;

public class TracingEffect : MonoBehaviour
{
    public float speed = 1f; // Speed of the tracing effect
    public Color lineColor = Color.red; // Color of the tracing lines
    public Transform[] controlPoints; // Array of control points that define the path

    private Image image;
    private RectTransform rectTransform;
    private Vector2[] originalVertices;
    private Vector2[] modifiedVertices;

    private void Awake()
    {
        image = GetComponent<Image>();
        rectTransform = GetComponent<RectTransform>();
        originalVertices = image.sprite.vertices;
        modifiedVertices = new Vector2[originalVertices.Length];
    }

    private void Update()
    {
        // Update the modified vertices based on time and control points
        float time = Time.time * speed;
        for (int i = 0; i < originalVertices.Length; i++)
        {
            Vector2 controlPoint = controlPoints[i % controlPoints.Length].position;
            modifiedVertices[i] = originalVertices[i] + Vector2.up * Mathf.Sin(time + i) * 0.1f + controlPoint;
        }

        // Update the image mesh with the modified vertices
        Mesh mesh = new Mesh();
        image.sprite.OverrideGeometry(modifiedVertices, image.sprite.triangles);
        image.SetAllDirty();
    }
}
