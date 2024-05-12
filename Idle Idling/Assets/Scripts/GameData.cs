using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public float highScore;
    public long appCloseTime;
    

    public GameData(GameControllerScript gameController)
    {
        highScore = gameController.highScore;
        appCloseTime = gameController.appCloseTime;
    }
}
