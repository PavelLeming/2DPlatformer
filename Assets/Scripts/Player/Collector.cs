using UnityEngine;
using UnityEngine.Events;

public class Collector : MonoBehaviour
{
    public event UnityAction<int> HealthRecover;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Coin>(out Coin coin))
        {
            Destroy(collision.gameObject);
        }
        else if (collision.TryGetComponent<FirstAidKit>(out FirstAidKit firstAidKit))
        {
            HealthRecover?.Invoke(firstAidKit.HealthRecover);
            Destroy(collision.gameObject);
        }
    }
}
