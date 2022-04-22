using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUIController : MonoBehaviour
{
    public void OnPlayButtonPressed()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void OnInstructionsButtonPressed()
    {
        SceneManager.LoadScene("Instructions");
    }

    public void OnCreditsButtonPressed()
    {
        SceneManager.LoadScene("Credits");
    }

    public void OnQuitButtonPressed()
    {
        Application.Quit();
    }
}
