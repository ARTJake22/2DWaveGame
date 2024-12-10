using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Coin : MonoBehaviour
{
     public delegate void CoinCollected();
    public event CoinCollected OnCollected;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            OnCollected?.Invoke();
            Destroy(gameObject);
        }
    }

}
