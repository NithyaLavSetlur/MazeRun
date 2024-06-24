using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // The target the camera will follow
    public float distance = 5.0f; // Distance from the target
    public float height = 2.0f; // Height offset from the target
    public float smoothSpeed = 0.125f; // Smoothness of the camera movement
    public float rotationSpeed = 5.0f; // Speed of camera rotation
    public float horizontalOffset = 0.0f; // Horizontal offset from the target

    private float rotationY = 0.0f;
    private float rotationX = 0.0f;

    void LateUpdate()
    {
        // Ensure the target is set
        if (!target)
        {
            Debug.LogWarning("Target not set for CameraFollow script.");
            return;
        }

        // Get mouse inputs
        rotationY += Input.GetAxis("Mouse X") * rotationSpeed;
        rotationX -= Input.GetAxis("Mouse Y") * rotationSpeed;
        rotationX = Mathf.Clamp(rotationX, -30, 60); // Limit the up/down rotation

        // Calculate the rotation
        Quaternion rotation = Quaternion.Euler(rotationX, rotationY, 0);

        // Calculate the desired position with horizontal offset
        Vector3 offset = rotation * new Vector3(horizontalOffset, 0, -distance);
        Vector3 targetPosition = target.position + offset + (Vector3.up * height);

        // Smoothly interpolate to the desired position
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed);

        // Always look at the target
        transform.LookAt(target.position + Vector3.up * height);
    }
}
