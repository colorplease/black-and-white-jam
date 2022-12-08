using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FishManagerRedux : MonoBehaviour
{
    [Header("Important")]
    public int difficulty;
    public float KP;
    public float income;
    [SerializeField]RectTransform shakeaShakea;
    Vector3 originalPos;
    bool isMistake;
    [SerializeField]float shakeAmount, decreaseFactor, shakeDuration;
    KPReadout kpReadout;

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
        BoringAssInitializationShit();
    }

    void BoringAssInitializationShit()
    {
        originalPos = shakeaShakea.localPosition;
        kpReadout = GetComponent<KPReadout>();
    }
    void UpdateKP(float newKP)
    {
        KP += newKP;
        KPText.SetText(KP.ToString());
    }

    void IncreaseDifficulty()
    {
        difficulty++;
        numberOfKeys += 2 * difficulty;
    }

    void ScreenShake()
    {
        if (isMistake)
        {
            if (shakeDuration > 0)
           {
               shakeaShakea.localPosition = originalPos + UnityEngine.Random.insideUnitSphere * shakeAmount;

               shakeDuration -= Time.deltaTime * decreaseFactor;
           }
           else
           {
               shakeDuration = 0f;
               shakeaShakea.localPosition = originalPos;
           }
        }
    }

    void Mistake(float duration)
    {
        shakeDuration = duration;
        isMistake = true;
    }

    public void TaskComplete()
    {
        kpReadout.SendMessageToChat("Complete [+" + income.ToString() + "KP]");
        UpdateKP(income);
    }

    // Update is called once per frame
    void Update()
    {
        ScreenShake();
        if (Input.GetKeyDown(KeyCode.K))
        {
            IncreaseDifficulty();
            Mistake(0.25f);
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            UpdateKP(5);
        }
    }
}
