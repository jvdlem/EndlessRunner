using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum gameStates
    {
        MainMenu,
        Highscore,
        Playing,
        GameOver,
        Reset
    }
    public gameStates currentState;

    public GameOver deathScreen;
    public GameObject menuScreen;
    public GameObject highscoreScreen;
    public LocalHighscore localHighscore;

    public PlayerMovement player;
    public Vector3 rememberPosition;

    public AudioSource backGroundMusic;

    public Points points;
    float rememberIncrement;

    public SpawnManager spawnManager;
    float rememberSpeed;

    public bool obstaclesSpawn;
    public bool obstacleCollision;
    // Start is called before the first frame update
    void Start()
    {
        localHighscore.LoadHighScores();
        rememberIncrement = points.pointsIncrement;
        rememberSpeed = spawnManager.movementSpeed;
        rememberPosition = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case gameStates.MainMenu:
                menuScreen.gameObject.SetActive(true);
                deathScreen.gameObject.SetActive(false);
                highscoreScreen.gameObject.SetActive(false);
                obstaclesSpawn = false;
                player.canPlay = false;
                points.text.gameObject.SetActive(false);
                points.pointsIncrement = 0;

                break;

            case gameStates.Highscore:
                menuScreen.gameObject.SetActive(false);
                highscoreScreen.gameObject.SetActive(true);
                break;

            case gameStates.Playing:

                if (!backGroundMusic.isPlaying)
                {
                    backGroundMusic.Play();
                }
                if (obstacleCollision)
                {
                    currentState = gameStates.GameOver;
                }
                break;

            case gameStates.GameOver:
                if (!deathScreen.enteredScore)
                {
                    deathScreen.gameObject.SetActive(true);
                    deathScreen.scorePopup.SetActive(true);
                    deathScreen.menuButtons.SetActive(false);
                }
                menuScreen.SetActive(false);
                obstaclesSpawn = false;
                player.canPlay = false;
                points.pointsIncrement = 0;
                break;

            case gameStates.Reset:
                for (int i = 0; i < spawnManager.obstacles.Count; i++)
                {
                    spawnManager.obstacles[i].SetActive(false);
                }
                player.transform.position = rememberPosition;
                obstacleCollision = false;
                player.canPlay = true;
                menuScreen.gameObject.SetActive(false);
                deathScreen.gameObject.SetActive(false);
                points.fakePoints = 0;
                spawnManager.movementSpeed = rememberSpeed;
                points.pointsIncrement = rememberIncrement;
                obstaclesSpawn = true;
                points.text.gameObject.SetActive(true);
                deathScreen.enteredScore = false;
                currentState = gameStates.Playing;
                break;
        }
    }
}
