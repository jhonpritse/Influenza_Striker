using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Card_Manager : MonoBehaviour
{

    private Almanac_Manager _almanacManager;
    private Level_Manager _levelManager;
    private GameObject _virus;
    private Virus_Logic _virusLogic;
    private int _cardIndexKey;

    
    [SerializeField]private GameObject _winLevelPanel;
    [SerializeField] private GameObject _cardUnlockedPanel;
    void Start()
    {
        _almanacManager = GameObject.Find("Almanac_Manager").GetComponent<Almanac_Manager>();
        _levelManager = GameObject.Find("Level_Manager").GetComponent<Level_Manager>();
        _virus = GameObject.FindWithTag("Virus/Body");
        _virusLogic = _virus.GetComponent<Virus_Logic>();
        _cardIndexKey = _virusLogic.CardIndexKey;
  
    }

 
   

   public void CheckVirusHealth()
    {
        if (_virusLogic.Health <= 0)
        {
            WinLevelLogic();
            Time.timeScale = 0;
        }
    }

    private void WinLevelLogic()
    {
        SetWinCanvas();
        
    }

    void SetWinCanvas()
    {
        if (!_winLevelPanel.activeSelf)
        {
            _winLevelPanel.SetActive(true);
        }
        //If Virus has already been unlocked will not enable CardUnlocked Panel
        var isCardUnlocked = _almanacManager.isCardUnlocked[_cardIndexKey];
        if (!isCardUnlocked)
        {
            if (_cardIndexKey < _almanacManager.isCardUnlocked.Length)
            {
                _almanacManager.isCardUnlocked[_cardIndexKey] = true;
            }

            if (_cardIndexKey < _levelManager.isLevelUnlocked.Length)
            {
                _levelManager.isLevelUnlocked[_cardIndexKey+1] = true;
            }
            _levelManager.SaveLevel();
            _almanacManager.SaveAlmanac();
            _cardUnlockedPanel.SetActive(true);
        }
    }
    
    
    
    //buttons 
    public void Card_ConfirmClose()
    {
        _cardUnlockedPanel.SetActive(false);
    }

    public void WinLevel_Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
    public void WinLevel_MainMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    public void WinLevel_NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        Time.timeScale = 1;
    }
}
