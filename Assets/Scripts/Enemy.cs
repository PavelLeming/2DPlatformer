using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float _xAPoint = 0.5f;
    private float _xBPoint = 5.5f;
    private float _offset = 0.01f;
    private float _speed = 5.0f;
    private bool _isGoToB = false;


    void Update()
    {
        if (_isGoToB)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(_xBPoint, transform.position.y), _speed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(_xAPoint, transform.position.y), _speed * Time.deltaTime);
        }

        if (Mathf.Abs(transform.position.x - _xAPoint) < _offset && _isGoToB != true)
        {
            _isGoToB = true;
            Flip();
        }
        else if (Mathf.Abs(transform.position.x - _xBPoint) < _offset && _isGoToB)
        {
            _isGoToB = false;
            Flip();
        }
    }

    private void Flip()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
