using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class Enemy_IsAttacked : MonoBehaviour
{
    [SerializeField] private float _damageAmount;

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlayerProjectile")
        {
            var healthController = collision.gameObject.GetComponent<EnemyHealthController>();

            healthController.enemyTakesDamage(_damageAmount);
        }
    }

}
