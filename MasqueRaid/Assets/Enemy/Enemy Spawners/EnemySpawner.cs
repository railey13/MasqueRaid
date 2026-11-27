using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    //ENEMY PREFAB
    [SerializeField] private GameObject enemyPrefab;

    //REGULAR SPAWN TIME
    [SerializeField] private float minSpawnTime;
    [SerializeField] private float maxSpawnTime;

    //WAVE SPAWN TIME
    [SerializeField] private Canvas timer;

    //VARIABLES
    private int waveCounter;
    private float timeUntilSpawn;

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
    }

    private void SetTimeUntilSpawn()
    {
        timeUntilSpawn = Random.Range(minSpawnTime, maxSpawnTime);

    }

}
