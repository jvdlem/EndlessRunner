using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public GameManager manager;

    public PlayerMovement movement;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Ground")
        {
            movement.isOnGround = true;
            movement.myAudio.clip = movement.audioClips[1];
            movement.myAudio.Play();
            movement.land.Play();
        }

        if (collision.transform.tag == "Obstacle" || collision.transform.tag == "FallingNet")
        {
            manager.obstacleCollision = true;
            //movement.enabled = false;
        }

        if (collision.transform.tag == "Coin")
        {
        
        }

        if (collision.transform.tag == "PowerUp")
        {
        
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.transform.tag == "Obstacle" || collision.transform.tag == "FallingNet")
        {
            manager.obstacleCollision = false;
        }
    }
}
