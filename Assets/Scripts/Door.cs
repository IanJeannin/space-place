using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    #region SerializeFields
    [SerializeField]
    private string sceneToLoad;
    [SerializeField]
    private SoundManager sound;
    #endregion

    #region PrivateVariables
    private bool isUnlocked = false;
    private bool isPlayerInTrigger;
    #endregion

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            isPlayerInTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            isPlayerInTrigger = false;
        }
    }

    private void Update()
    {
        if (isUnlocked == true) //If all the pickups are collected
        {
            this.gameObject.GetComponent<SpriteRenderer>().enabled = true; //Enable the sprite
            this.gameObject.GetComponent<Collider2D>().enabled = true; //Enable the collider
            if (Input.GetButtonDown("Activate") && isPlayerInTrigger) //If the player is within the collider and presses e or up
            {
                sound.DoorSound(); //Play door sound
                Debug.Log("Player activated Door!");
                SceneManager.LoadScene(sceneToLoad);
            }
        }
        else
        {
            this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            this.gameObject.GetComponent<Collider2D>().enabled = false;
        }
    }

    public void Unlock() //Function used to decrement toUnlock, called from Pickups
    {
        isUnlocked = true;
        Debug.Log("Unlocked"+gameObject.name);
    }
}
