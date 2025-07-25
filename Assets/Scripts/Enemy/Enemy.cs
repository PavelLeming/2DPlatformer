using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Patroller _patroller;
    [SerializeField] private EnemyCheckerArea _enemyCheckerArea;
    [SerializeField] private Flipper _flipper;
    [SerializeField] private Health _health;
    private float _speed = 1.0f;

    private void OnEnable()
    {
        _health.Death += Die;
    }

    private void OnDisable()
    {
        _health.Death -= Die;
    }

    private void Update()
    {
        if (!_enemyCheckerArea.IsEnemyEnter)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(_patroller.NextPoint, transform.position.y), _speed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(_enemyCheckerArea.Player.transform.position.x, transform.position.y), _speed * Time.deltaTime);

            _flipper.Flip(_enemyCheckerArea.Player.transform.position.x > transform.position.x);
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
