﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;



public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public float initialGameSpeed = 250; //เริ่มแรก
    public float gameSpeedIncrease = 3f;
    public float gameSpeed { get; set; } //speed ล่าสุด
    public float score;
    public float scoreMultiplier; // มีผลกับเอฟเฟกต์ DoubleScore
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI currentScoreText;
    public TextMeshProUGUI highScoreText;
    public Button retryButton;

    private Player player;
    private Spawner spawner;

    public bool isNewGame;

    public TimerScene2 retry_bg_swap;

    public AudioClip dead;
    private AudioSource audioSource;


    
    //public TimerScene2 reset;



    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            DestroyImmediate(gameObject);
        }
    }

    private void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }

    private void Start()
    {
        player = FindObjectOfType<Player>();
        spawner = FindObjectOfType<Spawner>();
        audioSource = GetComponent<AudioSource>();

        NewGame();
        
    }

    public void NewGame()
    {
        Obstacle[] obstacles = FindObjectsOfType<Obstacle>();

        foreach(var obstacle in obstacles)
        {
            Destroy(obstacle.gameObject);
        }

        score = 0;
        scoreMultiplier = 1;
        gameSpeed = initialGameSpeed;
        enabled = true;

        isNewGame = true;

        retry_bg_swap.day.SetActive(true);
        retry_bg_swap.evening.SetActive(false);
        retry_bg_swap.isEvening = false;

        

        //reset game TimeScene2 counter
        //float changeInterval = reset.changeInterval;
        //Debug.Log(changeInterval);
        //changeInterval = 30f;
        //reset scene to Day
        //bool isEvening = reset.isEvening;
        //isEvening = false;


        player.gameObject.SetActive(true);
        spawner.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(false);
        retryButton.gameObject.SetActive(false);

        UpdateHiscore();
    }

    public void GameOver()
    {
        audioSource.PlayOneShot(dead);
        gameSpeed = 0f;
        enabled = false;


        isNewGame = false;


        player.gameObject.SetActive(false);
        spawner.gameObject.SetActive(false);
        gameOverText.gameObject.SetActive(true);
        retryButton.gameObject.SetActive(true);

        UpdateHiscore();
    }

    private void Update()
    {
        gameSpeed += gameSpeedIncrease * Time.deltaTime;
        score += gameSpeed * Time.deltaTime * scoreMultiplier;
        currentScoreText.text = Mathf.FloorToInt(score).ToString("D8");       
    }

    private void UpdateHiscore()
    {
        float hiscore = PlayerPrefs.GetFloat("hiscore", 0);

        if (score > hiscore)
        {
            hiscore = score;
            PlayerPrefs.SetFloat("hiscore", hiscore);
        }

        highScoreText.text = Mathf.FloorToInt(hiscore).ToString("D8");
    }
}


//test212312312321
