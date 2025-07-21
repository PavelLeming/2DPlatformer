using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    private int _coinCount = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Coin>(out _))
        {
            Debug.Log("У вас всего " + ++_coinCount + " монет.");
            Destroy(collision.gameObject);
        }
    }
}
