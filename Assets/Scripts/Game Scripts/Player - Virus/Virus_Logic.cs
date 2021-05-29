using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class Virus_Logic : MonoBehaviour
{
    public VirusData_Object virusData;
    [SerializeField] private GameObject virusPositionHolder;
    [SerializeField] private GameObject virusNameUI;
    [SerializeField] private GameObject virusHealthBarUI;
    private TextMeshProUGUI _virusName;
    private Player_Manager _playerManager;
    private Card_Manager _cardManager;
    private Player_HitPosition _hitPosition;
    private Slider _healthSlider;
    private Transform _attackPos;
    private Spawner_Manager _spawner;
    private GameObject _virusAttack;
    private GameObject _virusShootParticles;

    public int Health { get; set; }
    public int CardIndexKey { get; set; }
    private int _playerDamage;
    private int _plusScore;
    private float _speed;
    
    private float _timeVariable;
    private float _timeAttack;
    private float _floatHeightY;
    private float _floatFreqY;
    private float _floatHeightX;
    private float _floatFreqX;
    private bool _isCanAttack;
    private float _attackRate;
    private bool _isInPosition;

    private void Start()
    {
        _playerManager = GameObject.FindWithTag("Player/Body").GetComponent<Player_Manager>();
        _cardManager = GameObject.Find("CardManager").GetComponent<Card_Manager>();
        _hitPosition = GameObject.FindWithTag("Player/Body").transform.Find("HitPos").GetComponent<Player_HitPosition>(); 
        _attackPos = transform.Find("AttackPos").GetComponent<Transform>();
        _spawner = GameObject.FindWithTag("Spawn-able/Spawner").GetComponent<Spawner_Manager>();
        CardIndexKey = virusData.cardIndexKey;
   
        
        _virusAttack = virusData.virusAttack; 
        _virusShootParticles = virusData.virusShootParticle;

        
        _speed = virusData.movementSpeed ;
        Health = virusData.health;
        _plusScore = virusData.plusScoreWhenHit;
        _playerDamage = virusData.playerDamage;
        _attackRate = virusData.attackRate;
        
        _floatHeightY = virusData.floatingHeightY;
        _floatFreqY = virusData.floatingFreqY;
        _floatHeightX = virusData.floatingHeightX;
        _floatFreqX = virusData.floatingFreqX;
        SetupVirusCanvasUI();
        
    }

    private void SetupVirusCanvasUI()
    {
        _healthSlider = virusHealthBarUI.GetComponent<Slider>();
        _healthSlider.maxValue = virusData.health;
        _healthSlider.value = Health;
        _virusName = virusNameUI.GetComponent<TextMeshProUGUI>();
        _virusName.text = virusData.virusName;

    }

 

    private void VirusHitLogic()
    {
     
        DeductHealth();
    }

    private void Update()
    {
        CheckPos();
        if (IsScoreLimitReached())
        {
            StopSpawner();
            if (!_isInPosition)
            {
                BringVirusClose();
            }
            else
            {
                _isCanAttack = true;
               VirusAttackingLogic();
               MovementInPosition();
            }
        }
        
    }

    
    private void DeductHealth()
    {
        if (Health > 0)
        {
            Health -= _playerDamage;
            SetHealthBar(Health);
            AddToScore(_plusScore);
            
            if (Health <= 0)
            {
                _isCanAttack = false;
                Time.timeScale = 0;
                PlayerWon();
            }
        }
       
    }

    private void PlayerWon()
    {
        //TODO death Particle 
        //TODO add player won logic and cards unlocking
        
        
        _cardManager.CheckVirusHealth();
        Destroy(gameObject);
    }

    private void AddToScore(int plusScore)
    {
        _playerManager.Score += plusScore;
    }
    
    private void VirusAttackingLogic()
    {
        if (_isCanAttack)
        {
            CanAttack();
        }
    }
    void CanAttack()
    {
        _timeAttack += 1 * Time.deltaTime;
        if (_timeAttack >= _attackRate)
        {
            Attack();
            _timeAttack = 0;
        }
    }
    void Attack()
    {
        _hitPosition.SetHitPosition();
        var pos = _attackPos.position;
        Instantiate(_virusAttack, pos, quaternion.identity);
        Instantiate(_virusShootParticles, pos, quaternion.identity);
    }
    private void MovementInPosition()
    {
        if (_playerManager.Health > 0)
        {
            _timeVariable += 1 * Time.deltaTime;
            var position = transform.position;
        
            var sin = Mathf.Sin(_timeVariable * _floatFreqY) * _floatHeightY;
            var cos = Mathf.Cos(_timeVariable * _floatFreqX) * _floatHeightX;
            var x = position.x;
            var y = position.y;
            var z = position.z;

            transform.position= new Vector3(x + cos, y + sin, z);
        }
        
    }
    private void SetHealthBar(int health)
    {
        _healthSlider.value = health;
    }

    private void CheckPos()
    {
        if (transform.position == virusPositionHolder.transform.position)
        {
            _isInPosition = true;
        }
    }

    private void BringVirusClose()
    {
        transform.position = Vector3.MoveTowards(transform.position, virusPositionHolder.transform.position, _speed* Time.deltaTime); 
    }

    private void StopSpawner()
    {
        _spawner.StopSpawning();
    }

    private bool IsScoreLimitReached()
    {
        return _playerManager.Score >= virusData.scoreLimit;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player/Attack"))
        {
           VirusHitLogic();
        }
      
     
    }
}
