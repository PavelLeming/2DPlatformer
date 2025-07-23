using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] Patroller _patroller;
    private float _speed = 5.0f;

    private void Update()
    {
        if (_patroller._isGoToB)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(_patroller._xBPoint, transform.position.y), _speed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(_patroller._xAPoint, transform.position.y), _speed * Time.deltaTime);
        }
    }
}
