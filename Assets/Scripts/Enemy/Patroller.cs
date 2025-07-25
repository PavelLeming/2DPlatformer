using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Patroller : MonoBehaviour
{
    [SerializeField] private Flipper _flipper;
    private float _offset = 0.1f;
    private List<float> _points = new List<float>() { 0.5f, 5.5f };
    private int _nextPointNumber = 0;
    public float NextPoint => _points[_nextPointNumber];

    public bool IsGoToB { get; private set; } = false;

    private void Update()
    {
        if (Mathf.Abs(transform.position.x - NextPoint) < _offset)
        {
            if (IsGoToB)
            {
                if (++_nextPointNumber == _points.Count)
                {
                    IsGoToB = !IsGoToB;
                    _flipper.Flip(false);
                    _nextPointNumber = _points.Count - 2;
                }
            }
            else
            {
                if (--_nextPointNumber == -1)
                {
                    IsGoToB = !IsGoToB;
                    _flipper.Flip(true);
                    _nextPointNumber = 1;
                }
            }
        }
    }
}
