using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shortcut : MonoBehaviour
{
    public Window window;
    public void MaximizeCall()
    {
        if (window.gameObject.activeSelf == false)
        {
            window.gameObject.SetActive(true);
            window.Maximize();
        }

        window.gameObject.transform.SetAsLastSibling();
        window.Focus();
    }
}
