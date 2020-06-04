using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Wallet wallet))
        {
            wallet.AddCoin();
            gameObject.SetActive(false);
        }
    }
}
