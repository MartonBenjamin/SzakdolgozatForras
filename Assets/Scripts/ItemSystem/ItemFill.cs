using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemFill : MonoBehaviour
{
    public List<ShopItem> items;
    public GameObject itemTemplate;
    public Transform slotHolder;

    private void Start()
    {
        for (int i = 0; i < items.Count; i++)
        {
            GameObject newItem = Instantiate(itemTemplate);
            newItem.SetActive(true);
            newItem.transform.SetParent(slotHolder);
            newItem.transform.localScale = new Vector3(1, 1, 1);
            newItem.GetComponent<ItemDisplayer>().item = items[i];
        }
        
       
    }
}
