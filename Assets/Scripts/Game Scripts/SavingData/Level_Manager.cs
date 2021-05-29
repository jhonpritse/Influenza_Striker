using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_Manager : MonoBehaviour
{
    
    #region Save variables
    private const string Key = "LevelfirstAwake";

    public bool[] isLevelUnlocked;
    #endregion
  

    private void Awake()
    {
        var  levelPanel = GameObject.Find("Canvas").transform.Find("LevelSelection_Panel").transform;
        var levelHolder = levelPanel.Find("Level_Panel").transform;
        var childCount = levelHolder.childCount;
        isLevelUnlocked = new bool[childCount];
    }

    private void OnEnable()
    {
     
        if (SavingSystem.CreatePathIfNull())
        {
                isLevelUnlocked[0] = true;
             SaveLevel();
        }
        if (PlayerPrefs.HasKey(Key))
        {
            print(" load data");
            LoadLevel();
        }
        
    }
    private void OnDisable()
    {
        PlayerPrefs.SetInt(Key , 1);
        SaveLevel();
    }
    

   
  
    
    public void SaveLevel()
    {
        SavingSystem.SaveLevelData(this);
    }

    public void LoadLevel()
    {
        LevelData data = SavingSystem.LoadLevelData();

        for (int i = 0; i < isLevelUnlocked.Length; i++)
        {
            isLevelUnlocked[i] = data.isLevelState[i];
        }
        
    }
}
