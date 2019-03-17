using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfirmationUI : MonoBehaviour
{
    public AudioSource slideIn;

    public void PlaySound()
    {
        slideIn.Play();
    }
}
