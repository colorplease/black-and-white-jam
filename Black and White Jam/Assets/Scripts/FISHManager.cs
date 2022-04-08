using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

[System.Serializable]
public class TutorialDialogue
{
    public string tutorialDialogue;
    public float timeBetweenNextDialogue;
    public bool breakTime;
    public int setNumberCall;
}

public class FISHManager : MonoBehaviour, IPointerDownHandler
{
    public int maxMessages = 25;
    public GameObject chatPanel, textObject;
    [SerializeField]
   List<Message> messageList = new List<Message>();
   [SerializeField] RectTransform dragRectTransform;
   [SerializeField]int currentMessage;
   [SerializeField]TutorialDialogue[] tutorialDialogues;
   [SerializeField]int currentDialogue;
   public bool tutorial;
   [SerializeField]GameObject[] tutorialObjects;
   [SerializeField]TaskManager taskManager;
   bool updateCall;
   public bool complete;
   int callNumber;
   GameObject[] windows;
    Window[] windowScripts;
    public AudioSource audioSource;
    public AudioClip[] sounds;

   void Awake()
   {
        taskManager = GameObject.FindGameObjectWithTag("TaskManager").GetComponent<TaskManager>();
       if (!tutorial)
       {
           StartCoroutine(intro());
       }
       else
       {
           StartCoroutine(Set());
       }
       
   }

   IEnumerator intro()
   {
       SendMessageToChat("> FINISH ALL TASKS BY THE END OF THE DAY");
       yield return new WaitForSeconds(4);
       SendMessageToChat("> TASKS AND WORK HOURS CAN BE FOUND IN YOUR NOTEPAD");
       yield return new WaitForSeconds(4);
       SendMessageToChat("> WORK BEGINS IN");
       yield return new WaitForSeconds(1f);
       SendMessageToChat("> 3");
       yield return new WaitForSeconds(2);
       SendMessageToChat("> 2");
       yield return new WaitForSeconds(2);
       SendMessageToChat("> 1");
       yield return new WaitForSeconds(2);
       taskManager.StartGame();
       SendMessageToChat("> GET MOVING");
   }

   public void SendMessageToChat(string text)
   {
       var randomMessage = Random.Range(0, 2);
       audioSource.PlayOneShot(sounds[randomMessage]);
       if (messageList.Count >= maxMessages)
       {
           Destroy(messageList[0].textObject.gameObject);
           messageList.Remove(messageList[0]);
       }
       Message newMessage = new Message();
       newMessage.text = text;
       GameObject newText = Instantiate(textObject, chatPanel.transform);
       newMessage.textObject = newText.GetComponent<TextMeshProUGUI>(); 
       newMessage.textObject.text = newMessage.text;
       messageList.Add(newMessage);
       dragRectTransform.SetAsLastSibling();
       messageList[currentMessage].textObject.fontSize = 42;
       if (currentMessage > 0)
       {
           messageList[currentMessage - 1].textObject.fontSize = 36;
       }
       currentMessage++;
   }

   public void OnPointerDown(PointerEventData eventData)
    {
        dragRectTransform.SetAsLastSibling();
    }

    void Sets(int setNumber)
    {
        switch(setNumber)
        {
            case 0:
            currentDialogue++;
            tutorialObjects[0].SetActive(true);
            tutorialObjects[1].SetActive(true);
            tutorialObjects[2].SetActive(true);
            taskManager.UpdateToDoList();
            StartCoroutine(Set());
            break;

            case 1:
            currentDialogue++;
            updateCall = true;
            callNumber = setNumber;
            break;

            case 2:
            currentDialogue++;
            updateCall = true;
            callNumber = setNumber;
            break;

            case 3:
            currentDialogue++;
            tutorialObjects[0].SetActive(false);
            tutorialObjects[3].SetActive(true);
            windows = GameObject.FindGameObjectsWithTag("Window");
            windowScripts = new Window[windows.Length];
            for (int i = 0; i < windows.Length; i++)
            {
            windowScripts[i] = windows[i].GetComponent<Window>();
            windowScripts[i].Close();
            }
            StartCoroutine(Set());
            break;
            
            case 4:
            currentDialogue++;
            updateCall = true;
            callNumber = setNumber;
            break;

            case 5:
            currentDialogue++;
            updateCall = true;
            callNumber = setNumber;
            break;

            case 6:
            currentDialogue++;
            tutorialObjects[4].SetActive(true);
            tutorialObjects[2].transform.SetAsLastSibling();
            StartCoroutine(Set());
            break;

            case 7:
            currentDialogue++;
            updateCall = true;
            callNumber = setNumber;
            break;

            case 8:
            currentDialogue++;
            GameObject.FindGameObjectWithTag("tutorial").GetComponent<TutorialButton>().button.SetActive(true);
            StartCoroutine(Set());
            break;

            case 9:
            SceneManager.LoadScene(1);
            break;

            case 10:
            currentDialogue++;
            updateCall = true;
            callNumber = setNumber;
            break;

            case 11:
            SceneManager.LoadScene(4);
            break;

            case 12:
            SceneManager.LoadScene(9);
            break;



        }
    }

    void Update()
    {
        if (updateCall)
        {
            switch(callNumber)
            {
                case 1:
                    if (GameObject.FindGameObjectWithTag("Window") != null)
                    {
                        StartCoroutine(Set());
                        updateCall = false;
                    }
                break;

                case 2:
                if (GameObject.FindGameObjectWithTag("circle") == null)
                {
                    taskManager.TaskComplete(1);
                    SendMessageToChat("> Task Completed! [Click the Circles]");
                    StartCoroutine(Set());
                    updateCall = false;
                }
                break;
                
                case 3:
                if (GameObject.FindGameObjectWithTag("Window") != null)
                    {
                        StartCoroutine(Set());
                        updateCall = false;
                    }
                break;

                case 4:
                if (complete)
                    {
                        StartCoroutine(Set());
                        updateCall = false;
                    }
                break;

                case 5:
                if (GameObject.FindGameObjectWithTag("Window") == null)
                    {
                        StartCoroutine(Set());
                        updateCall = false;
                    }
                break;

                case 7: 
                if (GameObject.FindGameObjectWithTag("NoMiniWindow") != null)
                    {
                        StartCoroutine(Set());
                        updateCall = false;
                    }
                break;

                case 10:
                if (GameObject.FindGameObjectWithTag("start menu") != null)
                    {
                        StartCoroutine(Set());
                        updateCall = false;
                    }
                break;

            }
        }

        if (tutorial)
        {
            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            {
                if (Input.GetKey(KeyCode.K))
                {
                    if (Input.GetKey(KeyCode.M))
                    {
                        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                    }
                }
            }
        }
    }

    IEnumerator Set()
    {
        SendMessageToChat(tutorialDialogues[currentDialogue].tutorialDialogue);
        yield return new WaitForSeconds(tutorialDialogues[currentDialogue].timeBetweenNextDialogue);
        if(tutorialDialogues[currentDialogue].breakTime)
        {
            Sets(tutorialDialogues[currentDialogue].setNumberCall);
        }
        else
        {
            currentDialogue += 1;
            StartCoroutine(Set());
        }
        
    }


}

[System.Serializable]
public class Message
{
    public string text;
    public TextMeshProUGUI textObject;
}
