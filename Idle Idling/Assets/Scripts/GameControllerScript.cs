using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameControllerScript : MonoBehaviour
{
    public static GameControllerScript Instance;
    
    public float timeCounter;
    public float _totalTimeMultiplier = 1;

    public float highScore;

    private TMP_Text _timerText;
    private TMP_Text _highScoreText;

    public long appCloseTime;

    private GameStateScript.GameState _gameState;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }

        Instance = this;
        
        _timerText = GameObject.FindGameObjectWithTag("Timer Text").GetComponent<TMP_Text>();
        _highScoreText = GameObject.FindGameObjectWithTag("HighScore Text").GetComponent<TMP_Text>();
    }
    
    private void OnEnable()
    {
        LoadGame();
    }

    private void Start()
    {
        GameEventScript.Instance.OnStateChange += ChangeState;
        
        _gameState = GameStateScript.Instance.GetState();
    }

    private void OnDisable()
    {
        GameEventScript.Instance.OnStateChange -= ChangeState;
    }

    private void ChangeState()
    {
        _gameState = GameStateScript.Instance.GetState();
    }

    private void Update()
    {
        if (_gameState != GameStateScript.GameState.Game)
        {
            return;
        }
        
        timeCounter += (1 * _totalTimeMultiplier) * Time.deltaTime;
        
        _timerText.text = ((int)timeCounter).ToString();

        if (timeCounter > highScore)
        {
            highScore = timeCounter;
            _highScoreText.text = "HighScore: " + (int)highScore;
        }
    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }

    private void SaveGame()
    {
        appCloseTime = DateTimeOffset.Now.ToUnixTimeSeconds();
        SaveSystem.SaveGame(this);
    }

    private void LoadGame()
    {
        GameData data = SaveSystem.LoadData();

        if (data == null)
        {
            return;
        }
        
        highScore = data.highScore;
        _highScoreText.text = "HighScore: " + (int)highScore;
        appCloseTime = data.appCloseTime;

        long difference = DateTimeOffset.Now.ToUnixTimeSeconds() - appCloseTime;
        Debug.Log("Time since last played: " + difference + " seconds");
    }

    public void AddTime(float timeToAdd)
    {
        timeCounter += timeToAdd;
        _timerText.text = ((int)timeCounter).ToString();
    }
}
