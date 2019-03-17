using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdUI : MonoBehaviour
{
    public AudioSource slideIn;

    public void PlaySound()
    {
        slideIn.Play();
    }
}
