using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class EnemyProjectile_Instantiate : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPos;

    private float timer;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer > 2)
        {
            timer = 0;
            shootBullet();
        }
        
    }

    private void shootBullet()
    {

        Instantiate(bullet, bulletPos.position, Quaternion.identity);
    }


}
