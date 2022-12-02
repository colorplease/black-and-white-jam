using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WindowDrag : MonoBehaviour, IDragHandler, IPointerDownHandler
{
    [SerializeField] private RectTransform dragRectTransform;
    [SerializeField] private Canvas canvas;
    [SerializeField] private RectTransform shakeaShakea;

    void Awake()
    {
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        shakeaShakea = GameObject.FindGameObjectWithTag ("ShakeaShakea").GetComponent<RectTransform>();
    }
    public void OnDrag(PointerEventData eventData)
    {
       dragRectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor / shakeaShakea.localScale.x;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        dragRectTransform.SetAsLastSibling();
    }
}
