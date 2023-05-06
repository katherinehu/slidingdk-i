using UnityEngine;

public class EndingBlock : MonoBehaviour
{
    public AudioSource audioSource;
    public Camera mainCamera;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Box"))
        {
            // Stop the audio
            if (audioSource != null)
            {
                audioSource.Stop();
            }

            // Stop the camera
            if (mainCamera != null)
            {
                mainCamera.enabled = false;
            }
        }
    }
}