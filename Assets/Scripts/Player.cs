using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    //
    // public float moveSpeed = 1f;
    // public float hitPoints = 100f;
    //
    // private Rigidbody2D rb2d;
    //
    // // Start is called before the first frame update
    // private void Start()
    // {
    //     rb2d = GetComponent<Rigidbody2D>();
    // }
    //
    // // Update is called once per frame
    // private void Update()
    // {
    //     if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
    //     {
    //         
    //         Ray2D ray = new Ray2D(transform.position, new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")));
    //         RaycastHit2D hit;
    //
    //         var horizontalMovement = Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime;
    //         var verticalMovement = Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime;
    //
    //         var directionOfMovement = new Vector3(horizontalMovement, verticalMovement, 0);
    //     
    //         gameObject.transform.Translate(directionOfMovement);
    //     }
    //     
    // }
    //
    // private void OnCollisionEnter2D(Collision2D collision)
    // {
    //     Debug.Log("Collision With: " + collision.collider.gameObject.name);
    //     Debug.Log("Collision Tag: " + collision.collider.gameObject.tag);
    // }
}
