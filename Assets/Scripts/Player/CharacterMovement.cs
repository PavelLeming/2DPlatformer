using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private GroundDetector _groundDetector;
    [SerializeField] private Mover _mover;
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private Flipper _flipper;
    [SerializeField] private PlayerAnimator _playerAnimator;
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _mover.Move(_inputReader.HorizontalMove);

        if (_inputReader.GetIsJump() && _groundDetector.IsGround())
        {
            _mover.Jump();
        }

        _playerAnimator.JumpAnimation(_groundDetector.IsGround(), _rigidbody.velocity.y);
    }

    private void Update()
    {
        _playerAnimator.RunAnimation(_inputReader.HorizontalMove != 0);

        if (_inputReader.HorizontalMove < 0 && _flipper.IsFacingRight)
        {
            _flipper.Flip();
        }
        else if (_inputReader.HorizontalMove > 0 && !_flipper.IsFacingRight)
        {
            _flipper.Flip();
        }
    }
}
