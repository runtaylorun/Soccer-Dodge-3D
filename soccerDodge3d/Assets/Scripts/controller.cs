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

    private bool hitGround;
    private bool canJump;
    private bool canCrouch;
    private Rigidbody playerRigidBody;
    private BoxCollider playerBoxCollider;
	void Start () 
    {
        canJump = true;
        canCrouch = true;
        hitGround = false;
        playerRigidBody = GetComponent<Rigidbody>();
        playerBoxCollider = GetComponent<BoxCollider>();
		
	}


    void Update()
    {
            if (Input.touchCount > 0 && ballScript.isPlaying == true) {
                var touch = Input.GetTouch (0);
                ballScript.firstClick = true;
                if (touch.position.x < Screen.width / 2 && canJump == true)
                {
                    playerRigidBody.velocity = new Vector3(playerRigidBody.velocity.x, jumpForce, playerRigidBody.velocity.z);
                }
                else if (touch.position.x > Screen.width / 2 && touch.phase != TouchPhase.Ended && canCrouch == true) {
                    animator.SetBool("isCrouching", true);
                } else {
                    animator.SetBool ("isCrouching", false);
                }
            }
	}

     void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Air")
        {
            canJump = false;
            canCrouch = false;
            hitGround = true;
            animator.ResetTrigger("hitGround");
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Ground")
        {
            if(hitGround == true)
            {
                animator.SetTrigger("hitGround");
            }
            canJump = true;
            canCrouch = true;
            hitGround = false;
        }
    }

}
