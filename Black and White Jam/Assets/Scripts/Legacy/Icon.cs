using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
public class Icon : MonoBehaviour, IPointerClickHandler
{
    int tap;
    int numberOfShortcuts;
    float xShortCutPos;
    public GameObject windowToOpen;
    public GameObject shortcutToOpen;
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
            if (GameObject.Find(shortcutToOpen.name + "(Clone)") != null)
            {
                return;
            }
            else
            {
            numberOfShortcuts = GameObject.FindGameObjectsWithTag("Shortcut").Length;
            switch(numberOfShortcuts)
            {
                case 0:
                {
                    xShortCutPos = -767.6f;
                    break;
                }
                case 1:
                {
                    xShortCutPos = -699.3f;
                    break;
                }
                case 2:
                {
                    xShortCutPos = -631.49f;
                    break;
                }
                case 3:
                {
                    xShortCutPos = -565.4f;
                    break;
                }
                case 4:
                {
                    xShortCutPos = -498.2f;
                    break;
                }
                case 5:
                {
                    xShortCutPos = -431.1f;
                    break;
                }
                case 6:
                {
                    xShortCutPos = -364.3f;
                    break;
                }
                case 7:
                {
                    xShortCutPos = -296.7f;
                    break;
                }
            }
                GameObject window = Instantiate(windowToOpen, new Vector3(Random.Range(-100, 100) / shakeaShakea.localScale.x, Random.Range(-87, 155), 0)/shakeaShakea.localScale.y, transform.rotation);
                window.transform.localScale = new Vector3(window.transform.localScale.x / shakeaShakea.localScale.x, window.transform.localScale.y / shakeaShakea.localScale.y, 1f);
                window.transform.SetParent(shakeaShakea);
                GameObject shortcut = Instantiate(shortcutToOpen, new Vector3(xShortCutPos / shakeaShakea.localScale.x, -501.8f / shakeaShakea.localScale.x, 0), transform.rotation);
                shortcut.transform.localScale = new Vector3(shortcut.transform.localScale.x / shakeaShakea.localScale.x, shortcut.transform.localScale.y / shakeaShakea.localScale.y,shortcut.transform.localScale.y / shakeaShakea.localScale.y );
                shortcut.transform.SetParent(shakeaShakea);
                shortcut.GetComponent<Shortcut>().window = window.GetComponent<Window>();
                window.GetComponent<Window>().minimizeTo = shortcut.GetComponent<RectTransform>();            
                }
            
        }
 
    }

    
}
