using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.UI;
using TMPro;
using UnityEngine.EventSystems;


public class Icon : MonoBehaviour, IPointerClickHandler
{
    int tap;
    
     public void OnPointerClick(PointerEventData eventData)
    {
        tap = eventData.clickCount;
 
        if (tap == 2)
        {
            Debug.Log("double clicked");
        }
 
    }

    
}
