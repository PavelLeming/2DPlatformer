using UnityEngine;
using UnityEngine.Events;

public class Collector : MonoBehaviour
{
    public event UnityAction<int> HealthRecover;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<CollectableObgect>(out CollectableObgect collectableObgect))
        {
            if (collectableObgect is Coin)
            {
                Destroy(collision.gameObject);
            }
            else if (collectableObgect is FirstAidKit)
            {
                FirstAidKit firstAidKit = collectableObgect as FirstAidKit;
                HealthRecover?.Invoke(firstAidKit.HealthRecover);
                Destroy(collision.gameObject);
            }
        }
    }
}
