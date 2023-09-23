using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LocalHighscore : MonoBehaviour
{
    public GameManager manager;
    public TextMeshProUGUI[] entries;

    public List<HighScore> scores = new List<HighScore>();
    // Start is called before the first frame update
    void Start()
    {
        //LoadHighScores();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < scores.Count; i++)
        {
            entries[i].text = (scores[i].playerName + " - " + scores[i].score);
        }
    }

    public void SaveHighScores()
    {
        // Convert highScores list to a JSON string and save it to PlayerPrefs
        string scoresJson = JsonUtility.ToJson(scores);
        PlayerPrefs.SetString("HighScore", scoresJson);
        PlayerPrefs.Save();

        Debug.Log("High scores saved: " + scoresJson);
    }

    // Function to load high scores
    public void LoadHighScores()
    {
        if (PlayerPrefs.HasKey("HighScore"))
        {
            // Retrieve the JSON string from PlayerPrefs and convert it back to a List
            string scoresJson = PlayerPrefs.GetString("HighScore");
            scores = JsonUtility.FromJson<List<HighScore>>(scoresJson); // Use HighScore
            Debug.Log("High scores loaded: " + scoresJson);
        }

/*        if (PlayerPrefs.HasKey("HighScore"))
        {
            // Retrieve the JSON string from PlayerPrefs and convert it back to a List
            string scoresJson = PlayerPrefs.GetString("HighScore");
            List<HighScore> loadedScores = JsonUtility.FromJson<List<HighScore>>(scoresJson); // Use HighScore

            // Add the loaded scores to your existing list
            scores.AddRange(loadedScores);
        }*/
    }

    public void backToMenu()
    {
        manager.currentState = GameManager.gameStates.MainMenu;
    }


}
