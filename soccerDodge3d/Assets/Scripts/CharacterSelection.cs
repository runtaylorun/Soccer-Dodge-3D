using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelection : MonoBehaviour
{
    public GameObject skinUI;
    public GameObject tempUIStart;
    public Canvas mainCanvas;
    public Camera mainCam;
    public Camera selectionCamera;
    public Button backButton;

    public void openSelectionMenu()
    {
        skinUI.SetActive(true);
        mainCam.enabled = false;
        mainCanvas.enabled = false;
        selectionCamera.enabled = true;
        tempUIStart.SetActive(false);
    }

    public void closeSelectionMenu()
    {
        skinUI.SetActive(false);
        mainCam.enabled = true;
        mainCanvas.enabled = true;
        selectionCamera.enabled = false;
        tempUIStart.SetActive(true);
    }
}
