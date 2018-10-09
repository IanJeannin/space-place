using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Checkpoints : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player entered Checkpoint");
            PlayerCharacter player = collision.GetComponent<PlayerCharacter>();
            player.SetCurrentCheckpoint(this);
        }
    }

}
