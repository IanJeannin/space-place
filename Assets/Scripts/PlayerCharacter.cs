using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour {

    [SerializeField]
    Rigidbody2D myRigidBody;
    [SerializeField]
    private float speed = 10;

    private float moveInput;
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
        myRigidBody.velocity = new Vector2(moveInput*speed, myRigidBody.velocity.y);
        
    }

    private void GetMovementInput()
    {
       moveInput=Input.GetAxis("Horizontal");
    }

    private void Jump()
    {
        //TODO Make Jump
    }

}

