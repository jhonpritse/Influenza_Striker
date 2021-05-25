using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button_Manager : MonoBehaviour
{

    #region Constant
//Constant Value for level name
//Call Variable and not manually
//type in level name to avoid errors 
    private const string Level1Name = "level1";
    private const string Level2Name = "level2";
    private const string Level3Name = "level3";
    private const string Level4Name = "level4";
    private const string Level5Name = "level5";
    private const string Level6Name = "level6";
    private const string Level7Name = "level7";
    private const string Level8Name = "level8";
    private const string Level9Name = "level9";
    private const string Level10Name = "level10";
    #endregion

    public GameObject controlButtons;
    public GameObject exitConfirmPanel;
    public GameObject levelSelectionPanel;
    public GameObject cardsPanel;
    public GameObject mainMenuPanel;  
    public GameObject settingsPanel;
    public GameObject pausePanel;
    public GameObject pauseButton;
    public GameObject inGameUI;

    // private bool _isInGame;
    

    private void Update()
    {
        // if (_isInGame)
        // {
        //     mainMenuPanel.SetActive(false);
        //     controlButtons.SetActive(true);
        //     inGameUI.SetActive(true);
        //     
        // }
        // else
        // {
        //     mainMenuPanel.SetActive(true);
        //     controlButtons.SetActive(false);
        //     inGameUI.SetActive(false);
        // }
    }

    public void StartGameButton()
    {
        mainMenuPanel.SetActive(false);
        levelSelectionPanel.SetActive(true);
    }

    public void StartGameBack()
    {
        mainMenuPanel.SetActive(true);
        levelSelectionPanel.SetActive(false);
    }

    //
    public void LourButton()
    {
        mainMenuPanel.SetActive(false);
        cardsPanel.SetActive(true);
    }
    public void CardClose()
    {
        cardsPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }
    
//
    public void SettingsButton()
    {
        //TODO quality and volume settings 
        settingsPanel.SetActive(true);
    }
    public void SettingsSave()
    {
        //TODO saving system
        settingsPanel.SetActive(false);
    }
    public void SettingsCancel()
    {
        settingsPanel.SetActive(false);
    }
    
    //
    public void ExitApp()
    {
        mainMenuPanel.SetActive(false);
        exitConfirmPanel.SetActive(true);
    }
    public void ExitNo()
    {
        exitConfirmPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }
    public void ExitYes()
    {
        Application.Quit();
    }
    
    
    
    //level Selection 
    public void Level1()
    {
     //   _isInGame = true;
        SceneManager.LoadScene(1);
    }
    public void Level2()
    {
     //   _isInGame = true;
        SceneManager.LoadScene(Level2Name);
    }
    public void Level3()
    {
     //   _isInGame = true;
        SceneManager.LoadScene(Level3Name);
    }
    public void Level4()
    {
     //   _isInGame = true;
        SceneManager.LoadScene(Level4Name);
    }
    public void Level5()
    {
     //   _isInGame = true;
        SceneManager.LoadScene(Level5Name);
    }
    public void Level6()
    {
     //   _isInGame = true;
        SceneManager.LoadScene(Level6Name);
    }
    public void Level7()
    {
     //   _isInGame = true;
        SceneManager.LoadScene(Level7Name);
    }
    public void Level8()
    {
     //   _isInGame = true;
        SceneManager.LoadScene(Level8Name);
    }
    public void Level9()
    {
     //   _isInGame = true;
        SceneManager.LoadScene(Level9Name);
    }  public void Level10()
    {
     //   _isInGame = true;
        SceneManager.LoadScene(Level10Name);
    }



    public void PauseGameButton()
    {
      //     _isInGame = false;
        Time.timeScale = 0;
        controlButtons.SetActive(false);
        pauseButton.SetActive(false);
        pausePanel.SetActive(true);
        
    }
    
    public void ResumeGameButton()
    {
     //   _isInGame = true;
        Time.timeScale = 1;
        controlButtons.SetActive(true);
        pauseButton.SetActive(true);
        pausePanel.SetActive(false);
    }

    public void MainMenuButton()
    {
      //     _isInGame = false;
        SceneManager.LoadScene(0);
    }

    public void RestartSceneButton()
    {
     //   _isInGame = true;
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}




