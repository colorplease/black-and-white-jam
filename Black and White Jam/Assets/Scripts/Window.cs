using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Window : MonoBehaviour
{
    public RectTransform minimizeTo;
    Vector3 TargetPos;
    public float minimizeSpeed;
    public float moveSpeed;
    public bool isMinimizing;
    public bool isMaximizing;


    public void Minimize()
    {
        minimizeTo = GameObject.Find("ShortcutTrashCanButton" + "(Clone)").GetComponent<RectTransform>();
        isMinimizing = true;
    }

    public void Close()
    {
        Destroy(GameObject.Find("ShortcutTrashCanButton" + "(Clone)"));
        Destroy(gameObject);
    }

    public void Maximize()
    {
        isMaximizing = true;
    }

    void Update()
    {
        if (minimizeTo == null)
        {
        minimizeTo = GameObject.Find("ShortcutTrashCanButton" + "(Clone)").GetComponent<RectTransform>();
        }
        if (isMinimizing)
        {
            transform.position = Vector3.MoveTowards(transform.position, minimizeTo.position, moveSpeed);
            transform.localScale = Vector3.Lerp(transform.localScale, new Vector3 (0f, 0f, 1), minimizeSpeed * Time.fixedDeltaTime);
        }
        else if (isMaximizing)
        {
            TargetPos = new Vector3(21,28, 0);
            transform.position = Vector3.MoveTowards(transform.position, TargetPos, moveSpeed);
            transform.localScale = Vector3.Lerp(transform.localScale, new Vector3 (1f, 1f, 1), minimizeSpeed * Time.fixedDeltaTime);
        }

        if (transform.position == minimizeTo.position && isMinimizing == true)
        {
            isMinimizing = false;
            gameObject.SetActive(false);
        }

        if (transform.localScale == new Vector3(1f, 1f, 1))
        {
            isMaximizing = false;
        }

    }

}
