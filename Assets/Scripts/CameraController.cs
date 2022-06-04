using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraController : MonoBehaviour
{
    public List<Transform> _targets = default;

    [Header("Parameter")]
    [SerializeField] private Vector3 offset = default;
    [SerializeField] private float smoothValue = 0.5f;
    [SerializeField] private float maxZoom = 1f;
    [SerializeField] private float minZoom = 20f;
    [SerializeField] private float zoomLimiter = 50f;

    private Vector3 velocity;
    private Camera cam;

    private void Start()
    {
        cam = GetComponent<Camera>();
    }

    private void LateUpdate()
    {
        if (_targets.Count == 0) return;

        Move();
        Zoom();


    }

    private void Zoom()
    {
        float newZoom = Mathf.Lerp(maxZoom, minZoom, GreatDistanceOfTarget() / zoomLimiter);
        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, newZoom, Time.deltaTime);
    }

    private void Move()
    {
        Vector3 centerPoint = GetCenterOfTargets();
        Vector3 newPosition = centerPoint + offset;

        transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, smoothValue);
    }

    private float GreatDistanceOfTarget()
    {
        Bounds bound = new Bounds(_targets[0].position, Vector3.zero);
        for (int i = 0; i < _targets.Count; i++)
        {
            bound.Encapsulate(_targets[i].position);
        }

        float xSize = bound.size.x;
        float ySize = bound.size.y;

        return Mathf.Sqrt(Mathf.Pow(xSize, 2) + Mathf.Pow(ySize, 2));
    }

    private Vector3 GetCenterOfTargets()
    {

        Bounds bound = new Bounds(_targets[0].position, Vector3.zero);
        for (int i = 0; i < _targets.Count; i++)
        {
            bound.Encapsulate(_targets[i].position);
        }

        return bound.center;
    }
}
