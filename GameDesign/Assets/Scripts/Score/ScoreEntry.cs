using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreEntry : MonoBehaviour
{
    public string playerName;
    public int score;

    public ScoreEntry(string _name, int _score)
    {
        playerName = _name;
        score = _score;
    }
}
