using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class FISHManager : MonoBehaviour, IPointerDownHandler
{
    public int maxMessages = 25;
    public GameObject chatPanel, textObject;
    [SerializeField]
   List<Message> messageList = new List<Message>();
   [SerializeField] RectTransform dragRectTransform;

   void Awake()
   {
       SendMessageToChat("> COMPLETE ALL TASKS BY THE END OF THE DAY");
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
   }

   public void OnPointerDown(PointerEventData eventData)
    {
        dragRectTransform.SetAsLastSibling();
    }


}

[System.Serializable]
public class Message
{
    public string text;
    public TextMeshProUGUI textObject;
}
