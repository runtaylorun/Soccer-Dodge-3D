using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelection : MonoBehaviour
{
    public GameObject skinUI;
    public Button characterSelectionButton;
    public Button backButton;

    public static bool selectingChar;
    void Start()
    {
        selectingChar = false;
    }

    void Update()
    {
    }

    public void openSelectionMenu()
    {
        selectingChar = true;
        skinUI.SetActive(true);
        characterSelectionButton.enabled = false;
    }

    public void closeSelectionMenu()
    {
        selectingChar = false;
        skinUI.SetActive(false);
        characterSelectionButton.enabled = true;
    }
}
