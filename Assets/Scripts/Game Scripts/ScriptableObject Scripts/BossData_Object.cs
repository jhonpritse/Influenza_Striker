using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BossData", menuName = "Scriptable Objects/BossData")]
public class BossData_Object : ScriptableObject
{
   public float scoreLimit;
   public int health;
   public GameObject enemyAttack;
   public GameObject enemyShootParticle;
   public float attackRate;
   public float speed;

}
