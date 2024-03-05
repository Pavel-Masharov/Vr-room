using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerLineRenderer : MonoBehaviour
{
    [SerializeField] private LineRenderer _lineRenderer;

    private void Update()
    {
        UpdateLineRenderer();
    }



    private void UpdateLineRenderer()
    {
        _lineRenderer.SetPosition(0, transform.position);

        Vector3 forward = transform.forward;
        Vector3 position = transform.position;
        float distance = 10f;
        Vector3 targetPoint = position + forward * distance;

        _lineRenderer.SetPosition(1, targetPoint);
    }
}
