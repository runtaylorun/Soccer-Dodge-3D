using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelection : MonoBehaviour
{
    public Button characterSelectionButton;
    public Button leaderboardButton;
    public Canvas mainCanvas;
    public Camera mainCam;
    public Animator confirmation;
    public Text coinsTextMain;
    public AudioSource buttonPress;
    public GameObject selectionCameraHolder;

    public void openSelectionMenu()
    {
        buttonPress.Play();
        DisableTemporaryStartMenu();
        mainCam.enabled = false;
        mainCanvas.enabled = false;
        selectionCameraHolder.SetActive(true);
    }

    public void closeSelectionMenu()
    {
        buttonPress.Play();
        selectionCameraHolder.SetActive(false);
        mainCam.enabled = true;
        mainCanvas.enabled = true;
        EnableTemporaryStartMenu();
        confirmation.SetBool("Confirmation", false);
        coinsTextMain.text = PlayerPrefs.GetInt("Coins").ToString();
    }

    private void DisableTemporaryStartMenu()
    {
        leaderboardButton.gameObject.SetActive(false);
        characterSelectionButton.gameObject.SetActive(false);
    }

    private void EnableTemporaryStartMenu()
    {
        leaderboardButton.gameObject.SetActive(true);
        characterSelectionButton.gameObject.SetActive(true);
    }
}
