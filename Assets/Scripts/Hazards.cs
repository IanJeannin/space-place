using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hazards : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player entered Hazard");
            PlayerCharacter player = collision.GetComponent<PlayerCharacter>();
            player.Respawn();
        }
        else
        {
            Debug.Log("Something other than the player entered the Hazard.");
        }
        
    }
}
