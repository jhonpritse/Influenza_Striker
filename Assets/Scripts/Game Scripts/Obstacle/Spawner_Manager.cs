using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner_Manager : MonoBehaviour
{

    [Range(0, 10)]
    [SerializeField] private int chanceToSpawnLowObjInPercentage;
    [Tooltip("Obstacles that the player needs to JUMP")]
    [SerializeField] private GameObject[] lowObstacle;
    [Space]
    [Range(0, 10)]
    [SerializeField] private int chanceToSpawnHighObjInPercentage;
    [Tooltip("Obstacles that the player needs to SLIDE")]
    [SerializeField] private GameObject[] highObstacle;
    [Space]
    [Range(0, 10)]
    [SerializeField] private int chanceToSpawnFlyingObjInPercentage;
    [Tooltip("Obstacles that the player needs to Avoid")]
    [SerializeField] private GameObject[] flyingObstacle;
    [Space]
    
    
    
    private Transform _spawnerPos;
    
    
    
    [Range(1, 5)]
    [SerializeField]  private float spawnRate;
    [Range(.25f, 3)]
    [SerializeField]  private float maxSpawnRate ;
    [Range(2,60)]
    [SerializeField]  private float timeUntilSpawnRateIncrease;
    [Range(.1f,1)]
    [SerializeField] private float decrementSpawnRate;

    private bool _canSpawn;
    void Start()
    {
        _canSpawn = true;
        _spawnerPos = transform.Find("Spawner").transform;
        StartCoroutine(SpawnTimer(0));
    }

    public void StopSpawning()
    {
        _canSpawn = false;
    }
    private void SpawnObstacle()
    {
        int maxChanceValue = chanceToSpawnFlyingObjInPercentage + chanceToSpawnHighObjInPercentage + chanceToSpawnLowObjInPercentage;
        int maxOfLowObj = chanceToSpawnLowObjInPercentage;
        int maxOfHighObj = chanceToSpawnLowObjInPercentage + chanceToSpawnHighObjInPercentage;
        
        int randValue = Random.Range(1, maxChanceValue);
        
        if (randValue < maxOfLowObj)
        {
            // print("Spawned Low");
            int randArrayIndex = Random.Range(0, lowObstacle.Length);
            Instantiate(lowObstacle[randArrayIndex], _spawnerPos.position, Quaternion.identity);
        }
        else if(randValue > maxOfLowObj && randValue < maxOfHighObj)
        {
            // print("Spawned High");
            int randArrayIndex = Random.Range(0, highObstacle.Length);
            Instantiate(highObstacle[randArrayIndex], _spawnerPos.position, Quaternion.identity);
        }
        else if (randValue > maxOfHighObj && randValue < maxChanceValue)
        {
            // print("Spawned Flying Object");
            int randArrayIndex = Random.Range(0, flyingObstacle.Length);
            Instantiate(flyingObstacle[randArrayIndex], _spawnerPos.position, Quaternion.identity);
        }

    }
    
    // public AnimationCurve plot = new AnimationCurve();
    IEnumerator SpawnTimer( float firstDelay )
    {
        float spawnRateCountdown = timeUntilSpawnRateIncrease ;
        float spawnCountdown = firstDelay ;
        
        while (true)
        {
            yield return null ;
            spawnRateCountdown -= Time.deltaTime;
            spawnCountdown     -= Time.deltaTime;
           
         
            //Spawning Object
            if( spawnCountdown < 0 )
            {
                spawnCountdown += spawnRate;
                // plot.AddKey(Time.realtimeSinceStartup, spawnCountdown);
                if (_canSpawn) SpawnObstacle();
            }
            
            // decrease SpawnRate 
            if( spawnRateCountdown <= 0 && spawnRate > maxSpawnRate )
            {
                spawnRateCountdown += timeUntilSpawnRateIncrease;
                spawnRate -= decrementSpawnRate;
            }
            
            
            
        }
        
      
    }


    void Update()
    {
        
    }
}
