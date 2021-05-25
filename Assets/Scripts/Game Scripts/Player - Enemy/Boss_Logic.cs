using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Logic : MonoBehaviour
{
    [SerializeField] private BossData_Object bossData;
    [SerializeField] private GameObject bossPositionHolder;
    private Player_Manager _playerManager;
    private float _speed;
    private bool _isInPosition;
    void Start()
    {
        _playerManager = GameObject.FindWithTag("Player").GetComponent<Player_Manager>();
        _speed = bossData.speed ;
    }


    void Update()
    {
        CheckPos();
        if (IsScoreLimitReached())
        {
            StopSpawner();
            if (!_isInPosition)
            {
                BringBossClose();
            }
            else
            {
                // print("is in ppostion");
            }
        }
        
    }

    void CheckPos()
    {
        if (transform.position == bossPositionHolder.transform.position)
        {
            _isInPosition = true;
        }
    }
    void BringBossClose()
    {
        transform.position = Vector3.MoveTowards(transform.position, bossPositionHolder.transform.position, _speed* Time.deltaTime); 
    }
    void StopSpawner()
    {
        GameObject.Find("Spawner").GetComponent<Spawner_Manager>().StopSpawning();
    }
    bool IsScoreLimitReached()
    {
        if (_playerManager.Score >= bossData.scoreLimit)
        {
            return true;
        }
        return false;
    }

    private void OnTriggerEnter(Collider other)
    {
    
        //TODO add player bullet minus enemy Health 
     
    }
}
