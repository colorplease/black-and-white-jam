using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class WindowDragRedux : MonoBehaviour, IDragHandler, IPointerDownHandler
{
    [SerializeField] RectTransform dragRectTransform;
    [SerializeField]RectTransform shakea;
    //a square that turns red if the window is selected, turns blue if not
    [SerializeField]Image debugImage;
    public bool isDraggable;
    [SerializeField]TextMeshProUGUI title;
    public void OnDrag(PointerEventData eventData)
    {
        if (isDraggable)
        {
            //Moves window, divided by shakea object or else it goes apeshit crazy
            dragRectTransform.anchoredPosition += eventData.delta / shakea.localScale.x;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //brings window to the front
        dragRectTransform.SetAsLastSibling();

    }
    // Start is called before the first frame update
    void Start()
    {
        shakea = GameObject.FindWithTag("ShakeaShakea").GetComponent<RectTransform>();
    }

    //checks if is lastsibling (in the front)
    public bool IsLastSibling()
    {
        if(dragRectTransform == dragRectTransform.parent.GetChild(dragRectTransform.parent.childCount - 1))
        {
            
            return true;
        }
        else
        {
            return false;
        }
    }

    void Update()
    {
        if (IsLastSibling())
        {
            //shows which window is currently focused
            title.fontStyle = FontStyles.Bold;
        }
        else
        {
            //shows which window is currently focused
            title.fontStyle = FontStyles.Normal;
        }
    }
}
