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
    private int _maxChanceValue;
    private int _maxOfLowObj;
    private int _maxOfHighObj;
    
    private void Start()
    {
        _canSpawn = true;
        _spawnerPos = transform.Find("Spawner").transform;
        
        _maxChanceValue = chanceToSpawnFlyingObjInPercentage + chanceToSpawnHighObjInPercentage + chanceToSpawnLowObjInPercentage;
         _maxOfLowObj = chanceToSpawnLowObjInPercentage;
         _maxOfHighObj = chanceToSpawnLowObjInPercentage + chanceToSpawnHighObjInPercentage;
         
        StartCoroutine(SpawnTimer(0));
    }

    public void StopSpawning()
    {
        _canSpawn = false;
    }
    
    private void SpawnObstacle()
    {

        //set chance of per object type to be spawned
        //inside per object type, set random chance to spawn object in array
        var randValue = Random.Range(1, _maxChanceValue);
        
        if (randValue < _maxOfLowObj)
        {
            // print("Spawned Low");
            var randArrayIndex = Random.Range(0, lowObstacle.Length);
            Instantiate(lowObstacle[randArrayIndex], _spawnerPos.position, Quaternion.identity);
        }
        else if(randValue > _maxOfLowObj && randValue < _maxOfHighObj)
        {
            // print("Spawned High");
            var randArrayIndex = Random.Range(0, highObstacle.Length);
            Instantiate(highObstacle[randArrayIndex], _spawnerPos.position, Quaternion.identity);
        }
        else if (randValue > _maxOfHighObj && randValue < _maxChanceValue)
        {
            // print("Spawned Flying Object");
            var randArrayIndex = Random.Range(0, flyingObstacle.Length);
            Instantiate(flyingObstacle[randArrayIndex], _spawnerPos.position, Quaternion.identity);
        }
    }
    
    IEnumerator SpawnTimer(float firstDelay)
    {
        var spawnRateCountdown = timeUntilSpawnRateIncrease;
        var spawnCountdown = firstDelay;

        while (true)
        {
            yield return null;
            spawnRateCountdown -= Time.deltaTime;
            spawnCountdown -= Time.deltaTime;

            //Spawning Object
            if (spawnCountdown < 0)
            {
                spawnCountdown += spawnRate;
                if (_canSpawn) SpawnObstacle();
            }

            // decrease SpawnRate 
            if (spawnRateCountdown <= 0 && spawnRate >= maxSpawnRate)
            {
                spawnRateCountdown += timeUntilSpawnRateIncrease;
                spawnRate -= decrementSpawnRate;
            }
        }
        
        // ReSharper disable once IteratorNeverReturns
    }
    
}

