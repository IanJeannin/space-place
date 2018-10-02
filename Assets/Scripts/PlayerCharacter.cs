using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour {

    [SerializeField]
    Rigidbody2D rb2d;
    [SerializeField]
    private float accelerationForce = 10;
    [SerializeField]
    private float maxSpeed;
    [SerializeField]
    private float jumpForce=10;

    private float horizontalInput;

    // Update is called once per frame
    void Update()
    {

        GetMovementInput();
        Jump();

    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        //Don't use, because we are using Physics
        //transform.Translate(1, 0, 0);
        // myRigidBody.velocity = new Vector2(horizontalInput*speed, myRigidBody.velocity.y);

        rb2d.AddForce(Vector2.right * horizontalInput * accelerationForce);
        Vector2 clampedVelocity = rb2d.velocity;
        clampedVelocity.x = Mathf.Clamp(rb2d.velocity.x, -maxSpeed, maxSpeed);
        rb2d.velocity = clampedVelocity;
    }

    private void GetMovementInput()
    {
       horizontalInput=Input.GetAxis("Horizontal");
        
    }

    private void Jump()
    {
        //TODO Make Jump
        if (Input.GetButtonDown("Jump"))
        {
            rb2d.AddForce(Vector2.up*jumpForce, ForceMode2D.Impulse);
        }
    }

}

