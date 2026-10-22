using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyDeath : MonoBehaviour
{
    [SerializeField] private float _currentEnemyHP;
    [SerializeField] private float _maxEnemyHealth;

    /*
    public float RemainingHealthPercentage
    {
        get
        {
            return _currentEnemyHP / _maxEnemyHealth;
        }
    }

    public void enemyTakesDamage(float damageAmount)
    {
        if (_currentEnemyHP == 0)
        {
            return;
        }


        _currentEnemyHP -= damageAmount;

        if (_currentEnemyHP < 0)
        {
            _currentEnemyHP = 0;
        }

        if (_currentEnemyHP == 0)
        {
            OnDied.Invoke();
            Destroy(gameObject);
        }

    }

    public void enemyHeals(float amountToAdd)
    {
        if (_currentEnemyHP == _maxEnemyHealth)
        {
            return;
        }

        _currentEnemyHP += amountToAdd;

        if (_currentEnemyHP > _maxEnemyHealth)
        {
            _currentEnemyHP = _maxEnemyHealth;
        }

    }
    */
    void Update()
    {
        destroyObject();


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlayerProjectile")
        {
            _currentEnemyHP--;

        }

    }

    private void destroyObject()
    {
        if(_currentEnemyHP <= 0)
        {
            _currentEnemyHP = 0;
            Destroy(this.gameObject);
        }
    }

}
