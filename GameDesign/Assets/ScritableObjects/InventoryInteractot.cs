using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryInteractot : MonoBehaviour
{
    public GameObject player;
    public Inventory inventoryPlayer;
    public int colorIndex = 0;
    public int symbolIndex = 0;
    public Image ColorPanel;
    public Material mat;
    public TMP_Text text;
    public int coins = 0;

    private void Start()
    {
        mat.color = inventoryPlayer.colors[inventoryPlayer.colorIndex];
        if (ColorPanel != null)
        {
            ColorPanel.color = inventoryPlayer.colors[inventoryPlayer.colorIndex];
            text.text = "Symbol:" + inventoryPlayer.names[inventoryPlayer.symbolIndex];
        }
        mat.SetTexture("_EmissionMap", inventoryPlayer.textures[inventoryPlayer.symbolIndex]);
        mat.SetColor("_EmissionColor", Color.white * inventoryPlayer.emmisonStrength[inventoryPlayer.symbolIndex]);

    }
    private void Awake()
    {
        mat = player.GetComponent<Renderer>().material;
    }
    public void changeColor(int number)
    {
        colorIndex += number;
        inventoryPlayer.colorIndex = colorIndex;
        if (colorIndex < inventoryPlayer.colors.Count && inventoryPlayer.colorIndex > 0)
        {
            inventoryPlayer.colorIndex = colorIndex;
            mat.color = inventoryPlayer.colors[inventoryPlayer.colorIndex];
            ColorPanel.color = inventoryPlayer.colors[inventoryPlayer.colorIndex];
        }
        else if (colorIndex < 0)
        {
            colorIndex = inventoryPlayer.colors.Count -1;
            inventoryPlayer.colorIndex = colorIndex;    
            mat.color = inventoryPlayer.colors[inventoryPlayer.colorIndex];


            ColorPanel.color = inventoryPlayer.colors[inventoryPlayer.colorIndex];
        }
        else
        {
            colorIndex = 0;
            inventoryPlayer.colorIndex = colorIndex;
            mat.color = inventoryPlayer.colors[inventoryPlayer.colorIndex];

            ColorPanel.color = inventoryPlayer.colors[inventoryPlayer.colorIndex];
        }
    }

    public void changeSymbol(int number)
    {
        symbolIndex += number;
        inventoryPlayer.symbolIndex = symbolIndex;
        if (symbolIndex < inventoryPlayer.textures.Count && symbolIndex > 0)
        {
            inventoryPlayer.symbolIndex = symbolIndex;
            mat.SetTexture("_EmissionMap", inventoryPlayer.textures[inventoryPlayer.symbolIndex]);
            mat.SetColor("_EmissionColor", Color.white * inventoryPlayer.emmisonStrength[inventoryPlayer.symbolIndex]);
            text.text = "Symbol:" + inventoryPlayer.names[inventoryPlayer.symbolIndex];
        }
        else if (symbolIndex < 0)
        {
            symbolIndex = inventoryPlayer.textures.Count - 1;
            inventoryPlayer.symbolIndex = symbolIndex;
            mat.SetTexture("_EmissionMap", inventoryPlayer.textures[inventoryPlayer.symbolIndex]);
            mat.SetColor("_EmissionColor", Color.white * inventoryPlayer.emmisonStrength[inventoryPlayer.symbolIndex]);
            text.text = "Symbol:" + inventoryPlayer.names[symbolIndex];
        }
        else
        {
            symbolIndex = 0;
            inventoryPlayer.symbolIndex = symbolIndex;
            mat.SetTexture("_EmissionMap", inventoryPlayer.textures[inventoryPlayer.symbolIndex]);
            mat.SetColor("_EmissionColor", Color.white * inventoryPlayer.emmisonStrength[inventoryPlayer.symbolIndex]);
            text.text = "Symbol:" + inventoryPlayer.names[inventoryPlayer.symbolIndex];
        }
    }

    public void addColor(Color aColor, int number)
    {
        inventoryPlayer.colors.Add(aColor);
        inventoryPlayer.colorGotten.Add(number);
    }

    public void modifyCoins(int amountOfCoins)
    {
        inventoryPlayer.coins += amountOfCoins;
    }

    public void addSymbol(Texture2D aTexture, float emmison,string name, int number)
    {
        inventoryPlayer.textures.Add(aTexture);
        inventoryPlayer.emmisonStrength.Add(emmison);
        inventoryPlayer.names.Add(name); 
        inventoryPlayer.symbolGotten.Add(number);
    }

    public bool CheckColor(int value)
    {
        bool check = true;
        for (int i = 0; i < inventoryPlayer.colorGotten.Count; i++)
        {
            if (value == inventoryPlayer.colorGotten[i])
            {
                check = false;
            }
        }
        return check;
    }

    public bool CheckSymbol(int value)
    {
        bool check = true;
        for (int i = 0; i < inventoryPlayer.symbolGotten.Count; i++)
        {
            if (value == inventoryPlayer.symbolGotten[i])
            {
                check = false;
            }
        }
        return check;
    }

    public void checkCoins()
    {
        this.coins = inventoryPlayer.coins;
    }


}
