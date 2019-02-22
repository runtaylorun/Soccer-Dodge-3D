using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class DoubleReward : MonoBehaviour
{

    public GameObject deathAdUI;

    public void doubleRewardButton()
    {
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
                Debug.Log("Successfully shown");
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
