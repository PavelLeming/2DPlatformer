using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField] private LayerMask _enemyLayer;
    [SerializeField] private int _damage;
    private float _detectionRadius = 2f;

    public void Attack()
    {
        Collider2D enemy = Physics2D.OverlapCircle(transform.position, _detectionRadius, _enemyLayer);

        if (enemy != null)
        {
            if (enemy.TryGetComponent<Health>(out Health _health))
            {
                _health.TakeDamage(_damage);
            }
        }
    }
}
