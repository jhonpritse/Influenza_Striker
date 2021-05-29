using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class LevelData
{
    //TODO set variable to be savable
    public bool[] isLevelState ;    
       
    
    public LevelData(Level_Manager levelManager)
    {
        isLevelState = new bool[levelManager.isLevelUnlocked.Length];
            
        for (int i = 0; i < levelManager.isLevelUnlocked.Length; i++)
        {
            // Debug.Log("Update in almanac Data " + i + " " +    isCardState[i]  + " from almatac > "+ almanac.isCardUnlocked[i]);
            isLevelState[i] = levelManager.isLevelUnlocked[i];
        }
            
    }
}
