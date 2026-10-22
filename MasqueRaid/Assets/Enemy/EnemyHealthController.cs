using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]

public class EnemyHealthController : MonoBehaviour
{
    [SerializeField] private float _currentEnemyHP;
    [SerializeField] private float _maxEnemyHealth;

    private Collider2D selfCollider;

    public float RemainingHealthPercentage
    {
        get
        {
            return _currentEnemyHP / _maxEnemyHealth;
        }
    }

    public UnityEvent OnDied;

    public void enemyTakesDamage(float damageAmount)
    {
        if(_currentEnemyHP == 0)
        {
            return;
        }


        _currentEnemyHP -= damageAmount;

        if(_currentEnemyHP < 0)
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
        if(_currentEnemyHP == _maxEnemyHealth)
        {
            return;
        }

        _currentEnemyHP += amountToAdd;

        if (_currentEnemyHP > _maxEnemyHealth)
        {
            _currentEnemyHP = _maxEnemyHealth;
        }

    }


}
