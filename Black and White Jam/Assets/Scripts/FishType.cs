using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FishType : MonoBehaviour
{
    [SerializeField]TMP_InputField inputField;
    [SerializeField]TextMeshProUGUI countWord;
    [SerializeField]TextMeshProUGUI wordLimitText;
    [SerializeField] TaskManager taskManager;
    [SerializeField] FISHManager fishManager;
    [SerializeField] Animator decorFish;
    [SerializeField]float timeBetweenTypeSpeedCheck;
    [SerializeField]float speedMultiplier;
    [SerializeField]float startTime;
    bool alreadyComplete;
    bool CHEATER;
    int lastWordCount;
    [SerializeField]GameObject words;
    [SerializeField]GameObject cheater;
    [SerializeField]GameObject completedlol;
    public int wordLimit;

    void Awake()
    {
        taskManager = GameObject.FindGameObjectWithTag("TaskManager").GetComponent<TaskManager>();
        fishManager = GameObject.FindGameObjectWithTag("FISH").GetComponent<FISHManager>();
        inputField.characterLimit = wordLimit;
        wordLimitText.text = "/ " + wordLimit.ToString();
        lastWordCount = 0;
        countWord.text = "";
        alreadyComplete = false;
        CHEATER = false;
    }

    void FixedUpdate()
    {
        if (!alreadyComplete)
        {
            countWord.text = inputField.text.Length.ToString();
        }

        if (timeBetweenTypeSpeedCheck > 0)
        {
            timeBetweenTypeSpeedCheck -= Time.fixedDeltaTime;
        }
        else
        {
            timeBetweenTypeSpeedCheck = 0.05f;
            var wordDiff = inputField.text.Length - lastWordCount;
            decorFish.speed = Mathf.Clamp(wordDiff * speedMultiplier, 0, 100);
            if (wordDiff > 150)
            {
                if (!CHEATER)
                {
                    taskManager.Mistake(120);
                    fishManager.SendMessageToChat("> CHEATING CHEATING CHEATING [-120m]");
                    words.SetActive(false);
                    cheater.SetActive(true);
                    CHEATER = true;
                }
            }
            else
            {
                if (inputField.text.Length >= wordLimit && !alreadyComplete && CHEATER == false)
        {
            taskManager.TaskComplete(0);
            fishManager.SendMessageToChat("> Task Completed! [Draft a Report]");
            words.SetActive(false);
            completedlol.SetActive(true);
            alreadyComplete = true;
        }
            }
            lastWordCount = inputField.text.Length;
            timeBetweenTypeSpeedCheck = startTime;
        }

    }
}
