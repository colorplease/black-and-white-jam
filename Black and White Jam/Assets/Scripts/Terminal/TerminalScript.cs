using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TerminalScript : MonoBehaviour
{
    [SerializeField] private GameObject[] gameObjects;
    [SerializeField] private float timeNextActive;
    [SerializeField] private TerminalManager terminalManager;
    [SerializeField] private TMP_InputField inputField;

    private float _nowTime;
    private bool _isActive;
    private int _index;

    private void Start()
    {
        terminalManager = GetComponent<TerminalManager>();
        terminalManager.enabled = false;
        inputField.transform.parent.gameObject.SetActive(false);

        _nowTime = Time.time;
        _isActive = false;
        _index = 0;
    }

    void Update()
    {
        if ((Input.GetMouseButtonDown(0) || _isActive) && _index < gameObjects.Length)
        {
            _isActive = true;
            if (_nowTime + timeNextActive < Time.time)
            {
                gameObjects[_index].SetActive(true);
                _nowTime = Time.time;
                _index++;
            }
        }

        if (_index == gameObjects.Length)
        {
            this.enabled = false;
            terminalManager.enabled = true;
            inputField.transform.parent.gameObject.SetActive(true);
            inputField.ActivateInputField();
            inputField.Select();
        }
    }
}
