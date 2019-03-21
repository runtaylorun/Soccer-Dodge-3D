using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FreeGift : MonoBehaviour
{
    private int giftAmount;
    private bool hasClicked;

    public static int rand;
    public Text coinText;
    public GameObject giftUI;

    void Start()
    {
        hasClicked = false;
        giftAmount = Random.Range(100, 200);
        rand = Random.Range(0,37);
        Debug.Log(rand);
        Debug.Log(giftAmount);
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
        PlayerPrefs.SetInt("Coins", playerCoins + giftAmount);
        for (int i = 0; i <= giftAmount; i++)
        {
            yield return new WaitForSeconds(0.003f);
            coinText.text = playerCoins.ToString();
            playerCoins++;
        }
        giftUI.SetActive(false);
    }
}
