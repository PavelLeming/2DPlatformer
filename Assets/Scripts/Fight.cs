using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Fight : MonoBehaviour
{
    [SerializeField] private LayerMask _enemyLayer;
    [SerializeField] private int _damage;
    public event UnityAction CollisionWithEnemy;
    private float _detectionRadius = 2f;

    private void Start()
    {
        StartCoroutine(IsEnemyTouched());
    }

    private IEnumerator IsEnemyTouched()
    {
        var wait = new WaitForSeconds(1f);

        while (enabled)
        {
            Collider2D enemy = Physics2D.OverlapCircle(transform.position, _detectionRadius, _enemyLayer);

            if (enemy != null)
            {
                enemy.GetComponent<DamageTaker>().TakeDamage(_damage);
            }

            yield return wait;
        }
    }
}
