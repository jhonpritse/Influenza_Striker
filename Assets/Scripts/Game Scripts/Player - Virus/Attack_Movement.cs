using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_Movement : MonoBehaviour
{
    [SerializeField] private PlayerData_Object playerData;
    [SerializeField] private VirusData_Object virusData;
    private float _speed;
    private Rigidbody _rigidbody;
    private bool _isAPlayerAttack;
    private bool _isAVirusAttack;
    private Vector3 _playerHitPos;
    private GameObject _attackShootParticle;
    private GameObject _virusShootParticle;
    
    void Start()
    {
        //attack is form player
        if (playerData != null)
        {
            _speed = playerData.attackSpeed*100;
            gameObject.tag = "Player/Attack";
            _attackShootParticle = playerData.attackShootParticle;
            _isAPlayerAttack = true;
        }
        //attack is form virus
        else if (virusData != null)
        {
            _speed = virusData.attackSpeed*100;
            gameObject.tag = "Virus/Attack";
            _playerHitPos = GameObject.FindWithTag("Player/Body").GetComponent<Transform>().Find("HitPos").position;
            _virusShootParticle = virusData.virusShootParticle;
            _isAVirusAttack = true;
        }
        
        _rigidbody = GetComponent<Rigidbody>();


        //for performance safety, Destroy after 2sec
        Destroy(gameObject, 3f);
    }

    private void PlayerAttackLogic()
    {
        _rigidbody.AddForce(0, 0, +_speed *Time.deltaTime);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
     
        Gizmos.DrawWireSphere(_playerHitPos, 2);
    }

    private void VirusAttackLogic()
    {
        transform.position = Vector3.MoveTowards(transform.position, _playerHitPos, virusData.attackSpeed* Time.deltaTime);
        if (transform.position == -_playerHitPos)
        {
             Destroy(gameObject);
             //TODO add particles for miss hit 
        }
    }
    void Update()
    {
        if (_isAPlayerAttack) PlayerAttackLogic();
     
        if (_isAVirusAttack) VirusAttackLogic();
        
    }
    private void OnTriggerEnter(Collider other)
    {  
        if (_isAPlayerAttack)
        {
            if (other.CompareTag("Virus/Body"))
            {
                Destroy(gameObject);
                //TODO add particles on virus hit
            }
            if (other.CompareTag("Virus/Attack"))
            {
                Instantiate(_attackShootParticle, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
        
        else if (_isAVirusAttack)
        {
            if (other.CompareTag("Player/Body"))
            {
                Destroy(gameObject);
                //TODO add particles on player hit
            }
            if (other.CompareTag("Player/Attack"))
            {
                Instantiate(_virusShootParticle, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }

     

       
        
    }
}
