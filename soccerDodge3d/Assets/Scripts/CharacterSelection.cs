using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelection : MonoBehaviour
{
    public GameObject tempUIStart;
    public Canvas mainCanvas;
    public Camera mainCam;
    public Animator confirmation;
    public Text coinsTextMain;
    public AudioSource buttonPress;
    public GameObject selectionCameraHolder;

    public void openSelectionMenu()
    {
        buttonPress.Play();
        mainCam.enabled = false;
        mainCanvas.enabled = false;
        tempUIStart.SetActive(false);
        selectionCameraHolder.SetActive(true);
    }

    public void closeSelectionMenu()
    {
        buttonPress.Play();
        selectionCameraHolder.SetActive(false);
        mainCam.enabled = true;
        mainCanvas.enabled = true;
        tempUIStart.SetActive(true);
        confirmation.SetBool("Confirmation", false);
        coinsTextMain.text = PlayerPrefs.GetInt("Coins").ToString();
    }
}
