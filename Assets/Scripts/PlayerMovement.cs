using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public Animator playerAnim;
	public Rigidbody playerRigid;
	public float w_speed, wb_speed, olw_speed, rn_speed, ro_speed;
	public bool walking;
	public Transform playerTrans;

    private void Start()
    {
		playerAnim.SetTrigger("idle");
		walking = false;
    }

    bool isMoving = false;
    void Update()
    {

        // Check for W key
        if (Input.GetKeyDown(KeyCode.W))
        {
            playerAnim.SetTrigger("walk");
            playerAnim.ResetTrigger("idle");
            walking = true;
            isMoving = true;
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            playerAnim.ResetTrigger("walk");
            playerAnim.SetTrigger("idle");
            walking = false;
        }

        // Check for S key
        if (Input.GetKeyDown(KeyCode.S))
        {
            playerAnim.SetTrigger("walkback");
            playerAnim.ResetTrigger("idle");
            isMoving = true;
            walking = true;
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            playerAnim.ResetTrigger("walkback");
        }

        // Check for A key
        if (Input.GetKey(KeyCode.A))
        {
            isMoving = true;
        }

        // Check for D key
        if (Input.GetKey(KeyCode.D))
        {
            isMoving = true;
        }

        // Check for Left Shift key
        if (walking)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                w_speed = w_speed + rn_speed;
                playerAnim.SetTrigger("run");
                playerAnim.ResetTrigger("walk");
                isMoving = true;
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                playerAnim.ResetTrigger("run");
                playerAnim.SetTrigger("walk");
            }
        }

        // Check if not moving
        if (!isMoving)
        {
            walking = false;
            playerAnim.SetTrigger("idle");
        }
    }

}