using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private Text timerText;
    public GameObject victoryText;
    public int secondsLeft = 180;
    public bool pause = false;

    private int secondsDisplay;
    private int minutesDisplay;
    private void Start()
    {
        timerText = GetComponent<Text>();
        minutesDisplay = 3;
        secondsDisplay = secondsLeft % 60;
        timerText.text = "03:00";
    }

    private void Update()
    {
        secondsDisplay = secondsLeft % 60;
        if(pause == false && secondsLeft >= 0)
        {
            StartCoroutine(TimerCount());
        }
    }

    IEnumerator TimerCount()
    {
        if(secondsLeft >= 0)
        {
            pause = true;
            yield return new WaitForSeconds(1);
            secondsLeft -= 1;
            if(secondsDisplay < 10)
            {
                timerText.text = "0" + minutesDisplay + ":0" + secondsDisplay;
            }
            else
            {
                timerText.text = "0" + minutesDisplay + ":" + secondsDisplay;
            }
        
            if(secondsDisplay == 0)
            {
                minutesDisplay -= 1;
            }
            pause = false;
        }
        else
        {
            victoryText.SetActive(true);
            victoryText.GetComponent<Text>().text = "Game Over";
            pause = true;
        }
    }
}
