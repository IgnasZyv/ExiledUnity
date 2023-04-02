using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public GameObject player;
    public Camera camera;
    private Vector3 offset;
    private Boolean boolCamIsMovingToPlayer = false;
    
    // Start is called before the first frame update
    private void Start()
    {
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        var viewPos = camera.WorldToViewportPoint(player.transform.position); // Assign the coordinates of the target to viewPos in Viewport space
        if (viewPos.x >= 0.75F || viewPos.x <= 0.25F || viewPos.y <= 0.25F ||
            viewPos.y >= 0.75F) // Check if the target is beyond the boundaries defined for the dead zone
        {
            StartCoroutine(Transition()); // If the target is on or outside the boundary, move the camera to recenter on it

        }
        
        

    }
    
 private IEnumerator Transition()
    {
        if (boolCamIsMovingToPlayer) yield break;
        boolCamIsMovingToPlayer = true;
        var playerPosition = player.transform.position;
        var cameraPosition = new Vector3(playerPosition.x, playerPosition.y, -10f);
        var t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime;
            transform.position = Vector3.Lerp(transform.position, cameraPosition, t);
            yield return null;
        }
        boolCamIsMovingToPlayer = false;
    }
        
        
        
}

