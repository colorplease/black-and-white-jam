using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Window : MonoBehaviour
{
    public RectTransform minimizeTo;
    [SerializeField]Vector3 lastRecordedPos;
    [SerializeField]Vector3 lastRecordedSize;
    public float minimizeSpeed;
    public float moveSpeed;
    public bool isMinimizing;
    public bool isMaximizing;
    public Transform shakeaShakea;
    public FISHManager fishManager;
    public string instructions;

    

    void Awake()
    {
        shakeaShakea = GameObject.FindGameObjectWithTag ("ShakeaShakea").GetComponent<RectTransform>();
        fishManager = GameObject.FindGameObjectWithTag("FISH").GetComponent<FISHManager>();
        StartCoroutine(instruct());
    }

    IEnumerator instruct()
    {
        yield return new WaitForSeconds(0.5f);
        fishManager.SendMessageToChat(instructions);
    }


    public void Minimize()
    {
        lastRecordedPos = transform.localPosition;
        lastRecordedSize = new Vector3(transform.localScale.x, transform.localScale.y, 1f);
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
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, minimizeTo.localPosition, moveSpeed);
            transform.localScale = Vector3.Lerp(transform.localScale, new Vector3 (0f, 0f, 1), minimizeSpeed * Time.fixedDeltaTime);
        }
        else if (isMaximizing)
        {
            transform.localPosition = lastRecordedPos;
            transform.localScale = lastRecordedSize;
        }

        if (transform.position == minimizeTo.position && isMinimizing == true)
        {
            isMinimizing = false;
            gameObject.SetActive(false);
        }

        if (transform.localScale == lastRecordedSize)
        {
            isMaximizing = false;
        }

    }

}
