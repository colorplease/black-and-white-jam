using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Resume : MonoBehaviour
{
    public TMP_InputField inputField;

    void Awake()
    {
        inputField.characterLimit = 4;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            string passwordTry = inputField.text;
            if (passwordTry.Equals("9215"))
            {
                print("yes");
            }
        }
    }
}
