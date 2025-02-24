﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeScript : MonoBehaviour {

    public Animator animator;

    public void FadeToLevel()
    {
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene("Game");
    }
}
