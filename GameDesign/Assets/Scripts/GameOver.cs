using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameManager manager;
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
