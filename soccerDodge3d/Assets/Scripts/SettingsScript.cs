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
    public AudioSource birdNoise;
    public AudioSource crowdNoise;
    public AudioSource buttonPressed;
    public Button muteBtn;
    public Button crowdButton;
    public Button tutorialButton;
    public Button shadowButton;
    public Button backButton;
    public Text muteText;
    public Text crowdText;
    public Text tutorialText;
    public Text shadowText;
    public Text scoreText;
    public Text coinText;
    public Image settingsBackgroundImage;
    public Image coinImage;
    public GameObject deathAdUI;
    public GameObject tutorial;
    public GameObject crowd;

    public void Start()
    {
        CheckIfCrowdShouldBeDisabled();
        CheckIfTutoiralShouldBeDisabled();
        CheckIfGameShouldBeMuted();
        CheckIfShadowsShouldBeDisabled();
    }
    public void showSettings()
    {
        buttonPressed.Play();
        DisableMainUI();
        EnableSettingsUI();
    }

    public void leaveSettings()
    {
        buttonPressed.Play();
        DisableSettingsUI();
        EnableMainUI();
    }

    public void muteBtnPressed()
    {
        buttonPressed.Play();
        if(PlayerPrefs.GetInt("isMuted", 0) == 0)
        {
            muteBtn.image.sprite = muteButtonHighlighted;
            PlayerPrefs.SetInt("isMuted", 1);
            PlayerPrefs.Save();
            AudioListener.pause = true;
        }
        else
        {
            muteBtn.image.sprite = regularMute;
            PlayerPrefs.SetInt("isMuted", 0);
            PlayerPrefs.Save();
            AudioListener.pause = false;
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
            DisableCrowdNoises();
        }
        else
        {
            crowdButton.image.sprite = regularDisabledCrowdGraphic;
            PlayerPrefs.SetInt("crowdDisabled", 0);
            PlayerPrefs.Save();
            crowd.SetActive(true);
            EnableCrowdNoises();
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

    public void DisableShadowsButton()
    {
        buttonPressed.Play();
        if(PlayerPrefs.GetInt("shadowsDisabled",0) == 0)
        {
            shadowButton.image.sprite = highlightedCrowdDisabledGraphic;
            PlayerPrefs.SetInt("shadowsDisabled", 1);
            PlayerPrefs.Save();
            QualitySettings.shadows = ShadowQuality.Disable;
        }
        else
        {
            shadowButton.image.sprite = regularDisabledCrowdGraphic;
            PlayerPrefs.SetInt("shadowsDisabled", 0);
            PlayerPrefs.Save();
            QualitySettings.shadows = ShadowQuality.All;
        }
    }

    private void CheckIfShadowsShouldBeDisabled()
    {
        if(PlayerPrefs.GetInt("shadowsDisabled", 0) == 0)
        {
            QualitySettings.shadows = ShadowQuality.All;
            shadowButton.image.sprite = regularDisabledCrowdGraphic;
        }
        else
        {
            QualitySettings.shadows = ShadowQuality.Disable;
            shadowButton.image.sprite = highlightedCrowdDisabledGraphic;
        }
    }

    private void CheckIfCrowdShouldBeDisabled()
    {
        if (PlayerPrefs.GetInt("crowdDisabled", 0) == 0)
        {
            crowd.SetActive(true);
            EnableCrowdNoises();
            crowdButton.image.sprite = regularDisabledCrowdGraphic;
        }
        else
        {
            crowd.SetActive(false);
            DisableCrowdNoises();
            crowdButton.image.sprite = highlightedCrowdDisabledGraphic;
        }
    }

    private void EnableCrowdNoises()
    {
        birdNoise.enabled = false;
        crowdNoise.enabled = true;
    }

    private void DisableCrowdNoises()
    {
        birdNoise.enabled = true;
        crowdNoise.enabled = false;
    }

    private void CheckIfGameShouldBeMuted()
    {
        if (PlayerPrefs.GetInt("isMuted", 0) == 0)
        {
            muteBtn.image.sprite = regularMute;
            AudioListener.pause = false;
        }
        else
        {
            muteBtn.image.sprite = muteButtonHighlighted;
            AudioListener.pause = true;
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

    private void EnableMainUI()
    {
        coinText.gameObject.SetActive(true);
        scoreText.gameObject.SetActive(true);
        coinImage.gameObject.SetActive(true);
    }

    private void DisableMainUI()
    {
        coinText.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(false);
        coinImage.gameObject.SetActive(false);
    }

    private void EnableSettingsUI()
    {
        settingsBackgroundImage.gameObject.SetActive(true);
        muteBtn.gameObject.SetActive(true);
        shadowButton.gameObject.SetActive(true);
        tutorialButton.gameObject.SetActive(true);
        crowdButton.gameObject.SetActive(true);
        muteText.gameObject.SetActive(true);
        shadowText.gameObject.SetActive(true);
        tutorialText.gameObject.SetActive(true);
        crowdText.gameObject.SetActive(true);
        backButton.gameObject.SetActive(true);
    }

    private void DisableSettingsUI()
    {
        settingsBackgroundImage.gameObject.SetActive(false);
        muteBtn.gameObject.SetActive(false);
        shadowButton.gameObject.SetActive(false);
        tutorialButton.gameObject.SetActive(false);
        crowdButton.gameObject.SetActive(false);
        muteText.gameObject.SetActive(false);
        shadowText.gameObject.SetActive(false);
        tutorialText.gameObject.SetActive(false);
        crowdText.gameObject.SetActive(false);
        backButton.gameObject.SetActive(false);
    }
}
