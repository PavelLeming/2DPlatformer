using UnityEngine;

public class FirstAidKit : CollectableObgect
{
    [SerializeField] private int _healthRecover;

    public int HealthRecover => _healthRecover;
}
