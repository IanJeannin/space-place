using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour {

    [SerializeField]
    private float maxSpeed = 10f;
    [SerializeField]
    private float jumpForce = 700f;

    private bool isFacingRight = true;
    private bool isOnGround;
    public Transform groundCheck; //Circle collider trigger to determine whether player is touching ground
    float groundRadius=0.2f;  //Radius of the ground
    public LayerMask whatIsGround; //LayerMask for determining ground


    Animator anim; //The animator


	// Use this for initialization
	void Start ()
    {
        anim = GetComponent<Animator>(); //Sets anim to the animator being used
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {

        isOnGround = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround); //Check if the character is on the ground
        anim.SetBool("Ground", isOnGround);

        anim.SetFloat("VSpeed", GetComponent<Rigidbody2D>().velocity.y); 

        float move = Input.GetAxis("Horizontal"); //Determines which direction character is moving in
        anim.SetFloat("Speed", Mathf.Abs(move)); //Changes animation to new movement

        GetComponent<Rigidbody2D>().velocity = new Vector2(move * maxSpeed, GetComponent<Rigidbody2D>().velocity.y); //Changes the velocity of the character

        //Changes the animation if the player switches direction
        if (move>0&&!isFacingRight) 
        {
            Flip();
        }
        if(move<0&&isFacingRight)
        {
            Flip();
        }

    }

    private void Update()
    {
        if (isOnGround && Input.GetButtonDown("Jump")) //If the player is on the ground and presses the jump button
        {
            anim.SetBool("Ground", false); //Player is no longer on the ground
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce)); //Add upwards force ot the character
        }
    }

    void Flip() //Flips the character animation
    {
        isFacingRight = !isFacingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
