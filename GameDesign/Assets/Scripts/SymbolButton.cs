using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SymbolButton : MonoBehaviour
{
    public BuyButton buyButton;
    public Texture2D texture2D;
    public float emmison = 0;
    public string textureName;
    public int number;
    public int cost = 0;
    public void setSymbol()
    {
        buyButton.Cost = this.cost;
        buyButton.texture = texture2D;
        buyButton.emmison = emmison;
        buyButton.textureName = textureName;
        buyButton.number = this.number;
    }
}
