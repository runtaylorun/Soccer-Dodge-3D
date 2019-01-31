using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DetectButtonDown : MonoBehaviour
{
    private GameObject player;

    private void Start()
    {
        player = GameObject.Find("Player");
    }

    public void heldDown()
    {
        player.GetComponent<controller>().enabled = false;
    }

    public void letUp()
    {
        player.GetComponent<controller>().enabled = true;
    }
}
