using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorButton : MonoBehaviour
{
    public BuyButton buyButton;
    public Color color;
    public int cost = 0;
    public int number;
    public void setColor()
    {
        buyButton.color = this.color;
        buyButton.Cost = this.cost;
        buyButton.number = this.number;
    }
}
