using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Patroller _patroller;
    private float _speed = 5.0f;

    private void Update()
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
}
