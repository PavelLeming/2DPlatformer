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
    [SerializeField] private Health _health;
    [SerializeField] private Attacker _attacker;
    [SerializeField] private View _view;

    private Rigidbody2D _rigidbody;

    private void OnEnable()
    {
        _collector.HealthRecover += RestoreHealth;
        _health.Died += Die;
    }

    private void OnDisable()
    {
        _collector.HealthRecover -= RestoreHealth;
        _health.Died -= Die;
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

        if (_inputReader.GetIsAttack())
        {
            _attacker.Attack();
        }

        _playerAnimator.StartJumpAnimation(_groundDetector.IsGround(), _rigidbody.velocity.y);
    }

    private void Update()
    {
        _playerAnimator.StartRunAnimation(_inputReader.HorizontalMove != 0);

        _flipper.Flip(_inputReader.HorizontalMove < 0);
    }

    private void RestoreHealth(int healthRecover)
    {
        _health.RestoreValue(healthRecover);
    }

    private void Die()
    {
        _view.Death();
    }
}
