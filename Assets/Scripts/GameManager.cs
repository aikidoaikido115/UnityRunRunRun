using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public float initialGameSpeed = 250f; //เริ่มแรก
    public float gameSpeedIncrease = 3f;
    public float gameSpeed { get; private set; } //speed ล่าสุด


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
        NewGame();
    }

    private void NewGame()
    {
        gameSpeed = initialGameSpeed;
    }
    private void Update()
    {
        gameSpeed += gameSpeedIncrease * Time.deltaTime;
    }
}
