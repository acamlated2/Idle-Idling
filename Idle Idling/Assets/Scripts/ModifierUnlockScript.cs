using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModifierUnlockScript : MonoBehaviour
{
    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(Unlock);
    }

    private void Unlock()
    {
        transform.parent.parent.GetComponent<ModifierScript>().Unlock();
    }
}
