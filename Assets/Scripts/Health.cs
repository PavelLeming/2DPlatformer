using System;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxValue;
    [SerializeField] private float _value;

    public event UnityAction Died;
    public event UnityAction ValueChanged;

    public float MaxValue => _maxValue;
    public float Value => _value;

    public void TakeDamage(float damage)
    {
        if (damage >= 0)
        {
            _value -= damage;
            ValueChanged?.Invoke();

            if (_value <= 0)
            {
                Died?.Invoke();
            }
        }
    }

    public void RestoreValue(float valueRecover)
    {
        if (valueRecover >= 0)
        {
            _value = Math.Clamp(_value + valueRecover, 0, _maxValue);
            ValueChanged?.Invoke();
        }
    }
}
