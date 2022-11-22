using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New ShopItem", menuName ="Items/ShopItem")]
public class ShopItem : ScriptableObject
{
    public uint id;
    public new string name;
    public string description;

    public Sprite icon;

    public int price;
   
}
