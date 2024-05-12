using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEventScript : MonoBehaviour
{
    public static GameEventScript Instance;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }

        Instance = this;
    }

    public event Action OnStateChange;

    public void ChangeState()
    {
        if (OnStateChange != null)
        {
            OnStateChange();
        }
    }
}
