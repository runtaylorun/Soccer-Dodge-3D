using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayBtn : MonoBehaviour {

    public Animator fadeAnim;
    public AudioSource clickbutton;
    public void clickPlay()
    {
        clickbutton.Play();
        fadeAnim.SetTrigger("FadeOut");
    }

}
