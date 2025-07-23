using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private GroundDetector _groundDetector;
    [SerializeField] private Flipper _flipper;
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void JumpAnimation(bool isGrounded, float yVelocity)
    {
        _animator.SetBool(PlayerAnimatorData.Params.IsGrounded, isGrounded);
        _animator.SetFloat(PlayerAnimatorData.Params.YSpeed, yVelocity);
    }

    public void RunAnimation(bool isRun)
    {
        _animator.SetBool(PlayerAnimatorData.Params.IsRun, isRun);
    }

    private void FixedUpdate()
    {
        JumpAnimation(_groundDetector.IsGround(), _rigidbody.velocity.y);
    }

    private void Update()
    {
        RunAnimation(_inputReader.HorizontalMove != 0);

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
