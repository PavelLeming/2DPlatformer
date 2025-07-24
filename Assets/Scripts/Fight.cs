using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Fight : MonoBehaviour
{
    [SerializeField] private LayerMask _enemyLayer;
    [SerializeField] private int _damage;
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
                enemy.GetComponent<Health>().TakeDamage(_damage);
            }

            yield return wait;
        }
    }
}
