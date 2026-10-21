using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class SpawnPoint_Movement : MonoBehaviour
{
    public float position;
    private Transform player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("MC").transform;

    }

    // Update is called once per frame
    void Update()
    {
        //Fixed position of spawn point in any given direction
        transform.position = player.position + this.transform.position;

    }
}
