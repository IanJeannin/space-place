using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hazards : MonoBehaviour {

    private bool isOn = true; //Used to determine whether or not the hazard is currently showing
    private float timeToChange = 0.01f; //Used to determine the time between hazard changing show state
    private float timeToAdd = 0.01f; //Add to timeToChange to continually change the hazards renderer
    [SerializeField]
    Buttons button; //Button associated with this gate

    private void Update()
    {
        if (button.GetActive() == true) //So long as the button associated with this gate has not been pushed
        {
            if (transform.parent.name == "Hazards") //Used to only access the lazer image of the gate
            {
                if (Time.time > timeToChange) //If the time since startup is a multiple of the time to change, change isOn
                {
                    isOn = !isOn; //isOn equals whatever it's not
                    timeToChange += timeToAdd;
                }

                if (isOn == true) //If isOn is true
                {
                    SpriteRenderer[] hazard = GetComponentsInChildren<SpriteRenderer>(); //Get all rendrers in child objects
                    foreach (Renderer x in hazard) //For every renderer in the child components
                    {
                        if (x.gameObject.transform.parent.name == "LazerGate" || transform.name == "FallDeath") //Checks that it's only getting the lazer parts of hazard
                        {
                            x.enabled = true; //Let the hazard show
                        }

                    }
                }
                else //Otherwise
                {
                    SpriteRenderer[] hazard = GetComponentsInChildren<SpriteRenderer>();
                    foreach (Renderer x in hazard)
                    {
                        if (x.gameObject.transform.parent.name == "LazerGate" || transform.name == "FallDeath") //Checks that it's only getting the lazer parts of hazard
                        {
                            x.enabled = false; //Don't
                        }
                    }
                }
            }
        }
        else
        {
            this.GetComponent<BoxCollider2D>().enabled = false;
            SpriteRenderer[] hazard = GetComponentsInChildren<SpriteRenderer>();
            foreach (Renderer x in hazard)
            {
                if (x.gameObject.transform.parent.name == "LazerGate") //Checks that it's only getting the lazer parts of hazard
                {
                    x.enabled = false; //Don't
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player")) //If an object with the tag "Player" collides with this object
        {
            Debug.Log("Player entered Hazard"); //Test Line
            CharacterController player = collision.GetComponent<CharacterController>();
            player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0); //Make character stop moving.
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
