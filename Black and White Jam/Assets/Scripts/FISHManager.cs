using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

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
   [SerializeField]bool tutorial;
   [SerializeField]GameObject[] tutorialObjects;
   bool updateCall;
   public bool complete;
   int callNumber;
   GameObject[] windows;
    Window[] windowScripts;

   void Awake()
   {
       if (!tutorial)
       {
           SendMessageToChat("> COMPLETE ALL TASKS BY THE END OF THE DAY");
       }
       else
       {
           StartCoroutine(Set());
       }
       
   }

   public void SendMessageToChat(string text)
   {
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
       messageList[currentMessage].textObject.fontSize = 45;
       if (currentMessage != 0)
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
            currentDialogue++;
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
