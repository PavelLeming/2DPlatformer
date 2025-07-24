using UnityEngine;
using UnityEngine.Events;

public class Collector : MonoBehaviour
{
    private int _coinCount = 0;
    public event UnityAction HealthRecover;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Coin>(out _))
        {
            Debug.Log("У вас всего " + ++_coinCount + " монет.");
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.TryGetComponent<FirstAidKit>(out _))
        {
            HealthRecover?.Invoke();
            Destroy(collision.gameObject);
        }
    }
}
