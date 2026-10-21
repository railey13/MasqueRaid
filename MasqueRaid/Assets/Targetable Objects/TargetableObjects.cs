using UnityEngine;

public class TargetableObjects : MonoBehaviour {
    [Header("Object Attributes")]
    [SerializeField] private float _health;
    [SerializeField] private GameObject _drop;

    private int _dropCount = 1;

    private void Awake() {
        _dropCount = Random.Range(1, 3);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("PlayerBullet")) {
            _health -= 1;
            if (_health <= 0) {
                Destroy(gameObject);
                if (_drop != null) {
                    for (int i = 0; i < _dropCount; i++) {
                        Instantiate(_drop, transform.position, Quaternion.identity);
                    }
                }
            }
        }
    }
}
