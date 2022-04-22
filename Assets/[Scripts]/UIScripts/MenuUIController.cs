using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUIController : MonoBehaviour
{
    public GameObject instructionsPanel;
    public GameObject title;
    public GameObject buttonPanel;

    private void Start()
    {
        instructionsPanel.SetActive(false);
    }

    public void OnPlayButtonPressed()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void OnInstructionsButtonPressed()
    {
        instructionsPanel.SetActive(true);
        title.SetActive(false);
        buttonPanel.SetActive(false);
    }

    public void OnCreditsButtonPressed()
    {
        SceneManager.LoadScene("Credits");
    }

    public void OnInstructionsBackButtonPressed()
    {
        instructionsPanel.SetActive(false);
        title.SetActive(true);
        buttonPanel.SetActive(true);
    }

    public void OnQuitButtonPressed()
    {
        Application.Quit();
    }
}
