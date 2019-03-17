using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FreeGift : MonoBehaviour
{
    private int giftAmount;
    public Text coinText;
    public GameObject giftUI;
    public static int rand;
    private bool hasClicked;

    void Start()
    {
        hasClicked = false;
        giftAmount = Random.Range(100, 200);
        rand = Random.Range(0,40);
        Debug.Log(rand);
    }

    void Update()
    {
        
    }

    public void freeGift()
    {
        if(hasClicked == false)
        {
            StartCoroutine("addCoins");
            hasClicked = true;
        }
        else
        {

        }
    }

    IEnumerator addCoins()
    {
        var playerCoins = PlayerPrefs.GetInt("Coins");
        for (int i = 0; i <= giftAmount; i++)
        {
            yield return new WaitForSeconds(0.03f);
            coinText.text = playerCoins.ToString();
            playerCoins++;
        }
        giftUI.SetActive(false);
        PlayerPrefs.SetInt("Coins", playerCoins - 1);
    }
}
