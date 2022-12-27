using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LocalDrive : MonoBehaviour
{
    [SerializeField]TextMeshProUGUI title;
    [SerializeField]WindowDragRedux isFocused;
    public bool canMove;
    // Start is called before the first frame update
    void Start()
    {
        string letterRange = "QWERTYUIOPASDFGHJKLZXCVBNM";
        title.SetText("Local Drive " + letterRange[Random.Range(0, letterRange.Length)].ToString() + ":");

    }

    // Update is called once per frame
    void Update()
    {
        if (isFocused.IsLastSibling())
        {
            canMove = true;
        }
        else
        {
            canMove = false;
        }
    }
}
