using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
[RequireComponent(typeof(Interpreter))]
public class TerminalManager : MonoBehaviour
{
    public GameObject directoryLine;
    public GameObject responseLine;

    public TMP_InputField terminalInput;
    public GameObject userInputLine;
    public GameObject msgList;
    public ScrollRect scrollRect;

    private Interpreter interpreter;

    private void Start()
    {
        interpreter = GetComponent<Interpreter>();
    }

    private void OnGUI()
    {
        if (terminalInput.isFocused && terminalInput.text != "" && 
            (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter)))
        {
            //Store whatever the user typed
            string userInput = terminalInput.text;

            //Clear input field
            ClearInputField();

            //Instantiate gameobject
            AddLine(userInput);

            //Add interpretation lines
            AddInterpreterLines(interpreter.Interpret(userInput));

            userInputLine.transform.SetAsLastSibling();

            terminalInput.ActivateInputField();
            terminalInput.Select();
        }
    }

    void ClearInputField()
    {
        terminalInput.text = "";
    }

    void AddLine(string userInput)
    {
        //Resizing command line
        Vector2 msgListSize = msgList.GetComponent<RectTransform>().sizeDelta;
        msgList.GetComponent<RectTransform>().sizeDelta = new Vector2(msgListSize.x, msgListSize.y + 20f);

        GameObject msg = Instantiate(directoryLine, msgList.transform);

        msg.transform.SetSiblingIndex(msgList.transform.childCount - 1);
        msg.GetComponentsInChildren<TMP_Text>()[1].text = userInput;
    }

    void AddInterpreterLines(List<string> interpretation)
    {
        for (int i = 0; i < interpretation.Count; i++)
        {
            GameObject res = Instantiate(directoryLine, msgList.transform);
            res.transform.SetAsLastSibling();

            Vector2 listSize = msgList.GetComponent<RectTransform>().sizeDelta;

            msgList.GetComponent<RectTransform>().sizeDelta = new Vector2(listSize.x, listSize.y + 20f);

            res.GetComponentsInChildren<TMP_Text>()[1].text = interpretation[i];
        }
    }

    void ScrollToBottom()
    {
        if (userInputLine.GetComponent<RectTransform>().position.y < msgList.GetComponent<RectTransform>().sizeDelta.y)
            scrollRect.verticalNormalizedPosition = 0;
            //scrollRect.velocity = new Vector2(0, 450f);
    }
}
