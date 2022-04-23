using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameUIController : MonoBehaviour
{
    public AudioSource musicSource;
    public AudioSource soundEffectSource;
    MovementComponent movementComponent;

    public GameObject pauseButton;
    public GameObject pausePanel;
    public GameObject topPanel;

    public TextMeshProUGUI garbageText;
    
    [SerializeField]
    public int garbageCollected;

    public void Update()
    {
        garbageText.text = "" + garbageCollected.ToString();
        CheckForWin();
    }

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
        musicSource.Pause();
    }

    public void OnResumeButtonPressed()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
        topPanel.SetActive(true);
        movementComponent.aimSensitivity = 3.5f;
        musicSource.Play();
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

    private void CheckForWin()
    {
        if (garbageCollected >= 15)
        {
            SceneManager.LoadScene("WinScreen");
        }
    }

}
