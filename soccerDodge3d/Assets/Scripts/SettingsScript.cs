using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsScript : MonoBehaviour
{
    public Sprite regularMute;
    public Sprite muteButtonHighlighted;
    public Sprite regularDisabledCrowdGraphic;
    public Sprite highlightedCrowdDisabledGraphic;

    public Button muteBtn;
    public Button crowdButton;
    public Button tutorialButton;

    public GameObject settingsMenu;
    public GameObject tutorial;
    public GameObject crowd;
    public GameObject permanentUI;

    public AudioSource buttonPressed;

    public void Start()
    {
        CheckIfCrowdShouldBeDisabled();
        CheckIfTutoiralShouldBeDisabled();
        CheckIfGameShouldBeMuted();
    }
    public void showSettings()
    {
        buttonPressed.Play();
        settingsMenu.SetActive(true);
        permanentUI.SetActive(false);
    }

    public void leaveSettings()
    {
        buttonPressed.Play();
        settingsMenu.SetActive(false);
        permanentUI.SetActive(true);
    }

    public void muteBtnPressed()
    {
        buttonPressed.Play();
        if(PlayerPrefs.GetInt("isMuted", 0) == 0)
        {
            muteBtn.image.sprite = muteButtonHighlighted;
            PlayerPrefs.SetInt("isMuted", 1);
            PlayerPrefs.Save();
        }
        else
        {
            muteBtn.image.sprite = regularMute;
            PlayerPrefs.SetInt("isMuted", 0);
            PlayerPrefs.Save();
        }
    }

    public void crowdDisabledPressed()
    {
        buttonPressed.Play();
        if(PlayerPrefs.GetInt("crowdDisabled", 0) == 0)
        {
            crowdButton.image.sprite = highlightedCrowdDisabledGraphic;
            PlayerPrefs.SetInt("crowdDisabled", 1);
            PlayerPrefs.Save();
            crowd.SetActive(false);
        }
        else
        {
            crowdButton.image.sprite = regularDisabledCrowdGraphic;
            PlayerPrefs.SetInt("crowdDisabled", 0);
            PlayerPrefs.Save();
            crowd.SetActive(true);
        }
    }

    public void DisableTutorialButton()
    {
        buttonPressed.Play();
        if(PlayerPrefs.GetInt("tutorialDisabled", 0) == 0)
        {
            tutorialButton.image.sprite = highlightedCrowdDisabledGraphic;
            PlayerPrefs.SetInt("tutorialDisabled", 1);
            PlayerPrefs.Save();
            tutorial.SetActive(false);
        }
        else
        {
            tutorialButton.image.sprite = regularDisabledCrowdGraphic;
            PlayerPrefs.SetInt("tutorialDisabled", 0);
            PlayerPrefs.Save();
            tutorial.SetActive(true);
        }
    }

    private void CheckIfCrowdShouldBeDisabled()
    {
        if (PlayerPrefs.GetInt("crowdDisabled", 0) == 0)
        {
            crowd.SetActive(true);
            crowdButton.image.sprite = regularDisabledCrowdGraphic;
        }
        else
        {
            crowd.SetActive(false);
            crowdButton.image.sprite = highlightedCrowdDisabledGraphic;
        }
    }

    private void CheckIfGameShouldBeMuted()
    {
        if (PlayerPrefs.GetInt("isMuted", 0) == 0)
        {
            muteBtn.image.sprite = regularMute;
        }
        else
        {
            muteBtn.image.sprite = muteButtonHighlighted;
        }
    }

    private void CheckIfTutoiralShouldBeDisabled()
    {
        if(PlayerPrefs.GetInt("tutorialDisabled", 0) == 0)
        {
            tutorialButton.image.sprite = regularDisabledCrowdGraphic;
            tutorial.SetActive(true);
        }
        else
        {
            tutorialButton.image.sprite = highlightedCrowdDisabledGraphic;
            tutorial.SetActive(false);
        }
    }

}
