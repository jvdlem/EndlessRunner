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
    public string nameInput;
    public bool enteredScore;

    public void enteredScoreName()
    {
        nameInput = inputField.text;
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
