using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private PointForGroundCheck _groundChecker;

    private float _groundCheckerRadius = 0.2f;
    private Collider2D[] _colliders = new Collider2D[1];

    public bool IsGround()
    {
        return Physics2D.OverlapCircleNonAlloc(_groundChecker.transform.position, _groundCheckerRadius, _colliders, _groundMask) > 0;
    }
}
