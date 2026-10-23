using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class EnemyDeath : MonoBehaviour
{
    [SerializeField] private float _currentEnemyHP;
    [SerializeField] private float _maxEnemyHealth;


    void Update()
    {
        destroyObject();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerProjectile") || collision.gameObject.CompareTag("TowerProjectile"))
        {
            _currentEnemyHP--;
        }
    }

    public UnityEvent OnDied;


    private void destroyObject()
    {
        if(_currentEnemyHP <= 0)
        {
            OnDied.Invoke();

            _currentEnemyHP = 0;
            Destroy(gameObject);
        }
    }

}
