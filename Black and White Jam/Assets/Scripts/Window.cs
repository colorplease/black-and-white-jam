using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Window : MonoBehaviour
{
    public RectTransform minimizeTo;
    [SerializeField]Vector3 lastRecordedPos;
    public float minimizeSpeed;
    public float moveSpeed;
    public bool isMinimizing;
    public bool isMaximizing;

    void Awake()
    {
    }


    public void Minimize()
    {
        lastRecordedPos = transform.position;
        isMinimizing = true;
    }

    public void Close()
    {
        Destroy(minimizeTo.gameObject);
        Destroy(gameObject);
    }

    public void Maximize()
    {
        isMaximizing = true;
    }

    void Update()
    {
        if (isMinimizing)
        {
            transform.position = Vector3.MoveTowards(transform.position, minimizeTo.position, moveSpeed);
            transform.localScale = Vector3.Lerp(transform.localScale, new Vector3 (0f, 0f, 1), minimizeSpeed * Time.fixedDeltaTime);
        }
        else if (isMaximizing)
        {
            transform.position = lastRecordedPos;
            transform.localScale = new Vector3(1, 1 ,1);  
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
