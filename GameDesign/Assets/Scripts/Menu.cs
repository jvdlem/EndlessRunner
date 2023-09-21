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

    public void quit()
    {
        Application.Quit();
    }
}
