using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialButton : MonoBehaviour
{
    public void OnClick()
    {
        Destroy(gameObject, 0.1f);
    }
}
