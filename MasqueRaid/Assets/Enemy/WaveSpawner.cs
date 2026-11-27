using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class Wave
{
    public int noOfEnemies;
    public GameObject[] enemyTypes;
    public float spawnInterval;
    
}

public class WaveSpawner : MonoBehaviour
{
    //SERIALIZABLE
    [SerializeField] Wave[] waves;
    [SerializeField] Transform[] spawnPoints;
    //[SerializeField] GameObject[] enemySpawners;

    //PRIVATE VARIABLES
    //Timer
    private GameObject timer;
    private TimerScript timerScript;
    private int waveTimer;

    private float nextSpawnTime;

    //Wave Counting
    private Wave currentWave;
    private int currentWaveNum = 1; //instantiate to wave 1

    //Enemy Counting
    private bool canSpawn = true;

    private void Start()
    {
        timerScript = timer.GetComponent<TimerScript>();
    }

    void SpawnWave()
    {
        if (canSpawn && nextSpawnTime < Time.time)
        {
            GameObject randomEnemy = currentWave.enemyTypes[Random.Range(0, currentWave.enemyTypes.Length)];
            Transform randomPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            Instantiate(randomEnemy, randomPoint.position, Quaternion.identity);

            //currentWave.noOfEnemies--;
            nextSpawnTime = Time.time + currentWave.spawnInterval;

        }
        
    }

    // Update is called once per frame
    void Update()
    {
        currentWave = waves[currentWaveNum];
        SpawnWave();

        waveTimer = timerScript.returnWaveCounter();

        /*
         * should guarantee that next wave activates REGARDLESS of how many enemies
         * in the current wave are still alive
        */
        if(currentWaveNum < waveTimer)
        {
            currentWaveNum++;
            canSpawn = true;
        }

    }
}
