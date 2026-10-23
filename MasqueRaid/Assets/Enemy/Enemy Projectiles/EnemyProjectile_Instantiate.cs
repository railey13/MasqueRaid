using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class EnemyProjectile_Instantiate : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPos;

    [SerializeField] private float enemyRange; 

    private float timer;
    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        float distance = Vector2.Distance(transform.position, player.transform.position);
        Debug.Log(distance);

        if (distance < enemyRange)
        {
            if(timer > 2)
            {
                timer = 0;
                shootBullet();
            }
        }
        
    }

    private void shootBullet()
    {

        Instantiate(bullet, bulletPos.position, Quaternion.identity);
    }


}
