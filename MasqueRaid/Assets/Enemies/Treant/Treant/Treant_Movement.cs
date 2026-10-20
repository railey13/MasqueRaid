using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treant_Movement : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private Rigidbody2D RB2D;
    private Transform player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("MC").transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(this.transform.position, player.position, speed*Time.deltaTime);
        
    }
}
