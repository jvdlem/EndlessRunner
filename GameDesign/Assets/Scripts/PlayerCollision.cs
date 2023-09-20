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
        }

        if (collision.transform.tag == "Obstacle")
        {
            Debug.Log("Death");
            manager.currentState = GameManager.gameStates.GameOver;
            movement.enabled = false;
        }

        if (collision.transform.tag == "Coin")
        {
        
        }

        if (collision.transform.tag == "PowerUp")
        {
        
        }
    }
}
