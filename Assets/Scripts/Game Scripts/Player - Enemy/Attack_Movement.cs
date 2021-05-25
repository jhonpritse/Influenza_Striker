using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_Movement : MonoBehaviour
{
    [SerializeField] private PlayerData_Object playerData;

    private float _speed;
    private Rigidbody _rigidbody;
    
    void Start()
    {
        _speed = playerData.attackSpeed*100;
        _rigidbody = GetComponent<Rigidbody>();
        
        Destroy(gameObject, 4f);
    }
    
    void Update()
    {
        _rigidbody.AddForce(0, 0, +_speed *Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EnemyBoss"))
        {
            //TODO add boss minus health
           
        }
        Destroy(gameObject);
    }
}
