using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    private const string HorizontalAxis = "Horizontal";

    [SerializeField] private GroundDetector _groundDetector;
    [SerializeField] private Mover _mover;
    [SerializeField] private PlayerAnimator _playerAnimator;
    private Rigidbody2D _rigidbody;
    private float _horizontalMove = 0;
    private bool _isFacingRight = true;
    
    private bool _isJump;

    private void Start()
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

        if (Input.GetButtonDown("Jump") && _groundDetector.GetGrounded())
        {
            _isJump = true;
        }
    }

    private void FixedUpdate()
    {
        _mover.Move(_horizontalMove);
        if (_isJump) 
        {
            _mover.Jump();
            _isJump = false;
        }
        _playerAnimator.JumpAnimation(_groundDetector.GetGrounded(), _rigidbody.velocity.y);
    }

    private void Flip()
    {
        _isFacingRight = !_isFacingRight;

        transform.Rotate(0, 180f, 0);
    }
}
