using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hazards : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player")) //If an object with the tag "Player" collides with this object
        {
            Debug.Log("Player entered Hazard"); //Test Line
            CharacterController player = collision.GetComponent<CharacterController>();
            player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0); //Make character stop moving. (NOT WORKING)
            player.StartRespawn(); //StartRespawn in Character Controller
        }
        /*
        else
        {
            Debug.Log("Something other than the player entered the Hazard.");
        }
        */
        
    }
}
