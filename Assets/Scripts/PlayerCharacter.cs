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
    [SerializeField]
    ContactFilter2D groundContactFilter;
    [SerializeField]
    private Collider2D groundDetectTrigger;

    private float horizontalInput;
    private bool isOnGround;
    private Collider2D[] groundHitDetectionResults= new Collider2D[16];

    // Update is called once per frame
    void Update()
    {
        UpdateIsOnGround();
        GetMovementInput();
        Jump();
       
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void UpdateIsOnGround()
    {
        isOnGround= groundDetectTrigger.OverlapCollider(groundContactFilter, groundHitDetectionResults) >0;
        //Debug.Log("isonGround: " + isOnGround);
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
        if (Input.GetButtonDown("Jump")&&isOnGround==true)
        {
            rb2d.AddForce(Vector2.up*jumpForce, ForceMode2D.Impulse);
        }
    }

}

