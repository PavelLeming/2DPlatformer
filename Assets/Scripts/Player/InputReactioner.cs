using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class InputReactioner : MonoBehaviour
{
    private const string HorizontalAxis = "Horizontal";
    private const string Jump = "Jump";

    [SerializeField] private GroundDetector _groundDetector;
    [SerializeField] private PlayerAnimator _playerAnimator;
    private Rigidbody2D _rigidbody;
    private bool _isFacingRight = true;

    public float _horizontalMove { get; private set; } = 0;
    public bool _isJump { get; private set; }

    private void Awake()
    {
        _rigidbody = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _horizontalMove = Input.GetAxisRaw(HorizontalAxis);

        if (_horizontalMove < 0 && _isFacingRight)
        {
            Flip();
        }
        else if(_horizontalMove > 0 && !_isFacingRight)
        {
            Flip();
        }

        if (_horizontalMove != 0)
        {
            _playerAnimator.RunAnimation(true);
        }
        else
        {
            _playerAnimator.RunAnimation(false);
        }

        if (Input.GetButtonDown(Jump) && _groundDetector.GetGrounded())
        {
            _isJump = true;
        }
    }

    public bool GetIsJump()
    {
        bool value = _isJump;
        _isJump = false;
        return value;
    }

    private void FixedUpdate()
    {
        _playerAnimator.JumpAnimation(_groundDetector.GetGrounded(), _rigidbody.velocity.y);
    }

    private void Flip()
    {
        _isFacingRight = !_isFacingRight;

        transform.Rotate(0, 180f, 0);
    }
}
