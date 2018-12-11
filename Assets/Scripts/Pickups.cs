using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickups : MonoBehaviour {

    private float min = 1f;
    private float max = 2f;
    [SerializeField]
    private float numberOfPickups = 1;
    [SerializeField]
    Door door;
    [SerializeField]
    SoundManager sound;
    //public Door door;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
       /* if (Time.time <min)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + (float)(1*0.00125));
        }
        else if(Time.time>=min&&Time.time<max)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y +(float) (1*0.00125));
        }
        else
        {
            min += 2;
            max += 2;
        }
        */
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            numberOfPickups--;
            sound.PickupSound();
            if(numberOfPickups<=0)
            {
                door.Unlock(); //Calls PickedUp method from Door class
            }
            Debug.Log("Player picked up Object");
            this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            this.gameObject.GetComponent<CircleCollider2D>().enabled = false;
            this.transform.GetComponentInChildren<ParticleSystem>().gameObject.SetActive(false);
        }
    }
}
