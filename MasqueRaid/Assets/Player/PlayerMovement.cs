using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    [Header("GObject Components")]
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private Animator _playerAnimator;
    [SerializeField] private SpriteRenderer _playerSprite;
    [SerializeField] private PlayerAction _inputActions;
    [SerializeField] private Camera _cam;
    [SerializeField] private Transform _pointerAnchor;

    [Header("Player Attributes")]
    [SerializeField] private float _playerSpeed = 2f;
    private Vector2 _moveDir;

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

    private void LookAtMouse() {
        Vector2 mouseScreenPos = _inputActions.Player.Look.ReadValue<Vector2>();
        Vector2 mouseWorldPos = _cam.ScreenToWorldPoint(mouseScreenPos);

        Vector2 direction = mouseWorldPos - (Vector2)_pointerAnchor.position;
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
    }
    public void OnDisable() {
        _inputActions.Disable();    
    }

}
