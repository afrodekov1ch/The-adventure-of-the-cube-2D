using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CoinText : MonoBehaviour
{
    Text CoinTexts;
    public static int Coin;
    void Start()
    {
        CoinTexts = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        CoinTexts.text = Coin.ToString();
        Coin = PlayerPrefs.GetInt("Coins", Coin);
    }
}

