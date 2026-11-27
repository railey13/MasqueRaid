using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //ENEMY PREFAB
    [SerializeField] private GameObject enemyPrefab;

    //REGULAR SPAWN TIME
    [SerializeField] private float minSpawnTime;
    [SerializeField] private float maxSpawnTime;

    //VARIABLES
    private float timeUntilSpawn;
    private int waveCounter; //referenced from timer script

    private void Awake()
    {
        SetTimeUntilSpawn();
    }

    void Update()
    {
        timeUntilSpawn -= Time.deltaTime;

        if (timeUntilSpawn <= 0)
        {
            Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            SetTimeUntilSpawn();
        }

        //Instantiate(enemyPrefab, transform.position, Quaternion.identity);

    }

    private void SetTimeUntilSpawn()
    {
        timeUntilSpawn = Random.Range(minSpawnTime, maxSpawnTime);

    }

}
