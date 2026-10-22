using UnityEngine;

public class Bullet1 : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _lifespan = 3f;
    [SerializeField] private string _enemyTag = "Enemy";

    private Rigidbody2D rb;

    private  void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

   public void Shoot(Vector2 direction)
    {
        rb.linearVelocity = direction * _speed;
        Destroy(gameObject, _lifespan);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(_enemyTag))
        {
            // Handle collision with enemy
            Debug.Log("Bullet hit an enemy!");
            Destroy(gameObject);
        }
    }



}
