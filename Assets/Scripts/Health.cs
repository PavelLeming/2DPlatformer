using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class Health : MonoBehaviour, IDamageable
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private int _health;
    private int _healthRecover = 50;

    public int MaxHealth => _maxHealth;
    public int HealthPoints => _health;

    public void TakeDamage(int damage)
    {
        _health -= damage;
    }

    public void Die()
    {
        if (_health < 0)
        {
            Destroy(gameObject);
        }
    }

    public void HealthRecover()
    {
        if (_health + _healthRecover > _maxHealth)
        {
            _health = _maxHealth;
        }
        else
        {
            _health += _healthRecover;
        }
    }

    private void Update()
    {
        Die();
    }
}
