using UnityEngine;

public class TargetableObjects : MonoBehaviour {
    [Header("Object Attributes")]
    [SerializeField] private float _health;
    [SerializeField] private DroppedResource _dropPrefab;
    [SerializeField] private int _maxDropCount = 3;
    [SerializeField] private ScriptableDrops _drop;

    private int _dropCount = 1;

    private void Awake() {
        _dropCount = Random.Range(1, _maxDropCount);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("PlayerProjectile")) {
            _health -= other.GetComponent<PlayerProjectile>().Damage;
            if (_health <= 0) {
                Destroy(gameObject);
                if (_drop != null) {
                    DroppedResource obj = Instantiate(_dropPrefab, transform.position, Quaternion.identity);
                    obj.SetDrop(_drop, _dropCount);
                }
            }
        }
    }
}
