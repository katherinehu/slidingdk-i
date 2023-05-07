using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LineController : MonoBehaviour
{
    public float speed;
    private Vector3 dir;
    public GameObject shadowPrefab;
    private AudioSource backgroundMusic;
    private Rigidbody rbd;
    public static bool startAgain = false;
    public bool canEnd = false;
    public Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        backgroundMusic = GetComponent<AudioSource>();
        rbd = GetComponent<Rigidbody>();
        startAgain = false;
        canEnd = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            canEnd = true;
            // start moving and play music
            if (dir == Vector3.zero)
            {
                dir = Vector3.forward;
                backgroundMusic.Play();
            }
            // if moving left move right
            else if (dir == Vector3.forward)
            {
                dir = Vector3.right;
            }
            // if moving right move left
            else if (dir == Vector3.right)
            {
                dir = Vector3.forward;
            }

        }
        else if (PauseMenu.isPaused == true) {
            print("PAUSE = true");
            backgroundMusic.Pause();
            startAgain = false;
        }
        else if (startAgain == true) {
            print("START AGAIN");
            backgroundMusic.Play();
            startAgain = false;
        }
        // Check if the music has ended
        if (!backgroundMusic.isPlaying && canEnd)
        {
            CameraController.allowMovement = false;
            SceneManager.LoadScene("MainMenu");
        }
        if (dir != Vector3.zero) { Instantiate(shadowPrefab, transform.position, transform.rotation); }
        float movement = speed * Time.deltaTime;
        transform.Translate(dir * movement);
    }
    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Jewel"))
        {
            // Handle collision with jewel
            Debug.Log("Jewel collected!");
            ScoreManager.instance.AddPt(); // Collect point on jewel counter
            Destroy(collision.gameObject); // Destroy the jewel object
        }
        else
        {
            // Handle collision with other obstacles
            dir = Vector3.zero;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}