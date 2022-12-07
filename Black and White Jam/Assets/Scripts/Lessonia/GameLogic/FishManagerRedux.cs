using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FishManagerRedux : MonoBehaviour
{
    [Header("Important")]
    public int difficulty;
    public float KP;

    [Header("Random")]
    [SerializeField]TextMeshProUGUI KPText;

    [Header("Keyboard Tester")]
    public int numberOfKeys;


    void Awake()
    {
        UpdateKP(0);
    }

    void OnEnable()
    {
        numberOfKeys += 2 * difficulty;
    }
    void UpdateKP(float newKP)
    {
        KP = newKP;
        KPText.SetText(KP.ToString());
    }

    void IncreaseDifficulty()
    {
        difficulty++;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            IncreaseDifficulty();
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            UpdateKP(KP + 5);
        }
    }
}
