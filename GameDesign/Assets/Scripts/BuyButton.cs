using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyButton : MonoBehaviour
{
    public InventoryInteractot inventory;
    public Color color;
    public int Cost = 0;
    public Texture2D texture;
    public float emmison = 0;
    public string textureName;
    public int number;
    public void buyColor()
    {
        inventory.checkCoins();
        if (Cost <= inventory.coins)
        {
            inventory.addColor(color, number);
            inventory.modifyCoins(-Cost);
        }
        
    }
    public void buySymbol()
    {
        inventory.checkCoins();
        if (Cost <= inventory.coins)
        {
            inventory.addSymbol(texture, emmison, textureName, number);
            inventory.modifyCoins(-Cost);
        }
    }

}
