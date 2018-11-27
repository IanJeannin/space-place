using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour {

   
    private bool isPlayerInTrigger; //Checks if player character is currently within the trigger
    private bool isActive=true; //Checks if button has yet to be pressed
    [SerializeField]
    SoundManager sound;

    private void OnTriggerEnter2D(Collider2D collision) //If an object enters the collider
    {
        if (collision.CompareTag("Player")) //If that object is a player
        {
            isPlayerInTrigger = true; //isPlayerInTrigger=true
        }
    }

    private void OnTriggerExit2D(Collider2D collision) //If an object exits the collider
    {
        if (collision.CompareTag("Player")) //If that object is a player
        {
            isPlayerInTrigger = false; //isPlayerInTrigger=true
        }
    }

    private void Update()
    {
        if (Input.GetButtonDown("Activate") && isPlayerInTrigger) //If the player clicks the interact key while inside the collider
        {
            sound.ButtonSound();
            if(isActive==true) //If the button hasn't been pressed
            {
                Debug.Log("Player activated Button!");
                isActive = false;
                GetComponent<SpriteRenderer>().enabled = false; //Hide the unpressed button renderer
            }
            else
            {
                Debug.Log("Player has deactivatedButton!");
                isActive = true;
                GetComponent<SpriteRenderer>().enabled = true; //show the unpressed button renderer
            }
            
        }
    }

    public bool GetActive() //Function used to access the isActive of the current object
    {
        return isActive;
    }
}
