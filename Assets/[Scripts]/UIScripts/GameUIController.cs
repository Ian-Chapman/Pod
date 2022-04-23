using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUIController : MonoBehaviour
{
    public AudioSource audioSource;
    MovementComponent movementComponent;

    public GameObject pauseButton;
    public GameObject pausePanel;
    public GameObject topPanel;

    private void Start()
    {
        pausePanel.SetActive(false);
        movementComponent = GameObject.Find("PlayerCharacter").GetComponent<MovementComponent>();
    }

    public void OnPauseButtonPressed()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
        topPanel.SetActive(false);
        movementComponent.aimSensitivity = 0;
        audioSource.Pause();
    }

    public void OnResumeButtonPressed()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
        topPanel.SetActive(true);
        movementComponent.aimSensitivity = 3.5f;
        audioSource.Play();
    }

    public void OnRestartButtonPressed()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("GameScene");
    }

    public void OnMainMenuButtonPressed()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

}
