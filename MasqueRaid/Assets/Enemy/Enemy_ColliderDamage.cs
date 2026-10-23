using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

[System.Serializable]

public class Enemy_ColliderDamage : MonoBehaviour
{
    [SerializeField] private float enemyCollisionDamage;

    private GameObject player;
    private float playerHealth;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<Player>().PlayerHealth;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            playerHealth = playerHealth - enemyCollisionDamage;
            player.GetComponent<Player>().PlayerHealth = playerHealth;
        }
    }
    
}
