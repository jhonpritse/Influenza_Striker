using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_Movement : MonoBehaviour
{
   [SerializeField] private ObstacleData_Object obstacleData;

   private float _speed;
   private Rigidbody _rigidbody;
    void Start()
    {
        _speed = obstacleData.speed*10;
        _rigidbody = GetComponent<Rigidbody>();
        Destroy(gameObject, 20);
    }

  
    void Update()
    {
        _rigidbody.AddForce(0, 0, -_speed *Time.deltaTime);
    }

  
}
