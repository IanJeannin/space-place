using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour {

    [SerializeField]
    private string sceneToLoad;
    private bool isUnlocked = false;

    private bool isPlayerInTrigger;
    

    //Can't use this because player has two colliders, triggers twice

    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("Player"))
    //    {
    //        if(Input.GetButtonDown("Activate"))
    //        {
    //            Debug.Log("Player activated Door!");
    //        }
    //    }
    //}

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
        
        if (isUnlocked == true)
        {
            this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
            this.gameObject.GetComponent<Collider2D>().enabled = true;
            if (Input.GetButtonDown("Activate") && isPlayerInTrigger)
            {
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
