using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    public int maxMessages = 100;
    [SerializeField]GameObject chatPanel, textObject;
    [SerializeField]TMP_InputField chatBox;
    [SerializeField]GameObject chatBoxObject;
    [SerializeField]AudioSource audioSource;
    [SerializeField]AudioSource audioSource2;
    [SerializeField]AudioClip[] clips;
    [SerializeField]AudioClip[] sounds;
    [SerializeField]GameObject flash;
    [SerializeField]
    List<Message2> messageList2 = new List<Message2>();
    bool ready;

    void Awake()
    {
        StartCoroutine(boot());
        ready = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && ready)
        {
            string command = chatBox.text;
            if (command.Equals("//help"))
            {
               StartCoroutine(help());
            }

            if (command.Equals("//start"))
            {
                StartCoroutine(start());
            }

            if (command.Equals("//fish"))
            {
                StartCoroutine(fish());
            }

            if (command.Equals("//quit"))
            {
                StartCoroutine(quit());
            }
        }

        if (chatBox.text != "" && ready)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                SendMessageToChatTitleScreen("> " + chatBox.text);
                chatBox.text = "";
            }
        }
    }

    IEnumerator help()
    {
        yield return new WaitForSeconds(1);
        SendMessageToChatTitleScreen("> //start to start FinuxOS;  //quit exit Title.exe;  //fish for a surprise"); 
    }

     IEnumerator start()
    {
        yield return new WaitForSeconds(1);
        SendMessageToChatTitleScreen("> Loading FinuxOS...");
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(1);
    }

    IEnumerator quit()
    {
        yield return new WaitForSeconds(1);
        SendMessageToChatTitleScreen("> Quitting...");
        yield return new WaitForSeconds(2); 
        Application.Quit();
    }

    IEnumerator fish()
    {
        yield return new WaitForSeconds(1);
        SendMessageToChatTitleScreen("> Loading fish...");
        yield return new WaitForSeconds(2); 
        audioSource2.Stop();
        audioSource2.clip = clips[2];
        audioSource2.Play();
        SendMessageToChatTitleScreen("> fish Loaded!");
    }

    
    
    IEnumerator boot()
    {
        audioSource.clip = clips[0];
        audioSource.Play();
        flash.SetActive(true);
        yield return new WaitForSeconds(0.025f);
        flash.SetActive(false);
        yield return new WaitForSeconds(0.25f);
        SendMessageToChatTitleScreen("> Warming Up...");
        yield return new WaitForSeconds(5);
        SendMessageToChatTitleScreen("> Loading 'Title.exe'.");
        yield return new WaitForSeconds(1);
         SendMessageToChatTitleScreen("> Loading 'Title.exe'..");
        yield return new WaitForSeconds(1);
         SendMessageToChatTitleScreen("> Loading 'Title.exe'...");
        yield return new WaitForSeconds(1);
         SendMessageToChatTitleScreen("> Loading 'Title.exe'.");
        yield return new WaitForSeconds(1);
         SendMessageToChatTitleScreen("> Loading 'Title.exe'..");
        yield return new WaitForSeconds(1);
         SendMessageToChatTitleScreen("> Loading 'Title.exe'...");
        yield return new WaitForSeconds(3);
        SendMessageToChatTitleScreen("> Connecting to FishWideWeb...");
        audioSource.PlayOneShot(clips[1]);
        yield return new WaitForSeconds(7);
        SendMessageToChatTitleScreen("> Connected!");
        yield return new WaitForSeconds(2);
        SendMessageToChatTitleScreen("> Welcome to FinuxOS!");
        chatBoxObject.SetActive(true);
        ready = true;
        audioSource.Stop();
        audioSource2.Play();
    }

    public void SendMessageToChatTitleScreen(string text)
    {
         var randomMessage = Random.Range(0, 2);
         audioSource.PlayOneShot(sounds[randomMessage]);
        if (messageList2.Count >= maxMessages)
        {
            Destroy(messageList2[0].textObject.gameObject);
            messageList2.Remove(messageList2[0]);
        }
        Message2 newMessage = new Message2();
        newMessage.text = text;
        GameObject newText = Instantiate(textObject, chatPanel.transform);
        newMessage.textObject = newText.GetComponent<TextMeshProUGUI>();
        newMessage.textObject.text = newMessage.text;
        messageList2.Add(newMessage);
    }
}

[System.Serializable]
public class Message2{
    public string text;
    public TextMeshProUGUI textObject;
}
