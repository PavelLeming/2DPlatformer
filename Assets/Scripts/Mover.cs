using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    private const string HorizontalAxis = "Horizontal";

    [SerializeField] private GroundChecker _groundChecker;
    [SerializeField] private LayerMask _groundMask;
    [SerializeField] Animator _animator;
    private Rigidbody2D _rigidbody;
    private float _groundCheckerRadius = 0.2f;
    private float _speed = 5f;
    private int _jumpForce = 300;
    private float _horizontalMove = 0;
    private bool _isFacingRight = true;
    private bool _isGrounded;

    private void Start()
    {
        _rigidbody = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _horizontalMove = Input.GetAxisRaw(HorizontalAxis);

        _rigidbody.velocity = new Vector2(_horizontalMove * _speed, _rigidbody.velocity.y);

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
            _animator.SetBool("IsRun", true);
        }
        else
            _animator.SetBool("IsRun", false);

        if (Input.GetButtonDown("Jump") && _isGrounded)
        {
            _rigidbody.AddForce(new Vector2(0, _jumpForce));
        }
    }

    private void FixedUpdate()
    {
        CheckGround();
        _animator.SetBool("IsGrounded", _isGrounded);
        _animator.SetFloat("YSpeed", _rigidbody.velocity.y);
    }

    private void Flip()
    {
        _isFacingRight = !_isFacingRight;

        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    private void CheckGround()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(_groundChecker.transform.position, _groundCheckerRadius, _groundMask);
        if (colliders.Length > 0)
        {
            _isGrounded = true;
        }
        else
        {
            _isGrounded = false;
        }
    }
}
