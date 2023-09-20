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

                points.text.gameObject.SetActive(false);
                points.pointsIncrement = 0;

                break;

            case gameStates.Playing:
                menuScreen.gameObject.SetActive(false);
                obstaclesSpawn = true;
                points.text.gameObject.SetActive(true);

                points.pointsIncrement = rememberIncrement;
                break;

            case gameStates.GameOver:
                deathScreen.SetActive(true);
                obstaclesSpawn = false;

                points.pointsIncrement = 0;
                break;
        }
    }
}
