using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Almanac_Manager : MonoBehaviour
{
   
    #region Save variables


    public bool[] isCardUnlocked;
    #endregion
    private const string Key = "AlmanacfirstAwake";

    private void Awake()
    {
      var  almanacPanel = GameObject.Find("Canvas").transform.Find("Almanac_Panel").transform;
       var almanacCardHolder = almanacPanel.Find("AlmanacCard_Holder").transform;
        var childCount = almanacCardHolder.childCount;
        isCardUnlocked = new bool[childCount];
    }

    private void OnEnable()
    {

        Time.timeScale = 1;
        if (SavingSystem.CreatePathIfNull())
        {
            SaveAlmanac();
            
        }
        if (PlayerPrefs.HasKey(Key))
        {
            LoadAlmanac();
        }
        
    }
    private void OnDisable()
    {
        PlayerPrefs.SetInt(Key , 1);
        SaveAlmanac();
    }
    
  
    
    public void SaveAlmanac()
    {
        SavingSystem.SaveAlmanacData(this);
    }

    public void LoadAlmanac()
    {
        AlmanacData data = SavingSystem.LoadAlmanacData();

        for (int i = 0; i < isCardUnlocked.Length; i++)
        {
            isCardUnlocked[i] = data.isCardState[i];
        }
        
    }
    
}
