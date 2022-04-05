using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Login : MonoBehaviour
{
    public TMP_InputField username;
    [SerializeField] TaskManager taskManager;
    [SerializeField] FISHManager fishManager;
    public TMP_InputField password;
    bool alreadyComplete;
    [SerializeField]int pain;
    [SerializeField]int suffering;
    [SerializeField]GameObject login;
    [SerializeField]GameObject end;
    [SerializeField]GameObject wrong;
    [SerializeField]GameObject issue;
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
            pain = Random.Range(0,10);
            suffering += 3;
            string passwordTry =  password.text;
            string usernameTry = username.text;
            if (passwordTry.Equals("Southeastern Salmon") && usernameTry.Equals("Northwestern Pike"))
            {
                if (pain <= suffering)
                {
                    if (!alreadyComplete)
                    {
                        taskManager.TaskComplete(3);
                        fishManager.SendMessageToChat("> Task Completed! [Clock Into Work]");
                        alreadyComplete = true;
                        login.SetActive(false);
                        end.SetActive(true);
                    }
                }
                else
                {
                    taskManager.Mistake(5);
                    fishManager.SendMessageToChat("> Try Again[-5]");
                    username.Select();                
                    username.text = "";
                    password.Select();
                    password.text = "";
                    StartCoroutine(error());
                }
            }
            else
            {
                taskManager.Mistake(60);
                fishManager.SendMessageToChat("> Incorrect Input [-60m]");
                username.Select();                
                username.text = "";
                password.Select();
                password.text = "";
                StartCoroutine(incorrect());
            }
        }
    }

    IEnumerator error()
    {
        if (issue.activeSelf == false && wrong.activeSelf == false)
        {
            issue.SetActive(true);
            yield return new WaitForSeconds(1.5f);
            issue.SetActive(false);
        }
    }

    IEnumerator incorrect()
    {
        if (issue.activeSelf == false && wrong.activeSelf == false)
        {
            wrong.SetActive(true);
            yield return new WaitForSeconds(1.5f);
            wrong.SetActive(false);
        }
    }
}
