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
    public GameObject shortcutToOpen;
    public RectTransform Canvas;

    void Awake()
    {
        Canvas = GameObject.Find("Canvas").GetComponent<RectTransform>();
    }

     public void OnPointerClick(PointerEventData eventData)
    {
            tap = eventData.clickCount;
 
        if (tap == 2)
        {
            if (GameObject.Find(shortcutToOpen.name + "(Clone)") != null)
            {
                return;
            }
            else
            {
                GameObject window = Instantiate(windowToOpen, new Vector3(Random.Range(-100, 100), Random.Range(-87, 155), 0), transform.rotation);
            window.transform.SetParent(Canvas, false);
                GameObject shortcut = Instantiate(shortcutToOpen, new Vector3(-767.6f, -501.8f, 0), transform.rotation);
            shortcut.transform.SetParent(Canvas, false);
                shortcut.GetComponent<Shortcut>().window = window.GetComponent<Window>();
            }
            
        }
 
    }

    
}
