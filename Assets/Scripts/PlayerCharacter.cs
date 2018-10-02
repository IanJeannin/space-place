﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour {

    [SerializeField]
    Rigidbody2D rb2d;
    [SerializeField]
    private float accelerationForce = 10;

    private float horizontalInput;
    // Use this for initialization
    void Start()
    {
        Debug.Log("This is STARTA!");
    }

    // Update is called once per frame
    void Update()
    {

        GetMovementInput();

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
    }

    private void GetMovementInput()
    {
       horizontalInput=Input.GetAxis("Horizontal");
        
    }

    private void Jump()
    {
        //TODO Make Jump
    }

}

