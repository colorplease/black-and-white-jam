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
    KeyCode inputCurrent;
    [SerializeField]WindowDragRedux isFocused;
    [SerializeField]int numberOfKeys;
    [SerializeField]float keySize;
    [SerializeField]GridLayoutGroup organizerLayout;
    [SerializeField]GameObject key;
    // Start is called before the first frame update
    void Start()
    {
        keys = GetComponentsInChildren<Key>();
    }

    void OnEnable()
    {
            numberOfKeys += 2 * PlayerPrefs.GetInt("Difficulty");
            keySize = 0.8f * PlayerPrefs.GetInt("Difficulty");
            organizerLayout.cellSize = new Vector2(organizerLayout.cellSize.x - keySize, organizerLayout.cellSize.y - keySize);
        for(int i=0; i < numberOfKeys; i++)
            {
                GameObject currentKey = Instantiate(key, Vector2.zero, Quaternion.identity, organizer);
                currentKey.GetComponentInChildren<TextMeshProUGUI>().fontSize -= keySize * 0.6f;
            }
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
