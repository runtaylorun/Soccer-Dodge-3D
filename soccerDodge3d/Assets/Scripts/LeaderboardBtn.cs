using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

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

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LeaderboardButton()
    {
#if UNITY_IOS
        Social.ShowLeaderboardUI();
#endif
    }
}
