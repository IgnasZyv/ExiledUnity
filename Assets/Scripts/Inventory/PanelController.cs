using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class PanelController : MonoBehaviour
{
    public static PanelController Instance;
    
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

    public void ToggleInventory()
    {
        // gameObject.SetActive(!gameObject.activeSelf);
        var canvasGroup = gameObject.GetComponent<CanvasGroup>();
        var alpha = canvasGroup.alpha;
        if (alpha.Equals(0))
        {
            alpha = canvasGroup.alpha = 1;
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;
        }
        else
        {
            alpha = canvasGroup.alpha = 0;
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
        }
    }
    
    
}