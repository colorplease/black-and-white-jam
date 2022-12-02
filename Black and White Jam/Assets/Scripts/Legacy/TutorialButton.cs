using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialButton : MonoBehaviour
{
    public GameObject button;
    public void OnClick()
    {
        Destroy(gameObject, 0.1f);
    }

    public void Continue()
    {
        SceneManager.LoadScene(2);
    }
}
