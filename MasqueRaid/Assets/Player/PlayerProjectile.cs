using UnityEngine;

public class PlayerProjectile : MonoBehaviour {
    [Header("Attributes")]
    [SerializeField] private float _speed = 10f;
    [SerializeField] private float _lifetime = 3f;

    private float _damage = 1f;
    public float Damage { get { return _damage; } }

    private Vector2 _dir;

    public void Initialize(Vector2 dir, float dmg) {
        _dir = dir.normalized;
        _damage = dmg;  
        transform.up = _dir;
        Destroy(gameObject, _lifetime);
    }

    private void Update() {
        transform.position += (Vector3)(_dir * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("HitObject")) {
            Destroy(gameObject);
        }
    }

}
