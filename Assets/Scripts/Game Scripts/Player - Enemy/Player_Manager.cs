using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player_Manager : MonoBehaviour
{

    [SerializeField] private PlayerData_Object playerData;

    [SerializeField]  private TextMeshProUGUI _text;
    private float _timer;
    private int _score;
    public int Score
    {
        get => _score;
        set => _score = value;
    }

    [SerializeField] private Transform healthParentPos;
    [SerializeField] private GameObject gameOverPanel;
   
    private int _health;
    public int Health
    {
        get => _health;
        set => _health = value;
    }

    private bool _isShoot; 
    public bool IsShoot
    {
        get => _isShoot;
        set => _isShoot = value;
    }
    [SerializeField] private Transform handPos;
    
    void Start()
    {
        Time.timeScale = 1;
        _health = playerData.health;
        _text = GameObject.Find("Score_Text").GetComponent<TextMeshProUGUI>();
        SetHealthPrefab();
    }

   void SetHealthPrefab()
    {
        for (int i = 0; i < playerData.health; i++)
        {
            GameObject newHealth = Instantiate(playerData.healthUI, healthParentPos.position, Quaternion.identity);
            newHealth.transform.SetParent(healthParentPos, false);
        }
    }
   void RemoveHealth()
   {
       if (_health>=0)
       {
           var heart =(healthParentPos.GetChild(_health));
           heart.GetComponent<Image>().enabled = false;
       }
   }
   void GameOverCheck()
   {
       if (_health <= 0)
       {
           Time.timeScale = 0;
           gameOverPanel.SetActive(true);
       }
      
   }
    void Update()
    {
        SetScoreText();
        ShootAttack();
    }
    void SetScoreText()
    {
        _timer += Time.deltaTime;
        if (_timer > 1) {

            _score += 1;
            _timer = 0;
        }
        
        _text.text = _score.ToString();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            _health -=1;
            RemoveHealth();
            GameOverCheck();
        }
    }

    void ShootAttack()
    {
        if (_isShoot)
        {
            var position = handPos.position;
            Instantiate(playerData.attackShootParticle, position, quaternion.identity);
            Instantiate(playerData.attackPrefab, position, quaternion.identity);
            _isShoot = false;
        }
    }
    
}
