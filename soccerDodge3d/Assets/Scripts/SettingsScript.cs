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
    public Sprite regularMute;
    public Sprite muteButtonHighlighted;
    public Sprite regularDisabledCrowdGraphic;
    public Sprite highlightedCrowdDisabledGraphic;
    public AudioSource buttonClick;
    public Button muteBtn;
    public Button infoBtn;
    public Button crowdButton;

    private bool isMuted;
    private bool crowdDisabled;

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

    public void muteBtnPressed()
    {
        if(!isMuted)
        {
            muteBtn.image.sprite = muteButtonHighlighted;
            isMuted = true;
        }
        else
        {
            muteBtn.image.sprite = regularMute;
            isMuted = false;
        }
    }

    public void crowdDisabledPressed()
    {
        if(!crowdDisabled)
        {
            crowdButton.image.sprite = highlightedCrowdDisabledGraphic;
            crowdDisabled = true;
        }
        else
        {
            crowdButton.image.sprite = regularDisabledCrowdGraphic;
            crowdDisabled = false;
        }
    }
}
