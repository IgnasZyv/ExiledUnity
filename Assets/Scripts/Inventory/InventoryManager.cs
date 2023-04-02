using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public List<Item> items = new List<Item>();
    
    private GridLayoutGroup _gridLayoutGroup;
    
    private void Start()
    {
        _gridLayoutGroup = GetComponentInChildren<GridLayoutGroup>();
        
    }
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddItem(Item item)
    {
        var slot = FindEmptySlot();
        if (slot == null) return;
        {
            slot.AddItemToSlot(item);
            items.Add(item);
            Debug.Log("Added item: " + item.name + " to inventory");

        }
    }

    public void RemoveItem(Item item)
    {
        items.Remove(item);
    }

    private InventorySlot FindEmptySlot()
    {
        var slots = _gridLayoutGroup.GetComponentsInChildren<InventorySlot>();
        
        int childCount = _gridLayoutGroup.transform.childCount;
        Debug.Log("childCount: " + childCount);
        for (var i = 0; i < childCount; i++)
        {
            var child = _gridLayoutGroup.transform.GetChild(i);
            Debug.Log("Child: " + child);
            var inventorySlot = child.gameObject.GetComponent<InventorySlot>();
            Debug.Log("InventorySlot name: " + inventorySlot.name);
            Debug.Log("InventorySlot item: " + inventorySlot.GetItem());
            Debug.Log("istaken: " + inventorySlot.isTaken);
            if (!inventorySlot.isTaken)
            {
                return inventorySlot;
            }
        }
        
        return null;
    }
    
    
}
