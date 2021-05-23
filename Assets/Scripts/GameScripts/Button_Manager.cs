using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button_Manager : MonoBehaviour
{
 
    public GameObject mainMenuPanel;
    public GameObject startButton;
    [Space]
    public GameObject levelSelectionPanel;

    private const string level1Name = "level1";
    private const string level2Name = "level2";
    private const string level3Name = "level3";
    private const string level4Name = "level4";
    private const string level5Name = "level5";
    private const string level6Name = "level6";
    private const string level7Name = "level7";
    private const string level8Name = "level8";
    private const string level9Name = "level9";
    private const string level10Name = "level10";
    
    
    
    [Space]
    public GameObject lourButton;
    public GameObject lourPanel;
        
    
    [Space]
    public GameObject settingsButton;
    public GameObject settingsPanel;
    
    
    
    public GameObject exitButton;
    public GameObject exitConfirmPanel;
    public GameObject yesExitButton;
    public GameObject noExitButton;


    
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
        lourPanel.SetActive(true);
    }
    public void LourClose()
    {
        lourPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }
    
//
    public void SettingsButton()
    {
        //TODO quality and volume settings 
        mainMenuPanel.SetActive(false);
        settingsPanel.SetActive(true);
    }
    public void SettingsSave()
    {
        //TODO saving system
        settingsPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }
    public void SettingsCancel()
    {
        settingsPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
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
        SceneManager.LoadScene(level1Name);
    }
    public void Level2()
    {
        SceneManager.LoadScene(level2Name);
    }
    public void Level3()
    {
        SceneManager.LoadScene(level3Name);
    }
    public void Level4()
    {
        SceneManager.LoadScene(level4Name);
    }
    public void Level5()
    {
        SceneManager.LoadScene(level5Name);
    }
    public void Level6()
    {
        SceneManager.LoadScene(level6Name);
    }
    public void Level7()
    {
        SceneManager.LoadScene(level7Name);
    }
    public void Level8()
    {
        SceneManager.LoadScene(level8Name);
    }
    public void Level9()
    {
        SceneManager.LoadScene(level9Name);
    }  public void Level10()
    {
        SceneManager.LoadScene(level10Name);
    }
}


