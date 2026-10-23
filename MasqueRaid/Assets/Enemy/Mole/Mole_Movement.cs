using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class Mole_Movement : MonoBehaviour
{
    [SerializeField] private float speed;

    //[SerializeField] private float rotationSpeed;

    private Rigidbody2D RB2D;
    private Transform player;

    private PlayerAwareness playerAwareness;
    private Vector2 targetDirection;
    private float changeDirectionCooldown;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        RB2D = GetComponent<Rigidbody2D>();
        playerAwareness = GetComponent<PlayerAwareness>();
        player = GameObject.FindGameObjectWithTag("Player").transform;

        targetDirection = transform.up;

    }

    // Update is called once per frame
    private void Update()
    {
        UpdateTargetDirection();
        //RotateTowardsTarget();
        SetVelocity();

    }

    private void UpdateTargetDirection()
    {
        setRandomDirection();
        playerTargeting();

    }

    private void setRandomDirection()
    {
        changeDirectionCooldown -= Time.deltaTime;

        if (changeDirectionCooldown <= 0)
        {
            float angleChange = Random.Range(-90f, 90f);
            Quaternion rotation = Quaternion.AngleAxis(angleChange, transform.forward);
            targetDirection = rotation * targetDirection;

            changeDirectionCooldown = Random.Range(1f, 5f);
        }

    }

    private void playerTargeting()
    {
        if (playerAwareness.AwareOfPlayer)
        {
            targetDirection = playerAwareness.DirectionToPlayer;
        }

    }

    /*
    private void RotateTowardsTarget()
    {
        if (targetDirection == Vector2.zero)
        {
            return;
        }

        Quaternion targetRotation = Quaternion.LookRotation(transform.forward, targetDirection);
        Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

    }
    */

    private void SetVelocity()
    {
        transform.position = Vector2.MoveTowards(this.transform.position, player.position, speed * Time.deltaTime);

    }
}
