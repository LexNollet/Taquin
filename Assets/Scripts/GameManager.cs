using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int currentEmpty = 5;
    public GameObject tile1;
    public GameObject tile2;
    public GameObject tile3;
    public GameObject tile4;
    public GameObject tile6;
    public GameObject tile7;
    public GameObject tile8;
    public GameObject tile9;

    public GameObject victoryText;

    public void checkVictory()
    {
        if(tile1.GetComponent<TileDrag>().currentSlot == 1 &&
           tile2.GetComponent<TileDrag>().currentSlot == 2 &&
           tile3.GetComponent<TileDrag>().currentSlot == 3 &&
           tile4.GetComponent<TileDrag>().currentSlot == 4 &&
           tile6.GetComponent<TileDrag>().currentSlot == 6 &&
           tile7.GetComponent<TileDrag>().currentSlot == 7 &&
           tile8.GetComponent<TileDrag>().currentSlot == 8 &&
           tile9.GetComponent<TileDrag>().currentSlot == 9)
        {
            if (!victoryText.active)
            {
                Debug.Log("Victory!");
                victoryText.SetActive(true);
                GameObject.FindGameObjectWithTag("Timer").GetComponent<Timer>().pause = true;
                int seconds = GameObject.FindGameObjectWithTag("Timer").GetComponent<Timer>().secondsLeft;
                if (seconds >= 120)
                {
                    GameObject.FindGameObjectWithTag("Highscore").GetComponent<Text>().text = "02:" + seconds % 60;
                }
                else if(60 <= seconds && seconds < 120)
                {
                    GameObject.FindGameObjectWithTag("Highscore").GetComponent<Text>().text = "01:" + seconds % 60;
                }
                else
                    GameObject.FindGameObjectWithTag("Highscore").GetComponent<Text>().text = "00:" + seconds % 60;
            }
        }
        else
        {
            victoryText.SetActive(false);
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
