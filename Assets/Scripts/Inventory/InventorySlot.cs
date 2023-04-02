using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Item item;
    public bool isTaken = false;
    
    public TextMeshProUGUI text;
    public RawImage image;
    
    
    public void AddItemToSlot(Item newItem)
    {
        item = newItem;
        isTaken = true;
        SetChildrenComponents();
        Debug.Log("AddItemToSlot called, item name: " + item);
    }

    private void SetChildrenComponents()
    {
        Debug.Log("SetChildrenComponents called, item name: " + item.itemName);
        Debug.Log(text.text);
        text.SetText(item.itemName);
        image.texture = item.itemIcon.texture;
        
        text.gameObject.SetActive(true);
        image.gameObject.SetActive(true);
    }

    public Item GetItem()
    {
        return item;
    }
}
