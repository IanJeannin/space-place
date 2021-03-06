﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterController : MonoBehaviour
{
    #region Serialize Fields
    [SerializeField]
    private float maxSpeed = 10f;
    [SerializeField]
    private float jumpForce = 700f;
    [SerializeField]
    private Checkpoints firstCheckpoint;
    [SerializeField]
    private SoundManager sound;
    #endregion

    #region Private Variables
    private bool isFacingRight = true;
    private bool isOnGround;
    private float groundRadius = 0.1f;  //Radius of the ground
    private Checkpoints currentCheckpoint;
    private float deathTime = 0; //Used to temporarily halt the player when they respawn
    private bool isInDeath = false; //Used to determine whether the death animation is playing
    private Animator anim; //The animator
    #endregion

    #region Public Variables
    public Transform groundCheck; //Circle collider trigger to determine whether player is touching ground
    public LayerMask whatIsGround; //LayerMask for determining ground
    #endregion

    void Start ()
    {
        anim = GetComponent<Animator>(); //Sets anim to the animator being used
	}
	
	void FixedUpdate ()
    {
        Movement();
    }

    private void Update()
    {
        Jump();
    }

    void Flip() //Flips the character animation
    {
        isFacingRight = !isFacingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    public void SetCurrentCheckpoint(Checkpoints newCurrentCheckpoint) //Changes current checkpoint when player walks through checkpoint.
    {
        if (currentCheckpoint != null) //If there is already a checkpoint
        {
            currentCheckpoint.SetIsActivated(false); //Set that checkpoint to false
        }
        currentCheckpoint = newCurrentCheckpoint; //Make current checkpoint equal the new checkpoint
        currentCheckpoint.SetIsActivated(true); //Activate checkpoint
    }

    public void StartRespawn()
    {
        isInDeath = true;
        deathTime = Time.realtimeSinceStartup; //Set the current time for deathTime
    }
    public void Respawn()
    {
           isInDeath = false;
            if (currentCheckpoint == null) //If there is no current checkpoint
            {
                 transform.position = firstCheckpoint.transform.position; //Transfer player to checkpoint position
                 anim.SetBool("IsDead", false);
            }
            else //If there is a current checkpoint
            {
                transform.position = currentCheckpoint.transform.position; //Transfer player to checkpoint position
                anim.SetBool("IsDead", false);
            }
            anim.SetFloat("Speed", 0);
    }

    private void CheckPlayerDirection(float move)
    {
        //Changes the animation if the player switches direction
        if (move > 0 && !isFacingRight)
        {
            Flip();
        }
        if (move < 0 && isFacingRight)
        {
            Flip();
        }
    }

    private void Jump()
    {
        if (Time.time - deathTime >= 3 || deathTime == 0) //If four seconds have passed since respawn was called
        {
            if (isOnGround && Input.GetButtonDown("Jump")) //If the player is on the ground and presses the jump button
            {
                sound.JumpSound();
                anim.SetBool("Ground", false); //Player is no longer on the ground
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce)); //Add upwards force ot the character
            }
            if (Input.GetButton("Horizontal"))
            {
                anim.SetBool("IsMoving", true);
            }
            else
            {
                anim.SetBool("IsMoving", false);
            }
            deathTime = 0; //Once the player is able to move again, reset deathTime to 0
        }

        if (isInDeath == true) //Checks if StartRespawn has been called
        {
            anim.SetBool("IsDead", true); //When Respawn is called, set the "IsDead" parameter to true
            if (Time.realtimeSinceStartup - deathTime >= 2.5) //Once three seconds have passed
            {
                Respawn();
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            }
        }
    }

    private void Movement()
    {
        isOnGround = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround); //Check if the character is on the ground
        anim.SetBool("Ground", isOnGround);
        anim.SetFloat("VSpeed", GetComponent<Rigidbody2D>().velocity.y);

        if (Time.realtimeSinceStartup - deathTime >= 3 || deathTime == 0) //If four seconds have passed since respawn was called
        {
            float move = Input.GetAxis("Horizontal"); //Determines which direction character is moving in
            anim.SetFloat("Speed", Mathf.Abs(move)); //Changes animation to new movement
            GetComponent<Rigidbody2D>().velocity = new Vector2(move * maxSpeed, GetComponent<Rigidbody2D>().velocity.y); //Changes the velocity of the character
            deathTime = 0; //Reset deathTime to 0 once respawn is finished
            CheckPlayerDirection(move);
        }
    }
}
