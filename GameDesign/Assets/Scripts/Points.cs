using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Points : MonoBehaviour
{
    public int points = 0;
    private float fakePoints = 0;
    public float pointsIncrement = 0;
    public TMP_Text text;
    private void FixedUpdate()
    {
        fakePoints += pointsIncrement;
        points = (int)fakePoints;
        text.text = "Points:" + points;
    }
}
