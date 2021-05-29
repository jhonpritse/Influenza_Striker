using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_HitPosition : MonoBehaviour
{
    private GameObject _virus;
    private GameObject _player;
    private GameObject _playerAttackPoint;


    private float x;
    private float y;
    private float z;

    private Vector3 _virusPosition;
    private Vector3 _playerPosition;
    private Vector3 _playerAttackPosition;

    private void Start()
    {
        _virus = GameObject.FindWithTag("Virus/Body");
        _player = GameObject.FindWithTag("Player/Body");
        _playerAttackPoint = _player.transform.Find("HandPos").gameObject;
    }
    
    public void SetHitPosition()
    {
        _virusPosition = _virus.transform.position;
        _playerPosition = _player.transform.position;
        _playerAttackPosition = _playerAttackPoint.transform.position;
        x = (_playerPosition.x *2) + (-_virusPosition.x);
        y = (_playerPosition.y *2) + (-_virusPosition.y);
        z =  -_virusPosition.z;

        var hitPos = new Vector3 (x, y, z);
        transform.position = hitPos;
    }
    
    
    // private void OnDrawGizmos()
    // {
    //    
    //     Gizmos.color = Color.magenta;
    //     var position = transform.position;
    //     Gizmos.DrawWireSphere(position, 3);
    //     // _virus = GameObject.FindWithTag("Virus/Body").transform.Find("AttackPos").gameObject;
    //     // Gizmos.color = Color.green;
    //     // Gizmos.DrawLine(position, _virus.transform.position);
    // }
}
