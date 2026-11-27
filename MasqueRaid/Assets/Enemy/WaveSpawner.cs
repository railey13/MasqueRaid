using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

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

    //PRIVATE VARIABLES
    //Timer
    private GameObject timer;
    private TimerScript timerScript;
    private int waveTimer;
    private float nextSpawnTime;

    //Wave Counting
    private Wave currentWave;
    private int currentWaveNum;

    //Enemy Counting
    private bool canSpawn = true;

    //Enemy Counter UI
    //[SerializeField] TextMeshProUGUI enemyCounterText;

    private void Start()
    {
        timerScript = timer.GetComponent<TimerScript>();
    }

    void SpawnWave()
    {
        if (canSpawn && nextSpawnTime < Time.time)
        {
            GameObject randomEnemy = currentWave.enemyTypes[Random.Range(0, currentWave.enemyTypes.Length)]; //this doesn't work
            Transform randomPoint = spawnPoints[Random.Range(0, spawnPoints.Length)]; //this works
            Instantiate(randomEnemy, randomPoint.position, Quaternion.identity);

            currentWave.noOfEnemies--;
            //variety in enemy spawn rate per wave
            nextSpawnTime = Time.time + currentWave.spawnInterval;

            //limiting spawn interval for each wave to specified number of enemies
            if (currentWave.noOfEnemies == 0)
            {
                canSpawn = false;
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        currentWave = waves[currentWaveNum];
        SpawnWave();

        waveTimer = timerScript.returnWaveCounter();

        /*
        GameObject[] totalEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        int enemyCounter = totalEnemies.Length;
        enemyCounterText.text = string.Format("Enemies Left: {0}", enemyCounter);
        */

        /*
         * should guarantee that next wave activates REGARDLESS of how many enemies
         * in the current wave are still alive
        */

        currentWaveNum++;

    }
}
