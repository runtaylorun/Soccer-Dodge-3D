using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class AdGift : MonoBehaviour
{
    private int giftAmount;
    private int playerCoins;

    public GameObject deathAdUI;
    public Text coinText;

    public void doubleRewardButton()
    {
        playerCoins = PlayerPrefs.GetInt("Coins", 0);
        giftAmount = Random.Range(25, 40);
        showRewardAd();
    }

    private void showRewardAd()
    {
        if(Advertisement.IsReady("rewardedVideo"))
        {
            var options = new ShowOptions { resultCallback = HandleShowResult };
            Advertisement.Show("rewardedVideo", options);
        }
    }

    private void HandleShowResult(ShowResult result)
    {
        switch(result)
        {
            case ShowResult.Finished:
                playerCoins += giftAmount;
                PlayerPrefs.SetInt("Coins", playerCoins);
                coinText.text = playerCoins.ToString();
                deathAdUI.SetActive(false);
                break;
            case ShowResult.Skipped:
                Debug.Log("Skipped");
                break;
            case ShowResult.Failed:
                Debug.LogError("Fauled to be shown");
                break;
        }
    }
}
