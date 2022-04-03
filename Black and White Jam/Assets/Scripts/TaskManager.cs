using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
// 1: -767.6
// 2: -699.3
// 3: -631.49
// 4: -565.4
// 5: -498.2
// 6: -431.1
// 7: -364.3
// 8: -296.7
   public RectTransform[] shortcuts;
   public GameObject[] shortcutsGameObjects;
   [SerializeField]int currentShortcutInt;
   float xShortCutPos;
   int numberOfShortcuts;
   public Transform shakeaShakea;
   public float shakeDuration;
   public float shakeAmount;
   public float decreaseFactor;
   public bool isMistake;

   Vector3 originalPos;

   void UpdateShortcut()
   {
       shortcutsGameObjects = GameObject.FindGameObjectsWithTag("Shortcut");
       shakeaShakea = GameObject.FindGameObjectWithTag ("ShakeaShakea").GetComponent<RectTransform>();
       shortcuts = new RectTransform[shortcutsGameObjects.Length];
       for(int i = 0; i < shortcutsGameObjects.Length; i++)
       {
           shortcuts[i] = shortcutsGameObjects[i].GetComponent<RectTransform>();
           switch(i)
           {
               case 0:
                {
                    xShortCutPos = -767.6f;
                    break;
                }
                case 1:
                {
                    xShortCutPos = -699.3f;
                    break;
                }
                case 2:
                {
                    xShortCutPos = -631.49f;
                    break;
                }
                case 3:
                {
                    xShortCutPos = -565.4f;
                    break;
                }
                case 4:
                {
                    xShortCutPos = -498.2f;
                    break;
                }
                case 5:
                {
                    xShortCutPos = -431.1f;
                    break;
                }
                case 6:
                {
                    xShortCutPos = -364.3f;
                    break;
                }
                case 7:
                {
                    xShortCutPos = -296.7f;
                    break;
                }
           }
           shortcuts[i].position = new Vector3(xShortCutPos / shakeaShakea.localScale.x, -501.8f / shakeaShakea.localScale.x, 836.0923f);
       }
   }

   void Update()
   {
        UpdateShortcut();   
        MistakeHappening();    
   }

    void MistakeHappening()
   {
       if (isMistake)
       {
           if (shakeDuration > 0)
           {
               shakeaShakea.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;

               shakeDuration -= Time.deltaTime * decreaseFactor;
           }
           else
           {
               shakeDuration = 0f;
               shakeaShakea.localPosition = originalPos;
           }
       }
   }

   public void Mistake()
   {
       originalPos = shakeaShakea.localPosition;
       shakeDuration = 0.25f;
       isMistake = true;
   }
   }

