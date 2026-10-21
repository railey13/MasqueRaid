using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class EnemyDeath : MonoBehaviour
{
    [SerializeField] private int enemyHP;

    private Collider2D selfCollider;
    //private Collider2D bulletCollider;
    //private GameObject bullet;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //bullet = GameObject.FindGameObjectWithTag("Bullet");
        selfCollider = this.GetComponent<Collider2D>();
        //bulletCollider = bullet.GetComponent<Collider2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (selfCollider.IsTouching(GameObject.FindGameObjectWithTag("Bullet").GetComponent<Collider2D>()))
        {
            enemyHP--;
        }

        destroySelf();
        
    }

    private void destroySelf()
    {
        if(enemyHP <= 0)
        {
            Destroy(this);
        }
    }
}
