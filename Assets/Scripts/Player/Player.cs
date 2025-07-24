using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private GroundDetector _groundDetector;
    [SerializeField] private Mover _mover;
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private Flipper _flipper;
    [SerializeField] private PlayerAnimator _playerAnimator;
    [SerializeField] private Collector _collector;
    [SerializeField] private DamageTaker _damageTaker;
    private Rigidbody2D _rigidbody;
    private int _healthPoints = 100;
    private int _maxHealth = 100;
    private int _healthRecover = 50;

    private void OnEnable()
    {
        _collector.HealthRecover += HealthRecover;
        _damageTaker.DamageTaken += TakeDamage;
    }

    private void OnDisable()
    {
        _collector.HealthRecover -= HealthRecover;
        _damageTaker.DamageTaken -= TakeDamage;
    }

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

        _flipper.Flip(_inputReader.HorizontalMove < 0);
    }

    private void HealthRecover()
    {
        if (_healthPoints + _healthRecover > _maxHealth)
        {
            _healthPoints = _maxHealth;
        }
        else
        {
            _healthPoints += _healthRecover;
        }

        Debug.Log("У вас осталось " + _healthPoints + " хп");
    }

    private void TakeDamage(int damage)
    {
        _healthPoints -= damage;

        Debug.Log("У вас остлось" + _healthPoints + "хп");

        if (_healthPoints < 0)
        {
            Destroy(gameObject);
        }
    }
}
