using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonCheck : MonoBehaviour
{
    public InventoryInteractot inventory;
    public int myNumber = 0;
    public bool isColor, isSymbol;
    private void Start()
    {
        if (isColor)
        {
            this.transform.gameObject.SetActive(inventory.CheckColor(myNumber));
        }
        else if (isSymbol)
        {
            this.transform.gameObject.SetActive(inventory.CheckSymbol(myNumber));
        }
    }
    private void Awake()
    {
        if (isColor)
        {
            this.transform.gameObject.SetActive(inventory.CheckColor(myNumber));
        }
        else if (isSymbol)
        {
           this.transform.gameObject.SetActive(inventory.CheckSymbol(myNumber));
        }
    }
    private void Update()
    {
        if (isColor)
        {
            this.transform.gameObject.SetActive(inventory.CheckColor(myNumber));
        }
        else if (isSymbol)
        {
            this.transform.gameObject.SetActive(inventory.CheckSymbol(myNumber));
        }
    }

}
