using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    int HealthPoints { get; }
    int MaxHealth { get; }

    void TakeDamage(int damage);

    void Die();
}
