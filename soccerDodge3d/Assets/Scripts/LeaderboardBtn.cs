using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.SocialPlatforms.GameCenter;

public class LeaderboardBtn : MonoBehaviour
{
    void Start()
    {
    #if UNITY_IOS
        Social.localUser.Authenticate(success =>
        {
            if (success)
            {
                Debug.Log("Authentication successful");
                string userInfo = "Username: " + Social.localUser.userName +
                    "\nUser ID: " + Social.localUser.id +
                    "\nIsUnderage: " + Social.localUser.underage;
                Debug.Log(userInfo);
            }
            else
            {
                Debug.Log("Authentication False");
            }
        });
    #endif
    }

    public void LeaderboardButton()
    {
#if UNITY_IOS
        GameCenterPlatform.ShowLeaderboardUI("Daily_Leaderboard", TimeScope.Today);
        GameCenterPlatform.ShowLeaderboardUI("Weekly_Leaderboard", TimeScope.Week);
        GameCenterPlatform.ShowLeaderboardUI("All_Time_Leaderboard", TimeScope.AllTime);
#endif
    }
}
