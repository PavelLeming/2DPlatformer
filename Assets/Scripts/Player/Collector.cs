using UnityEngine;
using UnityEngine.Events;

public class Collector : MonoBehaviour
{
    private int _coinCount = 0;
    public event UnityAction<int> HealthRecover;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Coin>(out Coin coin))
        {
            Debug.Log("� ��� ����� " + ++_coinCount + " �����.");
            coin.Collect();
        }
        else if (collision.gameObject.TryGetComponent<FirstAidKit>(out FirstAidKit firstAidKit))
        {
            HealthRecover?.Invoke(firstAidKit.HealthRecover);
            firstAidKit.Collect();
        }
    }
}
