using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField] private LayerMask _enemyLayer;
    [SerializeField] private int _damage;

    private float _detectionRadius = 2f;
    private Collider2D[] _enemies = new Collider2D[1];

    public void Attack()
    {
        Physics2D.OverlapCircleNonAlloc(transform.position, _detectionRadius, _enemies, _enemyLayer);

        if (Physics2D.OverlapCircleNonAlloc(transform.position, _detectionRadius, _enemies, _enemyLayer) > 0)
        {
            if (_enemies[0].TryGetComponent<Health>(out Health _health))
            {
                _health.TakeDamage(_damage);
            }
        }
    }
}
