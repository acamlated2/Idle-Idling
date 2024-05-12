using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrestigeButtonScript : MonoBehaviour
{
    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(ClickAction);
    }

    private void ClickAction()
    {
        GameStateScript.Instance.ChangeState(GameStateScript.GameState.Prestige);
    }
}
