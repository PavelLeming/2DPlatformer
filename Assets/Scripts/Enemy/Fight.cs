using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Fight : MonoBehaviour
{
    [SerializeField] private LayerMask _enemyLayer;
    [SerializeField] private Attacker _attacker;

    private void Start()
    {
        StartCoroutine(SearchEnemy());
    }

    private IEnumerator SearchEnemy()
    {
        var wait = new WaitForSeconds(1f);

        while (enabled)
        {
            _attacker.Attack();

            yield return wait;
        }
    }
}
