using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FishManagerRedux : MonoBehaviour
{
    [Header("Difficulty")]
    public int difficulty;
    public float KP;
    public float income;
    public float penalty;
    public float quota;

    [Header("Important")]
    public AudioSource audioSource;
    [SerializeField]float currentQuotaComplete;
    [SerializeField]TextMeshProUGUI KPText;
    [SerializeField]TextMeshProUGUI quotaText;

    [Header("Random")]
    [SerializeField]Slider quotaMeter;
    [SerializeField]RectTransform shakeaShakea;
    [SerializeField]RectTransform windows;
    Vector3 originalPos;
    bool isMistake;
    [SerializeField]float shakeAmount, decreaseFactor, shakeDuration;
    KPReadout kpReadout;

    [Header("Keyboard Tester")]
    public int numberOfKeys;

    [Header("Local Drive")]
    public float minSpeed;
    public float maxSpeed;
    public float minWait;
    public float maxWait;

    public int virusFiles;
    public int normalFiles;

    [Header("OS SFX")]
    public AudioClip neg1;
    public AudioClip neg2;
    public AudioClip neg3;
    public AudioClip pos1;
    public AudioClip pos2;
    public AudioClip pos3;

    [Header("Windows")]
    public GameObject keyTester;


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
        audioSource = GetComponent<AudioSource>();
    }

    void UpdateKP(float newKP)
    {
        Mathf.Clamp(Mathf.Floor(KP += newKP), 0, Mathf.Infinity);
        KPText.SetText(KP.ToString());
    }

    void UpdateQuota(float quotaIncrease)
    {
        currentQuotaComplete += quotaIncrease;
        quotaMeter.value = currentQuotaComplete / quota;
        quotaText.SetText(Mathf.Floor((currentQuotaComplete / quota) * 100).ToString() + "%");
    }

    void IncreaseDifficulty()
    {
        difficulty++;
        currentQuotaComplete = 0;
        quota += 2;
        income += 5;
        penalty = Mathf.Floor(income * 0.3f);
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

    public void Mistake(float duration)
    {
        kpReadout.SendMessageToChat("Failure [-" + penalty.ToString() + "KP]");
        UpdateKP(-penalty);
        shakeDuration = duration;
        isMistake = true;
        var randomSound = Random.Range(0,2);
        AudioClip[] sus = {neg1,neg2,neg3};
        PlaySound(sus[randomSound], 0.5f);
    }

    public void TaskComplete()
    {
        kpReadout.SendMessageToChat("Complete [+" + income.ToString() + "KP]");
        UpdateKP(income);
        UpdateQuota(1);
        var randomSound = Random.Range(0,2);
        AudioClip[] sus = {pos1, pos2, pos3};
        PlaySound(sus[randomSound], 0.5f);
    }

    public void PlaySound(AudioClip sound, float volume)
    {
        audioSource.PlayOneShot(sound, volume);
    }

    // Update is called once per frame
    void Update()
    {
        ScreenShake();
        if (Input.GetKeyDown(KeyCode.K))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                //IncreaseDifficulty();
                Instantiate(keyTester, new Vector3(Random.Range(-4.47f, 5.42f), Random.Range(-3.13f, 1.9f), 0), Quaternion.identity, windows);
                //Mistake(0.25f);
            }
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            UpdateKP(5);
        }
    }
}
