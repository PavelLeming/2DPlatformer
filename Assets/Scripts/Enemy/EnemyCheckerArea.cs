using System.Collections;
using UnityEngine;

public class EnemyCheckerArea : MonoBehaviour
{
    [SerializeField] private LayerMask _enemyLayer;
    private float _detectionRadius = 4f;

    public bool IsEnemyEnter { get; private set; }
    public Player Player { get; private set; }

    private void Start()
    {
        StartCoroutine(IsEnemyInArea());
    }

    private IEnumerator IsEnemyInArea()
    {
        var wait = new WaitForSeconds(0.5f);

        while (enabled)
        {
            Collider2D enemy = Physics2D.OverlapCircle(transform.position, _detectionRadius, _enemyLayer);

            if (enemy != null)
            {
                Player = enemy.GetComponent<Player>();
                IsEnemyEnter = true;
            }
            else
            {
                IsEnemyEnter = false;
            }

            yield return wait;
        }
    }
}
