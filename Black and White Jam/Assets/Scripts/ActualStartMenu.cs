using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ActualStartMenu : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public bool closeMenuMenu;
    public bool pleaseForTheLoveOfGod;
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        closeMenuMenu = false;
        transform.SetAsLastSibling();
    }

     public void OnPointerExit(PointerEventData eventData)
    {
        closeMenuMenu = true;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            pleaseForTheLoveOfGod = true;
        }
        else
        {
            pleaseForTheLoveOfGod = false;
        }
    }
}
