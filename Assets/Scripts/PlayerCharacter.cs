using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour {

    public Rigidbody2D myRigidBody;
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
            myRigidBody.velocity = new Vector2(5,0);
            
        }
        //This is the syntax for printing to the console
        //Debug.Log("Hello World");
	}
}
