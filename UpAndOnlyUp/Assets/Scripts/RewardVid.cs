using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class RewardVid : MonoBehaviour
{
    [SerializeField] private Button RewardButton;
    private int coins;
    
    private void OnEnable() => YandexGame.RewardVideoEvent += Rewarded;
    private void OnDisable() => YandexGame.RewardVideoEvent -= Rewarded;

    private void Awake()
    {
        RewardButton.onClick.AddListener(delegate { ExampleOpenRewardAd(1); });
    }
    private void Update()
    {
        coins = PlayerPrefs.GetInt("Coins");
    }
    void Rewarded(int id)
    {
        if (id == 1)
        {
            Debug.LogWarning("Получено: " + coins);
        }
    }
    void ExampleOpenRewardAd(int id)
    {
        coins += 10;
        PlayerPrefs.SetInt("Coins", coins);
        YandexGame.RewVideoShow(id);
        
    }
}
