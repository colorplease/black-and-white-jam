using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CursorScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] Texture2D cursor2;
    public void OnPointerEnter(PointerEventData eventData)
   {
       Cursor.SetCursor(cursor2, Vector2.zero, CursorMode.Auto);
   }

   public void OnPointerExit(PointerEventData eventData)
   {
       Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
   }
}
