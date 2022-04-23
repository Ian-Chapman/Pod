using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameUIController : MonoBehaviour
{
    public AudioSource musicSource;
    public AudioSource buttonEffectSource;
    MovementComponent movementComponent;

    public GameObject pauseButton;
    public GameObject pausePanel;
    public GameObject topPanel;

    public TextMeshProUGUI garbageText;

    public GameObject dummyTimer;

    public Animator UIAnimator;
    
    [SerializeField]
    public int garbageCollected;



    private void Start()
    {
        pausePanel.SetActive(false);
        dummyTimer.SetActive(false);
        movementComponent = GameObject.Find("PlayerCharacter").GetComponent<MovementComponent>();
    }

    public void Update()
    {
        garbageText.text = "" + garbageCollected.ToString();
        CheckForWin();
    }

    public void OnPauseButtonPressed()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
        topPanel.SetActive(false);
        movementComponent.aimSensitivity = 0;
        musicSource.Pause();
        buttonEffectSource.Play();
    }

    public void OnResumeButtonPressed()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
        topPanel.SetActive(true);
        movementComponent.aimSensitivity = 3.5f;
        musicSource.Play();
        buttonEffectSource.Play();
    }

    public void OnRestartButtonPressed()
    {
        Time.timeScale = 1;
        buttonEffectSource.Play();
        SceneManager.LoadScene("GameScene");
    }

    public void OnMainMenuButtonPressed()
    {
        Time.timeScale = 1;
        buttonEffectSource.Play();
        SceneManager.LoadScene("MainMenu");
    }

    private void CheckForWin()
    {
        if (garbageCollected == 15)
        {
            SceneManager.LoadScene("WinScene");
        }
    }

}
