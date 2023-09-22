using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameOver : MonoBehaviour
{
    public GameManager manager;

    public GameObject scorePopup, menuButtons;

    public TMP_InputField inputField;

    public HighScore highScore; // Reference to your HighScore Scriptable Object
    public LocalHighscore localHighscore;
    public bool enteredScore;

    public void enteredScoreName()
    {
        // Create a new HighScore object and add it to the HighScoreManager
        HighScore newScore = ScriptableObject.CreateInstance<HighScore>();
        newScore.playerName = inputField.text;
        newScore.score = manager.points.points;
/*
        ScoreEntry newEntry = new ScoreEntry(inputField.text, manager.points.points);
        highScore.playerName = newEntry.playerName;
        highScore.score = newEntry.score;*/

        localHighscore.scores.Add(newScore);
        localHighscore.SaveHighScores();

        enteredScore = true;
        scorePopup.SetActive(false);
        menuButtons.SetActive(true);
    }
    public void PlayAgain()
    {
        manager.currentState = GameManager.gameStates.Reset;
    }

    public void mainMenu()
    {
        manager.currentState = GameManager.gameStates.MainMenu;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
