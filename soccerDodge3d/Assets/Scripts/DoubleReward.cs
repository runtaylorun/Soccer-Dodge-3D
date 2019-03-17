using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class DoubleReward : MonoBehaviour
{

    public GameObject deathAdUI;
    public Text coinText;
    private int playerCoins;

    public void doubleRewardButton()
    {
        playerCoins = PlayerPrefs.GetInt("Coins", 0);
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
                playerCoins += ballScript.coinsAddedThisRound;
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
    /*
    IEnumerator addCoins()
    {
        var subtractCoins = PlayerPrefs.GetInt("Coins");
        subtractCoins -= ballScript.coinsAddedThisRound;
        for (int i = 0; i <= ballScript.coinsAddedThisRound; i++)
        {
            yield return new WaitForSeconds(0.1f);
            coinText.text = subtractCoins.ToString();
            subtractCoins++;
        }
    }

*/
}
