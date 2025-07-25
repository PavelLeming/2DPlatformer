using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour, IDamageable
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private int _health;
    public event UnityAction Death;

    public int MaxHealth => _maxHealth;
    public int HealthPoints => _health;

    public void TakeDamage(int damage)
    {
        _health -= damage;

        if (_health < 0)
        {
            Death?.Invoke();
        }
    }

    public void HealthRecover(int healthRecover)
    {
        if (_health + healthRecover > _maxHealth)
        {
            _health = _maxHealth;
        }
        else
        {
            _health += healthRecover;
        }
    }
}
