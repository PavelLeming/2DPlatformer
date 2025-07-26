using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Patroller : MonoBehaviour
{
    [SerializeField] private Flipper _flipper;
    [SerializeField] private List<Transform> _points = new List<Transform>();
    private float _offset = 0.1f;
    private int _nextPointNumber = 0;
    public Transform NextPoint => _points[_nextPointNumber];

    public bool IsGoRight { get; private set; } = false;

    private void Update()
    {
        if (Mathf.Abs(transform.position.x - NextPoint.position.x) < _offset)
        {
            if (IsGoRight)
            {
                if (++_nextPointNumber == _points.Count)
                {
                    IsGoRight = !IsGoRight;
                    _flipper.Flip(false);
                    _nextPointNumber = _points.Count - 2;
                }
            }
            else
            {
                if (--_nextPointNumber == -1)
                {
                    IsGoRight = !IsGoRight;
                    _flipper.Flip(true);
                    _nextPointNumber = 1;
                }
            }
        }
    }
}
