using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Patroller : MonoBehaviour
{
    [SerializeField] private Flipper _flipper;
    private float _offset = 0.1f;

    public float XAPoint {get; private set;} = 0.5f;
    public float XBPoint {get; private set;} = 5.5f;
    public bool IsGoToB { get; private set; } = false;

    private void Update()
    {
        if (Mathf.Abs(transform.position.x - XAPoint) < _offset && IsGoToB != true)
        {
            IsGoToB = true;
            _flipper.Flip();
        }
        else if (Mathf.Abs(transform.position.x - XBPoint) < _offset && IsGoToB)
        {
            IsGoToB = false;
            _flipper.Flip();
        }
    }
}
