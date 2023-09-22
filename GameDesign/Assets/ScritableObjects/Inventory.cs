using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Inventory", order = 1)]
public class Inventory : ScriptableObject
{
    public int colorIndex;
    public int symbolIndex;
    public int coins;
    public string name;
    public int HighScore;
    public List<Color> colors;
    public List<int> colorGotten;
    public List<int> symbolGotten;
    public List<Texture2D> textures;
    public List<float> emmisonStrength;
    public List<string> names;
}
