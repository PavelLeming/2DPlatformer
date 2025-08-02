using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Patroller _patroller;
    [SerializeField] private EnemyCheckerArea _enemyCheckerArea;
    [SerializeField] private Flipper _flipper;
    [SerializeField] private Health _health;
    [SerializeField] private View _view;

    private float _target;
    private float _speed = 1.0f;

    private void OnEnable()
    {
        _health.Died += Die;
    }

    private void OnDisable()
    {
        _health.Died -= Die;
    }

    private void Update()
    {
        if (_enemyCheckerArea.IsEnemyEnter == false)
        {
            _target = _patroller.NextPoint.position.x;
        }
        else
        {
            _target = _enemyCheckerArea.Player.transform.position.x;

            _flipper.Flip(_enemyCheckerArea.Player.transform.position.x > transform.position.x);
        }

        transform.position = Vector2.MoveTowards(transform.position, new Vector2(_target, transform.position.y), _speed * Time.deltaTime); ;
    }

    private void Die()
    {
        _view.Death();
    }
}
