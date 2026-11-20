using UnityEngine;

public class FollowLine : MonoBehaviour
{
    public Transform targetObject; // The object the line should follow
    public float lineLength = 2f;  // Distance from object to line start

    private LineRenderer lineRenderer;

    void Start()
    {
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.startColor = Color.red;
        lineRenderer.endColor = Color.green;
        lineRenderer.startWidth = 0.01f;
        lineRenderer.endWidth = 0.01f;
        lineRenderer.positionCount = 3; // Start point, target point, and an extra point if needed
    }

    void Update()
    {
        if (targetObject != null)
        {
            // First point: at the object's position
            lineRenderer.SetPosition(0, targetObject.position);

            // Second point: offset from object along the desired line direction
            Vector3 lineDirection = (targetObject.position + new Vector3(0, 0, lineLength)) - targetObject.position;
            lineRenderer.SetPosition(1, targetObject.position + lineDirection);

            // Optional: add a third point if you want a curved or bent line
            // lineRenderer.SetPosition(2, new Vector3(...));
        }
    }
}
