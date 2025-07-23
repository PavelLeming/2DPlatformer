using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private PointForGroundCheck _groundChecker;
    private float _groundCheckerRadius = 0.2f;

    public bool IsGround()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(_groundChecker.transform.position, _groundCheckerRadius, _groundMask);
        return colliders.Length > 0;
    }
}
