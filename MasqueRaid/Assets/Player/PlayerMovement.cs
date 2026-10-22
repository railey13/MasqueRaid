using System.Xml.Serialization;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    [Header("Components")]
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private Animator _playerAnimator;
    [SerializeField] private SpriteRenderer _playerSprite;
    [SerializeField] private Camera _cam;
    [SerializeField] private Transform _pointerAnchor;
    [SerializeField] public Transform SpawnLocation;
    [SerializeField] private GameObject[] _towers;
    private int _selectedTowerIndex = 0;


    [Header("Movement")]
    [SerializeField] private float _playerSpeed = 2f;

    private PlayerAction _inputActions;
    private Vector2 _moveDir;

    public Vector2 AimDirection { get; private set; } = Vector2.right;

    public void Awake() {
        _inputActions = new PlayerAction();
    }

    public void Update() {
        _moveDir = _inputActions.Player.Move.ReadValue<Vector2>();
        
        setAnim(_moveDir);
        LookAtMouse();
    }

    public void FixedUpdate() {
        _rb.MovePosition(_rb.position + _moveDir * _playerSpeed * Time.fixedDeltaTime);
    }

    private void setAnim(Vector2 moveDir) {
        if (moveDir == Vector2.zero) {
            _playerAnimator.SetBool("isWalking", false);
        }
        else {
            _playerAnimator.SetBool("isWalking", true);
        }

    }

    private void OnXPressed(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        Debug.Log("X pressed");
        Instantiate(_towers[_selectedTowerIndex], SpawnLocation.position, Quaternion.identity);
    }

    private void OnQPresses(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        _selectedTowerIndex =
            (_selectedTowerIndex + 1) % _towers.Length;

        Debug.Log("Selected Tower: " + _towers[_selectedTowerIndex].name);
    }

    private void LookAtMouse() {
        Vector2 mouseScreenPos = _inputActions.Player.Look.ReadValue<Vector2>();
        Vector2 mouseWorldPos = _cam.ScreenToWorldPoint(mouseScreenPos);

        Vector2 direction = mouseWorldPos - (Vector2)_pointerAnchor.position;
        AimDirection = direction.normalized;
        _pointerAnchor.up = -direction;


        if (direction.x >= Vector2.right.x) {
            _playerSprite.flipX = false;
        }
        else if (direction.x <= Vector2.left.x) {
            _playerSprite.flipX = true;
        }
    }

    public void OnEnable() {
        _inputActions.Enable();

        _inputActions.Player.PlaceTower.performed += OnXPressed;
        _inputActions.Player.Cycle.performed += OnQPresses;
    }
    public void OnDisable() {
        _inputActions.Disable();
        _inputActions.Player.PlaceTower.performed -= OnXPressed;
        _inputActions.Player.Cycle.performed -= OnQPresses;

    }

}
