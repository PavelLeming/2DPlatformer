using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DamageTaker : MonoBehaviour
{
    public event UnityAction<int> DamageTaken;

    public void TakeDamage(int damage)
    {
        DamageTaken?.Invoke(damage);
    }
}
