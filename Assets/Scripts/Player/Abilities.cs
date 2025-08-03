using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abilities : MonoBehaviour
{
    private const float VampireTime = 6f;
    private const float VampireReload = 4f;

    [SerializeField] private LayerMask _enemyLayer;
    [SerializeField] Health _playerHealth;
    [SerializeField] VampireAura _playerAura;

    private float _detectionRadius = 2f;
    private Collider2D[] _enemies = new Collider2D[1];
    private float _damage = 10f;
    private float _restoredHealth = 10f;
    public event Action<float> TimerChanged;

    public bool IsVampireEnable { get; private set; } = true;

    public void StartVampiring()
    {
        IsVampireEnable = false;
        StartCoroutine(Vampiring());
    }

    private IEnumerator Vampiring()
    {
        float time = VampireTime;
        _playerAura.gameObject.SetActive(true);

        while (time > 0)
        {
            time -= Time.deltaTime;
            TimerChanged?.Invoke(time / VampireTime);

            if (Physics2D.OverlapCircleNonAlloc(transform.position, _detectionRadius, _enemies, _enemyLayer) > 0)
            {
                if (_enemies[0].TryGetComponent<Health>(out Health health))
                {
                    health.TakeDamage(_damage * Time.deltaTime);
                    _playerHealth.RestoreValue(_restoredHealth * Time.deltaTime);
                }
            }

            yield return null;
        }

        _playerAura.gameObject.SetActive(false);
        StartCoroutine(VampireReloader());
    }

    private IEnumerator VampireReloader()
    {
        float time = 0;

        while (time < VampireReload)
        {
            time += Time.deltaTime;
            TimerChanged?.Invoke(time / VampireReload);

            yield return null;
        }

        IsVampireEnable = true;
    }
}
