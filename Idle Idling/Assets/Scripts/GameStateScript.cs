using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateScript : MonoBehaviour
{
    public enum GameState
    {
        Game, 
        Prestige, 
    }
    
    public static GameStateScript Instance;

    private GameState _gameState = GameState.Game;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }

        Instance = this;
    }

    public void ChangeState(GameState newState)
    {
        _gameState = newState;
        GameEventScript.Instance.ChangeState();
    }

    public GameState GetState()
    {
        return _gameState;
    }
}
