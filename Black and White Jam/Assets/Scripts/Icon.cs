using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.UI;
using TMPro;
using UnityEngine.EventSystems;


public class Icon : MonoBehaviour, IPointerClickHandler
{
    int tap;
    public GameObject windowToOpen;
    public RectTransform Canvas;
    
     public void OnPointerClick(PointerEventData eventData)
    {
            tap = eventData.clickCount;
 
        if (tap == 2)
        {
            if (GameObject.Find(windowToOpen.name + "(Clone)") != null)
            {
                return;
            }
            else
            {
                GameObject window = Instantiate(windowToOpen, new Vector3(Random.Range(-100, 100), Random.Range(-87, 155), 0), transform.rotation);
            window.transform.SetParent(Canvas, false);
            }
            
        }
 
    }

    
}
