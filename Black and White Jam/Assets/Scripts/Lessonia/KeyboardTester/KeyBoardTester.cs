using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBoardTester : MonoBehaviour
{
    public Key[] keys;
    [SerializeField]Transform organizer;
    [SerializeField]string currentInput;
    bool pressed;
    KeyCode inputCurrent;
    [SerializeField]WindowDragRedux isFocused;
    // Start is called before the first frame update
    void Start()
    {
        keys = GetComponentsInChildren<Key>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isFocused.IsLastSibling())
        {
            GetNewKey();
            if (Input.anyKeyDown && !(Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(2)))
            {
                if(Input.GetKeyDown(inputCurrent))
                {
                    keys[0].Pressed();
                    pressed = true;
                }
            else
                {
                    Debug.Log("L");
                }
            }
            if(Input.GetKeyUp(inputCurrent) && pressed)
            {
                keys[0].Release();
                pressed = false;
            }
        }
    }

    void GetNewKey()
    {
        currentInput = keys[0].letterID;
        inputCurrent = (KeyCode)System.Enum.Parse(typeof(KeyCode), currentInput);
        keys = GetComponentsInChildren<Key>();
    }
}
