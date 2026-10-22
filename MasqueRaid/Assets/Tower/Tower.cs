using UnityEngine;

public class Tower : MonoBehaviour
{
    [Header("Targeting")]
    [SerializeField] private float _range = 5f;
    [SerializeField] private string _enemyTag = "Enemies";
    [SerializeField] private Transform _firePoint;
    [SerializeField] private GameObject _bulletPrefab;

    private Transform _target;


    [Header("Shooting")]
    [SerializeField] private float _fireRate = 1f;

    private float _nextFireTime;


    private void FindTarget()
    {
            Collider2D[] enemiesInRange = Physics2D.OverlapCircleAll(transform.position, _range);
        Transform nearestEnemey = null;
        float nearestDistance = Mathf.Infinity;
            foreach(Collider2D enemy in enemiesInRange)
        {
            if (enemy.CompareTag(_enemyTag))
            {
                float distanceToEnemy = Vector2.Distance(transform.position, enemy.transform.position);
                if (distanceToEnemy < nearestDistance)
                {
                    nearestDistance = distanceToEnemy;
                    nearestEnemey = enemy.transform;
                }
            }
        }

            _target = nearestEnemey;
    }

    private  void Shoot()
    {
        if (Time.time >= _nextFireTime)
        {
            _nextFireTime = Time.time + 1f / _fireRate;
            if (_target != null)
            {
                Vector2 direction = (_target.position - _firePoint.position).normalized;
                GameObject bullet = Instantiate(_bulletPrefab, _firePoint.position, Quaternion.identity);
                bullet.GetComponent<Bullet1>().Shoot(direction);
            }
        }
    
    }

    private void Update()
    {
        FindTarget();
        Shoot();
    }
}