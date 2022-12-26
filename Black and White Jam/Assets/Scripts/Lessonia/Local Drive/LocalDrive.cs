using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LocalDrive : MonoBehaviour
{
    [SerializeField]TextMeshProUGUI title;
    // Start is called before the first frame update
    void Start()
    {
        string letterRange = "QWERTYUIOPASDFGHJKLZXCVBNM";
        title.SetText("Local Drive " + letterRange[Random.Range(0, letterRange.Length)].ToString() + ":");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
