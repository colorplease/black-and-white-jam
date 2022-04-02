using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shortcut : MonoBehaviour
{
    public Window window;
    public void MaximizeCall()
    {
        window.gameObject.SetActive(true);
        window.Maximize();
    }
}
