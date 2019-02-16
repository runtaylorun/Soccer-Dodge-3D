using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private float timeLeft = 2.0f;
    public Animator animator;
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }


    void Update()
    {
        if(Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);
            if (touch.position.x > Screen.width / 2 && touch.phase != TouchPhase.Ended)
            {
                timeLeft -= Time.deltaTime;
                Debug.Log(timeLeft);
                if(timeLeft <= 0)
                {
                    animator.SetBool("isCrouching", false);
                }
            }
            else
            {
                resetTimer();
            }
        }
    }

    private void resetTimer()
    {
        timeLeft = 2.0f;
    }
}
