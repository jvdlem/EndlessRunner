using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameManager manager;

    public void play()
    {
        manager.currentState = GameManager.gameStates.Reset;
    }

    public void highscore()
    {
        manager.currentState = GameManager.gameStates.Highscore;
    }

    public void Shop() 
    {
        manager.currentState = GameManager.gameStates.Shop;
    }

    public void Customize()
    {
        manager.currentState = GameManager.gameStates.Customize;
    }

    public void Controls()
    {
        manager.currentState = GameManager.gameStates.Controls;
    }

    public void quit()
    {
        Application.Quit();
    }
}
