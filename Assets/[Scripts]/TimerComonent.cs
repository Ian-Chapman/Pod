using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class TimerComonent : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public float timeLeft;

    public Transform player;


    private void Start()
    {
        timerText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        CheckPlayerDepth();
    }

    private void Timer()
    {
        timeLeft -= Time.deltaTime;
        timerText.text = "" + Math.Round(timeLeft);
        if (timeLeft <= 0)
        {
            timeLeft = 0;
            timerText.text = "0".ToString();
            //SceneManager.LoadScene("GameOver");
        }
    }

    private void CheckPlayerDepth()
    {
        //player has a budget of 10 seconds on a timer if they are below a Y level of 55
        if (player.transform.position.y < 55f)
        {
            timerText.enabled = true;
            Timer();
        }
        //Timer will reset if player goes up to the surface of the water
        else if (timerText.enabled = true && player.transform.position.y >= 88f)
        {
            timerText.enabled = false;
            timeLeft = 10;
        }
    }

}
