using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class controller : MonoBehaviour {

    public float jumpForce;
    public Animator animator;
    public GameObject air;
    public GameObject ground;
    public AudioSource jumpSound;
    public AudioSource landingSound;

    private bool canJump;
    private bool canCrouch;
    private Rigidbody playerRigidBody;
    private BoxCollider playerBoxCollider;

	void Start () 
    {
        disableCharacterAnimations();
        canJump = true;
        canCrouch = true;
        playerRigidBody = GetComponent<Rigidbody>();
        playerBoxCollider = GetComponent<BoxCollider>();
	}


    void Update()
    {
        /*
            if (UserTouchedScreen()) 
            {
                var touch = Input.GetTouch(0);
                if (UserTouchedLeftHalfOfScreen(touch))
                {
                    enableCharacterAnimation();
                    playerRigidBody.velocity = new Vector3(playerRigidBody.velocity.x, jumpForce, playerRigidBody.velocity.z);
                    jumpSound.Play();
                    ballScript.firstClick = true;
                }
                else if (UserTouchedRightHalfOfScreen(touch)) 
                {
                    enableCharacterAnimation();
                    animator.SetBool("isCrouching", true);
                    ballScript.firstClick = true;
                } 
                else 
                {
                animator.SetBool ("isCrouching", false);
                }
            }
*/


        if(Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            enableCharacterAnimation();
            playerRigidBody.velocity = new Vector3(playerRigidBody.velocity.x, jumpForce, playerRigidBody.velocity.z);
            jumpSound.Play();
            ballScript.firstClick = true;
        }
        else if(Input.GetKey(KeyCode.C) && canCrouch)
        {
            enableCharacterAnimation();
            animator.SetBool("isCrouching", true);
            ballScript.firstClick = true;
        }
        else
        {
            animator.SetBool("isCrouching", false);
        }


	}

     void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Air")
        {
            canJump = false;
            canCrouch = false;
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Ground")
        {
            animator.SetTrigger("hitGround");
            landingSound.Play();
            canJump = true;
            canCrouch = true;
        }
    }

    private bool UserTouchedScreen()
    {
        if(Input.touchCount > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void enableCharacterAnimation()
    {
        animator.enabled = true;
        landingSound.enabled = true;
    }

    private void disableCharacterAnimations()
    {
        animator.enabled = false;
        landingSound.enabled = false;
    }

    private bool UserTouchedLeftHalfOfScreen(Touch touch)
    {
        if(touch.position.x < Screen.width / 2 && canJump)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool UserTouchedRightHalfOfScreen(Touch touch)
    {
        if(touch.position.x > Screen.width / 2 && canCrouch && touch.phase != TouchPhase.Ended)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
