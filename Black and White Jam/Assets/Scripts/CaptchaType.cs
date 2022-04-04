using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CaptchaType : MonoBehaviour
{
    public TMP_InputField inputField;
    [SerializeField] TaskManager taskManager;
    [SerializeField] FISHManager fishManager;
    [SerializeField] Captcha captcha;
    // Update is called once per frame

    void Awake()
    {
        taskManager = GameObject.FindGameObjectWithTag("TaskManager").GetComponent<TaskManager>();
        fishManager = GameObject.FindGameObjectWithTag("FISH").GetComponent<FISHManager>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            string passwordTry = inputField.text;
            if (passwordTry.Equals("i love fish"))
            {
                taskManager.TaskComplete(4);
                fishManager.SendMessageToChat("> Task Completed! [Fish Verification]");
                captcha.rightFish();
            }
            else if (passwordTry.Equals("fish"))
            {

                fishManager.SendMessageToChat("> fish?");
            }
            else
            {
                taskManager.Mistake();
                fishManager.SendMessageToChat("> Incorrect Input [-60m]");
                inputField.Select();                
                inputField.text = "";
                captcha.wrongFish();
            }
        }
    }
}
