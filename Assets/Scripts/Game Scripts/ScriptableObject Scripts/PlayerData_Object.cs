
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Scriptable Objects/PlayerData")]
public class PlayerData_Object : ScriptableObject
{
    [Range(0, 10)] 
    public int health;
    public float moveSpeed;
    public float jumpSpeed;
  
    public float attackSpeed;
    public GameObject attackPrefab;
    public GameObject attackShootParticle;
    public GameObject healthUI;
    
    [Range(0, 4)] public float groundCheckFeetRadius;
}
