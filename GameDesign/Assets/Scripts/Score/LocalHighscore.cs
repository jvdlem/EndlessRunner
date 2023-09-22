using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LocalHighscore : MonoBehaviour
{
    public GameManager manager;
    public TextMeshProUGUI[] entries;

    public List<ScoreEntry> scores = new List<ScoreEntry>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < scores.Count; i++)
        {
            entries[i].text = (scores[i].playerName + " - " + scores[i].score);
        }
    }

    public void backToMenu()
    {
        manager.currentState = GameManager.gameStates.MainMenu;
    }
}
