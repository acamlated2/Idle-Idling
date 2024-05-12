using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifierControllerScript : MonoBehaviour
{
    public static ModifierControllerScript Instance;
    
    public enum ModifierType
    {
        ExtraTime, 
    }
    
    private ModifierScript _extraTimeModifier;
    public bool extraTimeUnlocked = true;
    [SerializeField] private float extraTimeAmount = 5;
    [SerializeField] private float extraTimeSpeed = 100;
    private float _extraTimeTimer;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }

        Instance = this;
        
        _extraTimeTimer = extraTimeSpeed;
    }

    private void Update()
    {
        if (GetModifierUnlockedByType(ModifierType.ExtraTime))
        {
            _extraTimeTimer -= 1 * Time.deltaTime;
            if (_extraTimeTimer <= 0)
            {
                _extraTimeTimer = extraTimeSpeed;
                
                GameControllerScript.Instance.AddTime(extraTimeAmount);
            }   
        }
    }

    private bool GetModifierUnlockedByType(ModifierType type)
    {
        switch (type)
        {
            case ModifierType.ExtraTime:
                return extraTimeUnlocked;
            default:
                throw new ArgumentOutOfRangeException(nameof(type), type, null);
        }
    }
}
