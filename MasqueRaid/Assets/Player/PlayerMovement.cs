using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    [Header("GObject Components")]
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private Animator _playerAnimator;
    [SerializeField] private PlayerAction _inputActions;
    //[SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Transform _pointerAnchor;

    public void Awake() {
        _inputActions = new PlayerAction();
    }

    public void Start() {
        _inputActions.Player.Move.performed += ctx => Move(ctx.ReadValue<Vector2>());
        _inputActions.Player.Move.canceled += ctx => Move(Vector2.zero);
    }   
    public void Move(Vector2 direction) {
        _rb.MovePosition(_rb.position + direction * 5f * Time.fixedDeltaTime);
        //_rb.linearVelocity = new Vector2(direction.x * 5f, _rb.linearVelocity.y);
        //_playerAnimator.SetFloat("Speed", Mathf.Abs(direction.x));
    }

    public void OnEnable() {
        _inputActions.Enable();
    }
    public void OnDisable() {
        _inputActions.Disable();    
    }

}
