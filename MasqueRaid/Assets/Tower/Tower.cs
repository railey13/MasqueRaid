using UnityEngine;

public class Tower : MonoBehaviour
{
    [Header("Targeting")]
   private float _range;
    [SerializeField] private string _enemyTag = "Enemies";
    [SerializeField] private Transform _firePoint;
    [SerializeField] private GameObject _bulletPrefab;
    private int _damage;
    private SpriteRenderer _spriteRenderer;


    [Header("Tower Level Data")]
    [SerializeField] private TowerData _towerLevelData;
    private int _currentLevel = 0;

    private Transform _target;


   private float _fireRate;

    private float _nextFireTime;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        ApplylevelStats();
    }
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

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _range);
    }

    public void UpgradeTower()
    {
        if (_currentLevel + 1 >= _towerLevelData.TowerLevels.Length)
            return;

        TowerLevelData nextLevel =
            _towerLevelData.TowerLevels[_currentLevel + 1];

        if (Inventory.Instance.HasEnoughResources(nextLevel.UpgradeCosts))
        {
            // Consume upgrade costs here
            foreach (ResourceCost cost in nextLevel.UpgradeCosts)
            {
                Inventory.Instance.ConsumeItem(
                    cost.ResourceMaterial,
                    cost.ResourceAmount
                );
            }
            _currentLevel++;

            ApplylevelStats();
        }
    }

    private void ApplylevelStats()
    {
        TowerLevelData temp;
        temp = _towerLevelData.TowerLevels[_currentLevel];

        _damage = temp.Damage;
        _range = temp.Range;
        _fireRate = temp.FireRate;

        _spriteRenderer.sprite = temp.Sprite;
    }




    private void Update()
    {
        FindTarget();
        Shoot();
    }
}