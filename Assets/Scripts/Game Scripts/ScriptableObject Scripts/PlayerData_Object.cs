
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Scriptable Objects/PlayerData")]
public class PlayerData_Object : ScriptableObject
{
    [Range(0, 7)] 
    public int health;
    public float moveSpeed;
    public float jumpSpeed;
    [Range(0, 6)] public float slideTime;
    [Range(0, 4)] public float groundCheckFeetRadius;
    public float attackSpeed;
    public GameObject attackPrefab;
    public GameObject attackShootParticle;
    public GameObject healthUI;
}
