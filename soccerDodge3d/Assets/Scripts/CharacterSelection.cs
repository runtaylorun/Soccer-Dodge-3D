using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelection : MonoBehaviour
{
    public GameObject skinUI;
    public GameObject tempUIStart;
    public Button backButton;

    public void openSelectionMenu()
    {
        skinUI.SetActive(true);
        tempUIStart.SetActive(false);
    }

    public void closeSelectionMenu()
    {
        skinUI.SetActive(false);
        tempUIStart.SetActive(true);
    }
}
