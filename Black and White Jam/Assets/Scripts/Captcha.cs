using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Captcha : MonoBehaviour
{
    [SerializeField]GameObject YESFISH;
    [SerializeField]GameObject NOTFISH;
    [SerializeField]GameObject[] set;
    [SerializeField] TaskManager taskManager;
    [SerializeField] FISHManager fishManager;
    [SerializeField] int currentSet;
    [SerializeField] int fishPoints;

    void Awake()
    {
        taskManager = GameObject.FindGameObjectWithTag("TaskManager").GetComponent<TaskManager>();
        fishManager = GameObject.FindGameObjectWithTag("FISH").GetComponent<FISHManager>();
    }

    public void YES()
    {
        StartCoroutine(yes());
    }

    public void NOT()
    {
        StartCoroutine(not());
    }

    public void yesfish()
    {
        fishPoints++;
    }

    public void notfish()
    {
        fishPoints--;
    }

    IEnumerator yes()
    {
        set[currentSet].SetActive(false);
        YESFISH.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        YESFISH.SetActive(false);
        if (currentSet + 1 < set.Length)
        {
            currentSet++;
            set[currentSet].SetActive(true);
        }
        else
        {
            Debug.Log("ooga");
        }
    }

    IEnumerator not()
    {
        set[currentSet].SetActive(false);
        NOTFISH.SetActive(true);
        taskManager.Mistake();
        fishManager.SendMessageToChat("> not fish [-60m]");
        yield return new WaitForSeconds(1.5f);
        currentSet = 0;
        set[currentSet].SetActive(true);
        NOTFISH.SetActive(false);
        
    }


}
