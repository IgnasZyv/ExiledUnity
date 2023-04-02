using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 1f;
    public float offset = 0.05f;
    public ContactFilter2D filter;
    
    private Vector2 _movementInput;
    private Rigidbody2D rb;
    private readonly List<RaycastHit2D> _collisions = new List<RaycastHit2D>();
    

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame 
    private void FixedUpdate()
    {
        if (_movementInput == Vector2.zero) return;
        {
            var canMove = TryMove(_movementInput); // try to move in the direction of the input

            if (canMove) return;
            {
                canMove = TryMove(new Vector2(_movementInput.x, 0)); // if can't move in the direction of the input, try to move in the x direction

                if (!canMove)
                {
                    canMove = TryMove(new Vector2(0, _movementInput.y)); // if can't move in the x direction, try to move in the y direction
                }
            }

        }
    }

    private bool TryMove(Vector2 direction)
    {
        var collisionCount = rb.Cast (
            direction, // direction
            filter, // filter
            _collisions, // list of collisions
            movementSpeed * Time.fixedDeltaTime + offset); // distance for raycast

        if (collisionCount.Equals(0)) // if no collisions
        {
            rb.MovePosition(rb.position + direction * (movementSpeed * Time.fixedDeltaTime));
            return true;
        }
        else
        {
            if (!_collisions[0].collider.CompareTag("Item") || !_collisions[0].collider.CompareTag("Equipment")) return false;
            {
                rb.MovePosition(rb.position + direction * (movementSpeed * Time.fixedDeltaTime));
                return true;
            }
        }
    }

    private void PickUpItem(Item item)
    {
        Debug.Log("Picked up item: " + item);
        
        InventoryManager.Instance.AddItem(item);
        Destroy(item.gameObject);
    }


    private void OnMove(InputValue movementValue)
    {
        _movementInput = movementValue.Get<Vector2>();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Item"))
        {
            PickUpItem(col.gameObject.GetComponent<Item>());
        }
    }
}
