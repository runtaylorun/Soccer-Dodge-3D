using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DetectButtonDown : MonoBehaviour
{
    public void heldDown()
    {
        CharacterSelection.selectingChar = true;
        ballScript.isPlaying = false;
    }

    public void letUp()
    {
        ballScript.isPlaying = true;
        CharacterSelection.selectingChar = false;
    }
}
