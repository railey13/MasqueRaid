using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class Treant_Movement : MonoBehaviour
{
    [SerializeField]    private float speed;

    [SerializeField]    private float rotationSpeed;

    private Rigidbody2D RB2D;
    private Transform player;

    private PlayerAwarenessController playerAwareness;
    private Vector2 targetDirection;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        RB2D = GetComponent<Rigidbody2D>();
        playerAwareness = GetComponent<PlayerAwarenessController>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        
    }

    // Update is called once per frame
    private void Update()
    {
        UpdateTargetDirection();
        RotateTowardsTarget();
        SetVelocity();
        
    }

    private void UpdateTargetDirection()
    {
        if (playerAwareness.AwareOfPlayer)
        {
            targetDirection = playerAwareness.DirectionToPlayer;
        }
        else
        {
            targetDirection = Vector2.zero;
        }


    }

    private void RotateTowardsTarget()
    {
        if(targetDirection == Vector2.zero)
        {
            return;
        }

        Quaternion targetRotation = Quaternion.LookRotation(transform.forward, targetDirection);
        Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

    }

    private void SetVelocity()
    {
        if(targetDirection == Vector2.zero)
        {
            RB2D.linearVelocity = Vector2.zero; 
        }
        else
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.position, speed*Time.deltaTime);
        }

    }
}
