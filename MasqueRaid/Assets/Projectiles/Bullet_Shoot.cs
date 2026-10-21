using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[System.Serializable]

public class Bullet_Shoot : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float bulletSpeed;

    private bool fireContinuously;

    // Update is called once per frame
    void Update()
    {
        if (fireContinuously)
        {
            fireBullet();
        }
        
    }

    private void fireBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.transform.position, transform.rotation);
        Rigidbody2D RB2D = bullet.GetComponent<Rigidbody2D>();

        Vector2 moveDir = transform.position.normalized * bulletSpeed;
        RB2D.MovePosition(moveDir);

        //RB2D.GetPointVelocity((bulletSpeed * transform.up));

    }

    private void OnFire(InputValue inputValue)
    {
        fireContinuously = inputValue.isPressed;

    }
}
