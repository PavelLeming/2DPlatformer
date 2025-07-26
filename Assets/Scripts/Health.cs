using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour, IDamageable
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private int _healthPoints;

    public event UnityAction Death;

    public int MaxHealth => _maxHealth;
    public int HealthPoints => _healthPoints;

    public void TakeDamage(int damage)
    {
        if (damage >= 0)
        {
            _healthPoints -= damage;

            if (_healthPoints < 0)
            {
                Death?.Invoke();
            }
        }
    }

    public void RestoreHealth(int healthRecover)
    {
        if ( healthRecover >= 0)
        {
            if (_healthPoints + healthRecover > _maxHealth)
            {
                _healthPoints = _maxHealth;
            }
            else
            {
                _healthPoints += healthRecover;
            }
        }
    }
}
