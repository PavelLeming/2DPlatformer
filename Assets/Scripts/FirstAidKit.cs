using UnityEngine;

public class FirstAidKit : MonoBehaviour
{
    [SerializeField] private int _healthRecover;

    public int HealthRecover => _healthRecover;
}
