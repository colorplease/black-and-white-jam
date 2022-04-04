using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class StartMenu : MonoBehaviour, ISelectHandler, IPointerDownHandler, IDeselectHandler
{
    public TextMeshProUGUI startText;
    public GameObject startMenu;
    public ActualStartMenu actualStartMenu;

    void Awake()
    {
    }

    public void OnSelect(BaseEventData eventData)
    {
        startText.color = Color.black;
        startMenu.SetActive(true);
    }

    public void OnDeselect(BaseEventData eventData)
    {
        startText.color = Color.white;
        if (actualStartMenu.closeMenuMenu == true)
        {
            startMenu.SetActive(false);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        startText.color = Color.black;
    }

    void Update()
    {
        if (actualStartMenu.closeMenuMenu == true && actualStartMenu.pleaseForTheLoveOfGod == true)
        {
            startText.color = Color.white;
            actualStartMenu.closeMenuMenu = false;
            actualStartMenu.pleaseForTheLoveOfGod = false;
            startMenu.SetActive(false);
        }
    }
}
