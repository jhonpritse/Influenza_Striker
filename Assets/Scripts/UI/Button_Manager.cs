using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button_Manager : MonoBehaviour
{
//TODO set up proper name level name
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
    public GameObject almanacPanel;
    public GameObject mainMenuPanel;  
    public GameObject settingsPanel;
    public GameObject creditsPanel;
    public GameObject pausePanel;
    public GameObject pauseButton;
    public GameObject inGameUI;

    private void OnEnable()
    {
        
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
        almanacPanel.SetActive(true);
    }
    public void CardClose()
    {
        almanacPanel.SetActive(false);
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

    public void CreditsButton()
    {
        creditsPanel.SetActive(true);
    }
    public void CreditsCloseButton()
    {
        creditsPanel.SetActive(false);
    }
    
    //level Selection 
    public void Level1()
    {
        SceneManager.LoadScene(Level1Name);
    }
    public void Level2()
    {
        SceneManager.LoadScene(Level2Name);
    }
    public void Level3()
    {
        SceneManager.LoadScene(Level3Name);
    }
    public void Level4()
    {
        SceneManager.LoadScene(Level4Name);
    }
    public void Level5()
    {
        SceneManager.LoadScene(Level5Name);
    }
    public void Level6()
    {
        SceneManager.LoadScene(Level6Name);
    }
    public void Level7()
    {
        SceneManager.LoadScene(Level7Name);
    }
    public void Level8()
    {
        SceneManager.LoadScene(Level8Name);
    }
    public void Level9()
    {
        SceneManager.LoadScene(Level9Name);
    }  public void Level10()
    {
        SceneManager.LoadScene(Level10Name);
    }



    public void PauseGameButton()
    {
        Time.timeScale = 0;
        controlButtons.SetActive(false);
        pauseButton.SetActive(false);
        pausePanel.SetActive(true);
    }
    
    public void ResumeGameButton()
    {

        Time.timeScale = 1;
        controlButtons.SetActive(true);
        pauseButton.SetActive(true);
        pausePanel.SetActive(false);
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene(0);
    }

    public void RestartSceneButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}




