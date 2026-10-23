using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class EnemyProjectile_Script : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D RBBullet;

    [SerializeField] private float bulletSpeed;
    [SerializeField] private float bulletLifetime;
    [SerializeField] public float bulletDamage;

    private float timer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        RBBullet = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

        Vector3 direction = player.transform.position - transform.position;
        RBBullet.linearVelocity = new Vector2(direction.x, direction.y).normalized * bulletSpeed;
        //transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, bulletSpeed * Time.deltaTime);

        float rotation = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotation + 45);
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer > bulletLifetime)
        {
            Destroy(gameObject);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Player>().PlayerHealth -= bulletDamage;
            Destroy(gameObject);
        }
    }
}
