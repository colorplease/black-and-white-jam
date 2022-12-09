using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class KeyBoardTester : MonoBehaviour
{
    public Key[] keys;
    [SerializeField]Transform organizer;
    [SerializeField]string currentInput;
    bool pressed;
    bool completed;
    KeyCode inputCurrent;
    [SerializeField]WindowDragRedux isFocused;
    [SerializeField]float keySize;
    [SerializeField]float keySizeMultiplier;
    [SerializeField]GridLayoutGroup organizerLayout;
    [SerializeField]GameObject key;
    [SerializeField]FishManagerRedux fishManager;
    [SerializeField]GameObject winner;
    [SerializeField]GameObject mainBody;

    void OnEnable()
    {
        fishManager = GameObject.FindWithTag("TaskManager").GetComponent<FishManagerRedux>();
        keySize = keySizeMultiplier * fishManager.numberOfKeys;
        organizerLayout.cellSize = new Vector2(organizerLayout.cellSize.x - keySize, organizerLayout.cellSize.y - keySize);
        for(int i=0; i < fishManager.numberOfKeys; i++)
            {
                GameObject currentKey = Instantiate(key, Vector2.zero, Quaternion.identity, organizer);
                currentKey.GetComponentInChildren<TextMeshProUGUI>().fontSize -= keySize * 0.6f;
            }
        keys = GetComponentsInChildren<Key>();
    }

    // Update is called once per frame
    void Update()
    {
        if (keys.Length == 0)
        {
            if(!completed)
            {
                winner.SetActive(true);
                fishManager.TaskComplete();
                Destroy(mainBody, 3f);
                completed = true;
            }
        }
        if (isFocused.IsLastSibling())
        {
            if (!completed)
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
                        fishManager.Mistake(0.25f);
                    }
                }
                if(Input.GetKeyUp(inputCurrent) && pressed)
                {
                    keys[0].Release();
                    pressed = false;
                }
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
