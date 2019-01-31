using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsScript : MonoBehaviour
{
    public GameObject settingsMenu;
    public Text scoreText;
    public Text coinsText;
    public Image coinImage;
    public AudioSource buttonClick;

    public void showSettings()
    {
        buttonClick.Play();
        settingsMenu.SetActive(true);
        scoreText.enabled = false;
        coinsText.enabled = false;
        coinImage.enabled = false;
    }

    public void leaveSettings()
    {
        buttonClick.Play();
        settingsMenu.SetActive(false);
        scoreText.enabled = true;
        coinsText.enabled = true;
        coinImage.enabled = true;
    }

}
