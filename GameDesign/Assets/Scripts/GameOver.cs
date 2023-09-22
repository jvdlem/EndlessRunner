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

    public LocalHighscore localHighscore;
    public string nameInput;
    public bool enteredScore;

    public void enteredScoreName()
    {
        // Create a new ScoreEntry and add it to the list
        ScoreEntry newEntry = new ScoreEntry(inputField.text, manager.points.points);
        localHighscore.scores.Add(newEntry);

        // Sort the list by score in descending order
        localHighscore.scores.Sort((x, y) => y.score.CompareTo(x.score));
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
