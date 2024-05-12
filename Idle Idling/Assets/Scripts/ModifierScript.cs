using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifierScript : MonoBehaviour
{
    [SerializeField] private GameObject loadInLocked;
    [SerializeField] private GameObject loadInUnlocked;
    [SerializeField] private GameObject loadInInfo;

    public void Unlock()
    {
        ModifierControllerScript.Instance.extraTimeUnlocked = true;
        
        loadInLocked.SetActive(false);
        loadInUnlocked.SetActive(true);
        loadInInfo.SetActive(false);
    }
}
