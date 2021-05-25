using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_Destroyer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Obstacle"))
        {
            Destroy(other.gameObject);
        }
       
    }
}
