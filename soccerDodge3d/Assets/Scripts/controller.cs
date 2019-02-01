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

    private bool canJump;
    private bool canCrouch;
    private Rigidbody playerRigidBody;
    private BoxCollider playerBoxCollider;
	void Start () 
    {
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
                    playerRigidBody.velocity = new Vector3(playerRigidBody.velocity.x, jumpForce, playerRigidBody.velocity.z);
                    ballScript.firstClick = true;
                }
                else if (UserTouchedRightHalfOfScreen(touch)) 
                {
                    animator.SetBool("isCrouching", true);
                    ballScript.firstClick = true;
                } else 
                {
                    animator.SetBool ("isCrouching", false);
                }
            }

*/
        if(Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            playerRigidBody.velocity = new Vector3(playerRigidBody.velocity.x, jumpForce, playerRigidBody.velocity.z);
            ballScript.firstClick = true;
        }
        else if(Input.GetKey(KeyCode.C) && canCrouch == true)
        {
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
        if(col.gameObject.tag == "Ground")
        {
            animator.SetTrigger("hitGround");
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

    private bool UserTouchedLeftHalfOfScreen(Touch touch)
    {
        if(touch.position.x < Screen.width / 2 && canJump == true)
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
        if(touch.position.x > Screen.width / 2 && canCrouch == true && touch.phase != TouchPhase.Ended)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
