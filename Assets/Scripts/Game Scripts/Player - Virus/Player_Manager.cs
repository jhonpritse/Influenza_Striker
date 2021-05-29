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
    [SerializeField]  private TextMeshProUGUI scoreText;
   

    [SerializeField] private Transform healthParentPos;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private Transform handPos;
    private float _timer;
    public int Score { get; set; }
    public int Health  { get; set; }
    public bool IsShoot { get; set; }
    private GameObject _healthUI;
    private GameObject _attackShootParticle;
    private GameObject _attackPrefab;
    //default value is +1 score per 1sec
    private  const int TimeTillAddScore = 1;
    private const int ScorePerTime = 1;
    //default value is -1 health per obstacle hit
    private const int ObstacleDamage = 1;

    private void Start()
    {
        Time.timeScale = 1;
        Health = playerData.health;
        _healthUI = playerData.healthUI;
        _attackShootParticle = playerData.attackShootParticle;
        _attackPrefab = playerData.attackPrefab;
        // scoreText = transform.GetComponent<TextMeshProUGUI>();
        SetHealthPrefab();
    }

    private void SetHealthPrefab()
    {
        for ( var i = 0; i < Health; i++)
        {
            var newHealth = Instantiate(_healthUI, healthParentPos.position, Quaternion.identity);
            newHealth.transform.SetParent(healthParentPos, false);
        }
    }

    private void DeductHealth()
   {
       if (Health>=0)
       {
           var heart =(healthParentPos.GetChild(Health));
           heart.GetComponent<Image>().enabled = false;
       }
   }

   private void GameOverCheck()
   {
       if (Health <= 0)
       {
           Time.timeScale = 0;
           GameOverLogic();
       }
   }

   private void GameOverLogic()
   {
       gameOverPanel.SetActive(true);
   }

   private void Update()
    {
        SetScoreText();
        ShootAttack();
    }

   private void SetScoreText()
    {
        _timer += Time.deltaTime;
        if (_timer > TimeTillAddScore) {

            Score += ScorePerTime;
            _timer = 0;
        }
        
        // text.text = Score.ToString();
        scoreText.text = Score.ToString();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle") || other.CompareTag("Virus/Attack"))
        {
            Health -=ObstacleDamage;
            DeductHealth();
            GameOverCheck();
        }
    }

    private void ShootAttack()
    {
        if (IsShoot)
        {
            var position = handPos.position;
            Instantiate(_attackShootParticle, position, Quaternion.identity);
            Instantiate(_attackPrefab, position, Quaternion.identity);
            IsShoot = false;
        }
    }
    
}
