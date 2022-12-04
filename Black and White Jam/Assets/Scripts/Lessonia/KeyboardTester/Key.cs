using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Key : MonoBehaviour
{
    public string letterID;
    [SerializeField]TextMeshProUGUI letter;
    [SerializeField]Image border;
    [SerializeField]Sprite borderPressedSprite;
    [SerializeField]Sprite borderUnpressedSprite;

    // Start is called before the first frame update
    void Start()
    {
        string st = "QWERTYUIOPASDFGHJKLZXCVBNM";
        letterID = st[Random.Range(0,st.Length)].ToString();
        letter.SetText(letterID);
    }

    public void Pressed()
    {
        border.sprite = borderPressedSprite;
        letter.color = Color.black;
    }

    public void Release()
    {
        border.sprite = borderUnpressedSprite;
        letter.color = Color.white;
        Destroy(gameObject);
    }
}
