using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour {

    [SerializeField]
    Rigidbody2D myRigidBody;
    [SerializeField]
    private float speed=10;
	// Use this for initialization
	void Start ()
    {
        Debug.Log("This is STARTA!");
	}
	
	// Update is called once per frame
	void Update ()
    {

        if(Input.GetKey(KeyCode.D))
        {
            //TODO: Move Character Right
            myRigidBody.velocity = new Vector2(speed,0);
            
        }
        
        if (Input.GetKey(KeyCode.S))
        {
            myRigidBody.velocity = new Vector2(0, -speed);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            myRigidBody.velocity = new Vector2(-speed, 0);
        }
        else if (Input.GetKey(KeyCode.W))
        {
            myRigidBody.velocity = new Vector2(0, speed);
        }
        //This is the syntax for printing to the console
        //Debug.Log("Hello World");
    }
}
