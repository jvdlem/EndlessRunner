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

    public GameObject deathscreen;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case gameStates.MainMenu:
                break;

            case gameStates.Playing:
                break;

            case gameStates.GameOver:
                deathscreen.SetActive(true);
                break;
        }
    }
}
