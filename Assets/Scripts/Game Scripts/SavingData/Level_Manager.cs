using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        isLevelUnlocked[0] = true;
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
            isLevelUnlocked[0] = true;
            LoadLevel();
        }
        
    }
    private void OnDisable()
    {
        PlayerPrefs.SetInt(Key , 1);
        isLevelUnlocked[0] = true;
        SaveLevel();
    }
    

    public void StartUnlockedLevel1()
    {
        var  levelPanel = GameObject.Find("Canvas").transform.Find("LevelSelection_Panel").transform;
        var levelHolder = levelPanel.Find("Level_Panel").transform;
        levelHolder.GetChild(0).transform.GetComponent<Button>().interactable = true;
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
