using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinButton : MonoBehaviour
{
    private bool canPressButton = true;

    public void OnButtonPress()
    {
        if (canPressButton)
        {
            GiveCoins(10);
            canPressButton = false;
            Invoke("EnableButton", 10f);
        }
    }

    private void EnableButton()
    {
        canPressButton = true;
    }

    private void GiveCoins(int amount)
    {
        CoinText.Coin += amount;
        PlayerPrefs.SetInt("Coins", CoinText.Coin);
    }
}