using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treant_Movement : MonoBehaviour
{
    public float speed;
    private Transform player;
    private Rigidbody2D RB2d;
    
    void Start()
    {
        RB2d = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("MC").transform;
        
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(this.transform.position, player.position, speed * Time.deltaTime);
    }
}
