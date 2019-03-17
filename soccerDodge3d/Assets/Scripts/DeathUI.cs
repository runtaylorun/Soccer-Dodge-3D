using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathUI : MonoBehaviour
{
    public AudioSource slideIn;

    public void PlaySound()
    {
        slideIn.Play();
    }
}
