using UnityEngine;

public class DroppedResource : MonoBehaviour {
    [SerializeField] private ScriptableDrops _drop;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private int _amount;

    public void SetDrop(ScriptableDrops drop, int amount) {
        _drop = drop;
        _amount = amount;
        _spriteRenderer.sprite = drop._sprite;
    }

    public void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            Inventory.Instance.AddItem(_drop, _amount);

            Destroy(gameObject);
        }
    }

}



public enum ResourceType { 
    Log,
    Stone
}