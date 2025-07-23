using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flipper : MonoBehaviour
{
    [SerializeField] private bool _isFacingRight;
    public bool IsFacingRight => _isFacingRight;

    public void Flip()
    {
        _isFacingRight = !_isFacingRight;

        transform.Rotate(0, 180f, 0);
    }
}
