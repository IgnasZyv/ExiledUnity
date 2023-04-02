using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Item : MonoBehaviour
{
    public static Item Instance;
    public int id;
    public string itemName;
    public Sprite itemIcon;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Item"))
        {
            Debug.Log("Collision With: " + collision.collider.gameObject.name);
            Debug.Log("Collision Tag: " + collision.collider.gameObject.tag);
        }
    }

}
