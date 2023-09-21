using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum gameStates
    {
        MainMenu,
        Playing,
        GameOver
    }
    public gameStates currentState;

    public GameObject deathScreen;
    public GameObject menuScreen;
    public PlayerMovement player;
    public AudioSource backGroundMusic;

    public Points points;
    float rememberIncrement;

    public bool obstaclesSpawn;
    // Start is called before the first frame update
    void Start()
    {
        rememberIncrement = points.pointsIncrement;
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case gameStates.MainMenu:
                menuScreen.gameObject.SetActive(true);
                obstaclesSpawn = false;
                player.canPlay = false;
                points.text.gameObject.SetActive(false);
                points.pointsIncrement = 0;

                break;

            case gameStates.Playing:
                player.canPlay = true;
                menuScreen.gameObject.SetActive(false);
                obstaclesSpawn = true;
                points.text.gameObject.SetActive(true);

                points.pointsIncrement = rememberIncrement;
                if (!backGroundMusic.isPlaying)
                {
                    backGroundMusic.Play();
                }
                break;

            case gameStates.GameOver:
                deathScreen.SetActive(true);
                obstaclesSpawn = false;
                player.canPlay = false;
                points.pointsIncrement = 0;
                break;
        }
    }
}
