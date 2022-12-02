using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ToDo : MonoBehaviour, IPointerDownHandler
{
    [SerializeField]Transform small;
   public void OnPointerDown(PointerEventData pointerEventData)
   {
       small.SetAsLastSibling();
   }
}
