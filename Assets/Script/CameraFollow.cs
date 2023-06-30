using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform cameraTarget;
    public float smoothTime = 0.3f;
    public float minHeight = 1f;
    public float maxHeight = 10f;

    private Vector3 smoothVelocity = Vector3.zero;

    private void Start()
    {
        transform.position = cameraTarget.position;
    }

    private void LateUpdate()
    {
        Vector3 targetPosition = cameraTarget.position;
        targetPosition.y = transform.position.y;
        targetPosition.y = Mathf.Clamp(targetPosition.y, minHeight, maxHeight);
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref smoothVelocity, smoothTime);
    }
}
