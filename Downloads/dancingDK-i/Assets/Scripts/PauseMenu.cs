using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    public static bool isPaused = false;
    public Button resumeButton; // Assign this in the Inspector or in code
    public Button homeButton; // Assign this in the Inspector or in code

    void Start()
    {
        Resume();
        resumeButton.onClick.AddListener(Resume);
        homeButton.onClick.AddListener(Home);
        Debug.Log("resumeButton assigned: " + (resumeButton != null));
        Debug.Log("homeButton assigned: " + (homeButton != null));
        LineController.startAgain = false;
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void Resume()
    {
        print ("RESUME");
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        LineController.startAgain = !LineController.startAgain;
    }

    public void Home()
    {
        print ("MAIN");
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (isPaused) {
                Resume();
            }
            else{
                Pause();
            }
        }
    }
}
