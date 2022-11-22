using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemDisplayer : MonoBehaviour
{
    public ShopItem item;

    public Image itemImg;
    public Text itemNameText;
    public Text itemDescriptionText;
    public Text itemPriceText;

    private void Start()
    {
        itemImg.sprite = item.icon;
        itemNameText.text = item.name;
        itemDescriptionText.text = item.description;
        itemPriceText.text = item.price.ToString();
    }
    public void BuyItem()
    {
        //TODO: Player inventoryhoz hozzáad, pénzt levon
        Debug.Log(item.name + " has bought");
    }
}
