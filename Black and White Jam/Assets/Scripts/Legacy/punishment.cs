using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class punishment : MonoBehaviour
{
    [SerializeField] TaskManager taskManager;
    [SerializeField] FISHManager fishManager;
    [SerializeField]string message;
    [SerializeField]float discipline;

    void Awake()
    {
        taskManager = GameObject.FindGameObjectWithTag("TaskManager").GetComponent<TaskManager>();
        fishManager = GameObject.FindGameObjectWithTag("FISH").GetComponent<FISHManager>();
        taskManager.Mistake(discipline);
        fishManager.SendMessageToChat(message);
        Destroy(gameObject, 5f);
    }
}
