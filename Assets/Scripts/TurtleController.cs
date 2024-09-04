using System.Collections.Generic;
using UnityEngine;

public class TurtleController : MonoBehaviour
{
    public float moveSpeed = 20.0f;
    public float turnSpeed = 80.0f;
    public LineRenderer lineRenderer;

    private List<Vector3> linePositions = new List<Vector3>();

    private void Start()
    {
        Debug.Log("TurtleController called");
        if (lineRenderer == null)
        {
            lineRenderer = GetComponent<LineRenderer>();
        }

        linePositions.Add(transform.position);
        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0, transform.position);
    }

    private void UpdateLine()
    {
        linePositions.Add(transform.position);
        lineRenderer.positionCount = linePositions.Count;
        lineRenderer.SetPositions(linePositions.ToArray());
    }

    public void MoveForward()
    {
        Debug.Log("MoveForward called");
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        UpdateLine();
    }

    public void TurnLeft()
    {
        Debug.Log("TurnLeft called");
        transform.rotation *= Quaternion.Euler(0, -90, 0);
    }

    public void TurnRight()
    {
        Debug.Log("TurnRight called");
        transform.rotation *= Quaternion.Euler(0, 90, 0);
    }

    public void ResetLine()
    {
        linePositions.Clear();
        lineRenderer.positionCount = 0;

        linePositions.Add(transform.position);
        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0, transform.position);
    }
}
