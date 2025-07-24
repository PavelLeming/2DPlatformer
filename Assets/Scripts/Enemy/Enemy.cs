using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Patroller _patroller;
    [SerializeField] private EnemyCheckerArea _enemyCheckerArea;
    [SerializeField] private Flipper _flipper;
    private float _speed = 1.0f;

    private void Update()
    {
        if (!_enemyCheckerArea.IsEnemyEnter)
        {
            if (_patroller.IsGoToB)
            {
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(_patroller.XBPoint, transform.position.y), _speed * Time.deltaTime);
            }
            else
            {
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(_patroller.XAPoint, transform.position.y), _speed * Time.deltaTime);
            }
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(_enemyCheckerArea.Player.transform.position.x, transform.position.y), _speed * Time.deltaTime);

            _flipper.Flip(_enemyCheckerArea.Player.transform.position.x > transform.position.x);
        }
    }
}
