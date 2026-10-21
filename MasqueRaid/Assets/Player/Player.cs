using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour {
    [Header("Attributes")]
    [SerializeField] private float _playerMaxHealth = 50f;
    [SerializeField] private float _playerHealth = 50f;
    [SerializeField] private float _fireRate = 0.5f;
    [SerializeField] private float _projectileDmg = 1f;

    [Header("Others")]
    [SerializeField] private GameObject _projectile;
    [SerializeField] private Transform _anchorPos;

    private PlayerAction _inputActions;
    private PlayerMovement _playerMovement;
    private bool _isFiring = false;
    private float _nextFireTime = 0f;

    private void Awake() {
        _inputActions = new PlayerAction();
        
        _playerMovement = GetComponent<PlayerMovement>();
    }

    private void OnAttackPerformed(InputAction.CallbackContext context) => _isFiring = true;
    private void OnAttackCanceled(InputAction.CallbackContext context) => _isFiring = false;

    private void Update() {
        if (_isFiring && Time.time >= _nextFireTime) {
            _nextFireTime = Time.time + _fireRate;
            Attack();
        }
    }

    private void Attack() {
        GameObject proj = Instantiate(_projectile, _anchorPos.position, Quaternion.identity);
        proj.GetComponent<PlayerProjectile>().Initialize(_playerMovement.AimDirection, _projectileDmg);
    }

    private void OnEnable() {
        _inputActions.Enable();
        _inputActions.Player.Attack.performed += OnAttackPerformed;
        _inputActions.Player.Attack.canceled += OnAttackCanceled;
    }

    private void OnDisable() {
        _inputActions.Player.Attack.performed -= OnAttackPerformed;
        _inputActions.Player.Attack.canceled -= OnAttackCanceled;
        _inputActions.Disable();
    }
}



