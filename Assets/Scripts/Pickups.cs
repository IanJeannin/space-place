using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickups : MonoBehaviour
{
    #region PrivateVariables
    private float min = 1f;
    private float max = 2f;
    #endregion

    #region SerializeFields
    [SerializeField]
    private float numberOfPickups = 1;
    [SerializeField]
    private Door door;
    [SerializeField]
    private SoundManager sound;
    #endregion

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
