using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUIController : MonoBehaviour
{
    public GameObject instructionsPanel;
    public GameObject title;
    public GameObject buttonPanel;
    public GameObject creditsPanel;

    public AudioSource buttonEffectSource;

    private void Start()
    {
        instructionsPanel.SetActive(false);
        creditsPanel.SetActive(false);
    }

    public void OnPlayButtonPressed()
    {
        buttonEffectSource.Play();
        SceneManager.LoadScene("GameScene");
    }

    public void OnInstructionsButtonPressed()
    {
        buttonEffectSource.Play();
        instructionsPanel.SetActive(true);
        title.SetActive(false);
        buttonPanel.SetActive(false);
    }

    public void OnInstructionsBackButtonPressed()
    {
        buttonEffectSource.Play();
        instructionsPanel.SetActive(false);
        title.SetActive(true);
        buttonPanel.SetActive(true);
    }

    public void OnCreditsButtonPressed()
    {
        buttonEffectSource.Play();
        creditsPanel.SetActive(true);
        buttonPanel.SetActive(false);
    }

    public void OnCreditsBackButtonPressed()
    {
        buttonEffectSource.Play();
        creditsPanel.SetActive(false);
        buttonPanel.SetActive(true);
    }



    public void OnMainMenuButtonPressed()
    {
        Time.timeScale = 1;
        buttonEffectSource.Play();
        SceneManager.LoadScene("MainMenu");
    }

    public void OnQuitButtonPressed()
    {
        buttonEffectSource.Play();
        Application.Quit();
    }
}
