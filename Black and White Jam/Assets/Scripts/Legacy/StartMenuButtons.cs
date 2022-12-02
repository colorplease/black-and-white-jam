using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.SceneManagement;

public class StartMenuButtons : MonoBehaviour, IDeselectHandler 
{
    [SerializeField]Sprite defaultSprite;
    [SerializeField]Sprite inverted;
    [SerializeField]TextMeshProUGUI buttonText;
    [SerializeField]Image icon;
    GameObject[] windows;
    Window[] windowScripts;
    GameObject[] noMinimizeWindows;
    NoMinimizeWindow[] noMinimizeWindowsScripts;

    public void Selected()
    {
        icon.sprite = inverted;
        buttonText.color = Color.black;
    }

    public void OnDeselect (BaseEventData data)
    {
        icon.sprite = defaultSprite;
        buttonText.color = Color.white;
    }

    public void KillAllTabs()
    {
        windows = GameObject.FindGameObjectsWithTag("Window");
        windowScripts = new Window[windows.Length];
        for (int i = 0; i < windows.Length; i++)
        {
            windowScripts[i] = windows[i].GetComponent<Window>();
            windowScripts[i].Close();
        }
        noMinimizeWindows = GameObject.FindGameObjectsWithTag("NoMiniWindow");
        noMinimizeWindowsScripts = new NoMinimizeWindow[noMinimizeWindows.Length];
        for (int i = 0; i < noMinimizeWindows.Length; i++)
        {
            noMinimizeWindowsScripts[i] = noMinimizeWindows[i].GetComponent<NoMinimizeWindow>();
            noMinimizeWindowsScripts[i].Close();
        }

    }

    public void Quit()
    {
        Application.Quit();
    }
    
}
