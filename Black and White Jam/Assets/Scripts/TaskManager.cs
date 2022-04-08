using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.SceneManagement;

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
   [SerializeField] Transform notePad;
   GameObject[] shortcutsGameObjects;
   GameObject[] crossOutsGameObjects;
   public GameObject ToDo;
   public GameObject ToDoShortcut;
   public Image[] crossOuts;
   [SerializeField]int currentShortcutInt;
   float xShortCutPos;
   int numberOfShortcuts;
   public Transform shakeaShakea;
   public float shakeDuration;
   public float shakeAmount;
   public float decreaseFactor;
   public bool isMistake;
   public int numberOfTasksCompleted;
   public float currentTime;
   public float timeSpeed;
   public TextMeshProUGUI currentTimeText;
   public bool clockActive;
   bool secondTimeAround;
   public GameObject[] everything;
   public GameObject loss;
   public int loopNumber;
   FISHManager fishManager;
   bool win;
   bool fast;
   bool lose;
   bool lost;
   public int SceneNumber;


   Vector3 originalPos;

   void Awake()
   {
       lose = false;
       timeSpeed = 0;
       shakeaShakea = GameObject.FindGameObjectWithTag ("ShakeaShakea").GetComponent<RectTransform>();
       crossOutsGameObjects = GameObject.FindGameObjectsWithTag("CrossOut");
       fishManager = GameObject.FindGameObjectWithTag("FISH").GetComponent<FISHManager>();
       crossOuts = new Image[crossOutsGameObjects.Length];
       for (int i = 0; i < crossOutsGameObjects.Length; i++)
       {
           crossOuts[i] = crossOutsGameObjects[i].GetComponent<Image>();
           var tempColor = crossOuts[i].color;
           tempColor.a = 0f;
           crossOuts[i].color = tempColor;
       }

       if (!fishManager.tutorial)
       {
           for (int i = 0; i < everything.Length; i++)
            {
           everything[i].SetActive(false);
            }
       }
       
   }

   public void UpdateToDoList()
   {
        crossOutsGameObjects = GameObject.FindGameObjectsWithTag("CrossOut");
       crossOuts = new Image[crossOutsGameObjects.Length];
       for (int i = 0; i < crossOutsGameObjects.Length; i++)
       {
           crossOuts[i] = crossOutsGameObjects[i].GetComponent<Image>();
           var tempColor = crossOuts[i].color;
           tempColor.a = 0f;
           crossOuts[i].color = tempColor;
       }
   }

   public void StartGame()
   {
       timeSpeed = 0.2f;
       for (int i = 0; i < everything.Length; i++)
       {
           everything[i].SetActive(true);
       }
   }

   public void EndGame()
   {
       timeSpeed = 0.2f;
       for (int i = 0; i < everything.Length; i++)
       {
           everything[i].SetActive(false);
       }
       Mistake(0);
   }

   public void NextLoop()
   {
       SceneManager.LoadScene(SceneNumber);
   }

   void UpdateShortcut()
   {
       shortcutsGameObjects = GameObject.FindGameObjectsWithTag("Shortcut");
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
        Clock();
        CompletionCheck();
   }

   void CompletionCheck()
   {
       if (numberOfTasksCompleted == 6 && win == false && loopNumber > 3 && lose == false)
       {
           win = true;
       }
       else if (numberOfTasksCompleted == 5 && fast == false && loopNumber < 3 && clockActive == false)
       {
           Mistake(155);
           fishManager.SendMessageToChat("> KatF!sh: TO FAST, TOO SOON [-155m]");
           fast = true;
       }

       if (lose && !lost)
       {
           PlayerPrefs.SetInt("Losses", PlayerPrefs.GetInt("Losses") + 1);
           PlayerPrefs.SetInt("Loops", PlayerPrefs.GetInt("Loops") + 1);  
           EndGame();
           GameObject window = Instantiate(loss, new Vector3(UnityEngine.Random.Range(-100, 100) / shakeaShakea.localScale.x, UnityEngine.Random.Range(-87, 155), 0)/shakeaShakea.localScale.y, transform.rotation);
            window.transform.localScale = new Vector3(window.transform.localScale.x / shakeaShakea.localScale.x, window.transform.localScale.y / shakeaShakea.localScale.y, 1f);
            window.transform.SetParent(shakeaShakea);
            lose = false;
            lost = true;
       }
   }

   void Clock()
   {
       if (clockActive == true)
       {
           currentTime += Time.fixedDeltaTime * timeSpeed;
           int minutes = Mathf.FloorToInt(currentTime / 60.0f);
           int seconds = Mathf.FloorToInt(currentTime - minutes * 60);
           currentTimeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
           if (currentTime > 779)
           {
               currentTime = 0f;
               secondTimeAround = true;
           }
           else if (currentTime > 300 && secondTimeAround == true)
           {
               clockActive = false;
               secondTimeAround = false;
           }
       }
       else
       {
           lose = true;
       }
   }

    void MistakeHappening()
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
               isMistake = false;
           }
       }
   }

   public void Mistake(float timeLost)
   {
       originalPos = shakeaShakea.localPosition;
       shakeDuration = 0.25f;
       isMistake = true;
       currentTime += timeLost;
   }

    public void TaskComplete(int taskNumber)
    {
        var tempColor2 = crossOuts[taskNumber].color;
        tempColor2.a = 1f;
        crossOuts[taskNumber].color = tempColor2;
        numberOfTasksCompleted++;
        notePad.SetAsLastSibling();
        
    }
   }

