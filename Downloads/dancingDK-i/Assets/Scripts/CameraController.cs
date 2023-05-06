using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target; // The object to follow
    public float smoothSpeed = 0.125f; // The speed of the camera movement
    public Vector3 offset; // The offset from the target object's position

    void LateUpdate()
    {
        // Calculate the desired camera position
        Vector3 desiredPosition = target.position + offset;

        // Smoothly move the camera to the desired position
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Set the camera to always look at the target object
        transform.rotation = Quaternion.Euler(45f, 45f, 0f);
    }
}
