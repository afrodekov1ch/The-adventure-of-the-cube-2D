using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GiveCoin();
        }
    }

    public void GiveCoin()
    {
        CoinText.Coin += 1;
        PlayerPrefs.SetInt("Coins", CoinText.Coin);
        Destroy(gameObject);
    }
}