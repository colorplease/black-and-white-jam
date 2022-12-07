using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KPReadout : MonoBehaviour
{
    public int maxMessages = 25;
    public GameObject chatPanel, textObject;
    [SerializeField]List<MessageRedux> messageList = new List<MessageRedux>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SendMessageToChat("I'm bombing the school");
        }
    }

    public void SendMessageToChat(string text)
    {
        if (messageList.Count >= maxMessages)
        {
            Destroy(messageList[0].textObject.gameObject);
            messageList.Remove(messageList[0]);
        }
            MessageRedux newMessage = new MessageRedux();
            newMessage.text = "> " + text;
            GameObject newText = Instantiate(textObject, chatPanel.transform);
            newMessage.textObject = newText.GetComponent<TextMeshProUGUI>();
            newMessage.textObject.SetText(newMessage.text);
            messageList.Add(newMessage);
    }
}

    [System.Serializable]
public class MessageRedux
{
    public string text;
    public TextMeshProUGUI textObject;
}
