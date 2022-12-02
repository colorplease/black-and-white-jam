using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class captchaSelect : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler
{
    public Sprite selected;
    public Sprite notSelected;
    public bool selectedBool;
    [SerializeField] Captcha captcha;
    int tap1;
    int tap2;
    int tap3;
    public AudioSource audioSource;
    public AudioClip[] sounds;

    void Awake()
    {
        audioSource = GameObject.FindGameObjectWithTag("TaskManager").GetComponent<AudioSource>();
    }

   public void OnPointerEnter(PointerEventData pointerEventData)
   {
       transform.SetAsLastSibling();
   }

   public void OnPointerDown(PointerEventData pointerEventData)
   {
       var randomSound = Random.Range(0,3);
       audioSource.PlayOneShot(sounds[randomSound]);
       tap3 += 1;
       if (tap3 == 1)
       {
           gameObject.GetComponent<Image>().sprite = selected;
           selectedBool = true;
       }
       else
       {
           gameObject.GetComponent<Image>().sprite = notSelected;
           selectedBool = false;
           tap3 = 0;
       }
   }

   public void yesfish()
   {
       tap1 += 1;
       if (tap1 == 1)
       {
           captcha.fishPoints++;
       }
       else
       {
           captcha.fishPoints--;
           tap1 = 0;
       }
   }

   public void notfish()
   {
       tap2 += 1;
       if (tap2 == 1)
       {
           captcha.fishPoints--;
       }
       else
       {
           captcha.fishPoints++;
           tap2 = 0;
       }
   }

   void Update()
   {
       if (selectedBool)
       {
            transform.SetAsLastSibling();
       }

       if (captcha.fishClickReset)
       {
           gameObject.GetComponent<Image>().sprite = notSelected;
           selectedBool = false;
           tap3 = 0;
           tap2 = 0;
           tap1 = 0;
       }
   }
}
