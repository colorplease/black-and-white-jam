using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Captcha : MonoBehaviour
{
    [SerializeField]GameObject YESFISH;
    [SerializeField]GameObject NOTFISH;
    [SerializeField]GameObject[] set;
    [SerializeField]GameObject fishQuestions;
    [SerializeField] TaskManager taskManager;
    [SerializeField] FISHManager fishManager;
    [SerializeField] int currentSet;
    [SerializeField]GameObject clickFish;
    [SerializeField] TextMeshProUGUI confirmText;
    [SerializeField]GameObject confirmButton;
    [SerializeField]GameObject captchaType;
    [SerializeField]GameObject end;
    public int fishPoints;
    public bool fishClickReset;

    void Awake()
    {
        taskManager = GameObject.FindGameObjectWithTag("TaskManager").GetComponent<TaskManager>();
        fishManager = GameObject.FindGameObjectWithTag("FISH").GetComponent<FISHManager>();
    }

    public void YES()
    {
        StartCoroutine(yes());
    }

    public void NOT()
    {
        StartCoroutine(not());
    }

    public void Confirm()
   {
       confirmText.color = Color.black;
       if (fishPoints == 5)
       {
           StartCoroutine(yesfish());
       }
       else
       {
           StartCoroutine(notfish());
       }
   }

   IEnumerator yesfish()
   {
       clickFish.SetActive(false);
       YESFISH.SetActive(true);
       yield return new WaitForSeconds(1.5f);
       YESFISH.SetActive(false);
       captchaType.SetActive(true);

   }

   IEnumerator notfish()
   {
       
       fishPoints = 0;
       confirmButton.GetComponent<Image>().color = Color.white;
       fishClickReset = true;
       clickFish.SetActive(false);
       NOTFISH.SetActive(true);
       taskManager.Mistake(60);
       fishManager.SendMessageToChat("> not fish [-60m]");
       yield return new WaitForSeconds(1.5f);
       confirmText.color = Color.white;
       confirmButton.GetComponent<Image>().color = Color.black;
       clickFish.SetActive(true);
       NOTFISH.SetActive(false);
       yield return new WaitForSeconds(0.01f);
       fishClickReset = false;
   }

   public void wrongFish()
   {
       StartCoroutine(wrongfish());
   }

   public void rightFish()
   {
       StartCoroutine(rightfish());
   }

   IEnumerator wrongfish()
   {
       captchaType.SetActive(false);
       NOTFISH.SetActive(true);
       yield return new WaitForSeconds(1.5f);
       captchaType.SetActive(true);
       NOTFISH.SetActive(false);
   }

   IEnumerator rightfish()
   {
       captchaType.SetActive(false);
       YESFISH.SetActive(true);
       yield return new WaitForSeconds(1.5f);
       YESFISH.SetActive(false);
       end.SetActive(true);
   }

    IEnumerator yes()
    {
        set[currentSet].SetActive(false);
        YESFISH.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        YESFISH.SetActive(false);
        if (currentSet + 1 < set.Length)
        {
            currentSet++;
            set[currentSet].SetActive(true);
        }
        else
        {
            fishQuestions.SetActive(false);
            clickFish.SetActive(true);
        }
    }

    IEnumerator not()
    {
        set[currentSet].SetActive(false);
        NOTFISH.SetActive(true);
        taskManager.Mistake(60);
        fishManager.SendMessageToChat("> not fish [-60m]");
        yield return new WaitForSeconds(1.5f);
        currentSet = 0;
        set[currentSet].SetActive(true);
        NOTFISH.SetActive(false);
        
    }


}
