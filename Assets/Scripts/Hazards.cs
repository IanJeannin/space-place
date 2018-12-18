using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hazards : MonoBehaviour
{
    #region PrivateVariables
    private bool isOn = true; //Used to determine whether or not the hazard is currently showing
    private float timeToChange = 0.02f; //Used to determine the time between hazard changing show state
    private float timeToAdd = 0.02f; //Add to timeToChange to continually change the hazards renderer
    #endregion

    #region SerializeFields
    [SerializeField]
    private Buttons button, button2; //Buttons associated with this gate
    [SerializeField]
    private SoundManager sound;
    [SerializeField]
    private bool onAtStartup;
    #endregion

    private void Update()
    {
        HazardStatus();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player")) //If an object with the tag "Player" collides with this object
        {
            sound.DeathSound();
            Debug.Log("Player entered Hazard"); //Test Line
            CharacterController player = collision.GetComponent<CharacterController>();
            player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0); //Make character stop moving.
            player.StartRespawn(); //StartRespawn in Character Controller
        }
    }

    private void HazardStatus()
    {
        if (button.GetActive() == onAtStartup && button2.GetActive() == onAtStartup) //So long as the button associated with this gate has not been pushed
        {
            this.GetComponent<BoxCollider2D>().enabled = true; //Turns the collider back on if the button associated with this hazard was pushed twice. 
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
                    foreach (SpriteRenderer x in hazard) //For every renderer in the child components
                    {
                        if (x.gameObject.transform.parent.name == "LazerGate" || transform.name == "FallDeath") //Checks that it's only getting the lazer parts of hazard
                        {
                            Color alpha = x.color; //Make a color variable to hold sprite renderers color
                            if (alpha.a == 0f) //If the renderer alpha is 0
                            {
                                alpha.a = 1f; //Make it 1
                            }
                            else //If the renderer alpha is 1
                            {
                                alpha.a = 0f; //Make it 0
                            }
                            x.color = alpha;
                        }
                        x.enabled = true;
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
                    x.enabled = false; //Turn off lazer images
                }
            }
        }
    }
}
