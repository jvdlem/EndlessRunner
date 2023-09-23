using UnityEngine;

[CreateAssetMenu(fileName = "HighScore", menuName = "ScriptableObjects/HighScore", order = 1)]
public class HighScore : ScriptableObject
{
    public string playerName;
    public int score;
}
