using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Patroller : MonoBehaviour
{
    [SerializeField] Flipper _flipper;
    private float _offset = 0.01f;

    public float _xAPoint {get; private set;} = 0.5f;
    public float _xBPoint {get; private set;} = 5.5f;
    public bool _isGoToB { get; private set; } = false;

    void Update()
    {
        if (Mathf.Abs(transform.position.x - _xAPoint) < _offset && _isGoToB != true)
        {
            _isGoToB = true;
            _flipper.Flip();
        }
        else if (Mathf.Abs(transform.position.x - _xBPoint) < _offset && _isGoToB)
        {
            _isGoToB = false;
            _flipper.Flip();
        }
    }
}
