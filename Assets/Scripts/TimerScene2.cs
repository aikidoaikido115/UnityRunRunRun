using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerScene2 : MonoBehaviour
{
    public GameObject day;
    public GameObject evening;
    public float changeInterval = 30f;
    public bool isEvening = false;
    public GameManager reset;
    

    private void Start()
    {
        
        changeInterval = 30f;
        //isNewGame = reset.isNewGame;
        Debug.Log(reset.isNewGame);


    }
    void Update()
    {
        changeInterval -= Time.deltaTime;
        
        if (changeInterval <= 0)
        {
            BackgroundChanger();
            changeInterval = 30f;
        }
        if (!reset.isNewGame)
        {
            changeInterval = 30f;
            isEvening = false;

        }
    }

    public void BackgroundChanger()
    {
        if (!isEvening)
        {
            day.SetActive(false);
            evening.SetActive(true);
            isEvening = true;
        }
        else
        {
            day.SetActive(true);
            evening.SetActive(false);
            isEvening = false;
        }
    }
}
