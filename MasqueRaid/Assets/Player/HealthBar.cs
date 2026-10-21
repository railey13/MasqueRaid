using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {
    [SerializeField] Slider _healthSlider;

    private float _maxHealth = 1f;
    private float _currentHealth = 1f;

    public void Initialize(float maxHP, float hp) {
        SetMaxHealth(maxHP);
        SetHealth(hp);
    }

    public void SetMaxHealth(float maxHealth) {
        _maxHealth = maxHealth;
        _healthSlider.maxValue = _maxHealth;
        _healthSlider.value = _maxHealth;
    }

    public void SetHealth(float hp) {
        _currentHealth = hp;
        _healthSlider.value = _currentHealth;
    }
   

}
