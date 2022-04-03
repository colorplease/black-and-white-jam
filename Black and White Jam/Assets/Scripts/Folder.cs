using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.UI;
using TMPro;
using UnityEngine.EventSystems;

// 1: -767.6
// 2: -699.3
// 3: -631.49
// 4: -565.4
// 5: -498.2
// 6: -431.1
// 7: -364.3
// 8: -296.7
public class Folder : MonoBehaviour, IPointerClickHandler
{
    int tap;
    int numberOfShortcuts;
    float xShortCutPos;
    public GameObject windowToOpen;
    public RectTransform Canvas;
    public Transform shakeaShakea;

    void Awake()
    {
        Canvas = GameObject.Find("Canvas").GetComponent<RectTransform>();
        shakeaShakea = GameObject.FindGameObjectWithTag ("ShakeaShakea").GetComponent<RectTransform>();
    }

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
                GameObject window = Instantiate(windowToOpen, new Vector3(Random.Range(-100, 100) / shakeaShakea.localScale.x, Random.Range(-87, 155), 0)/shakeaShakea.localScale.y, transform.rotation);
                window.transform.localScale = new Vector3(window.transform.localScale.x / shakeaShakea.localScale.x, window.transform.localScale.y / shakeaShakea.localScale.y, 1f);
                window.transform.SetParent(shakeaShakea);        
                }
            
        }
 
    }

    
}
