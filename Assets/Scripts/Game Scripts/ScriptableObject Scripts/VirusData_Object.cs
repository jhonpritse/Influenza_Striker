using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "VirusName", menuName = "Scriptable Objects/VirusData")]
public class VirusData_Object : ScriptableObject
{
   public string virusName;
   public int cardIndexKey;
   public float scoreLimit;
   public int health;
   public int playerDamage;
   public int plusScoreWhenHit;
   public GameObject virusAttack;
   public GameObject virusShootParticle;
   public float attackRate;
   public float attackSpeed;
   [Space]
   [Range(0,0.02f)] public float floatingHeightY;
   [Range(0,2f)]  public float floatingFreqY;
   [Range(0,.25f)]  public float floatingHeightX;
   [Range(0,2)]  public float floatingFreqX;

    public float movementSpeed;
    [Space]
   //TODO make custom editor for description managing
   [TextArea(5,10)] public string description1;
   [TextArea(5,10)] public string description2;
   [TextArea(5,10)] public string description3;

}
