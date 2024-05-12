using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CanvasScript : MonoBehaviour
{
    [SerializeField] private GameObject _loadInGame;
    [SerializeField] private GameObject _loadInPrestige;
    
    private void Start()
    {
        GameEventScript.Instance.OnStateChange += ChangeState;
        
        ChangeState();
    }

    private void OnDisable()
    {
        GameEventScript.Instance.OnStateChange -= ChangeState;
    }

    private void ChangeState()
    {
        switch (GameStateScript.Instance.GetState())
        {
            case GameStateScript.GameState.Game:
                _loadInGame.SetActive(true);
                _loadInPrestige.SetActive(false);
                break;
            case GameStateScript.GameState.Prestige:
                _loadInGame.SetActive(false);
                _loadInPrestige.SetActive(true);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}
