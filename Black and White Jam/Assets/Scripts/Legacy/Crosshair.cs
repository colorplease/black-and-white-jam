using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    [SerializeField]Texture2D cursor;
    [SerializeField] TaskManager taskManager;
    [SerializeField] FISHManager fishManager;
    [SerializeField]GameObject[] viruses;
    [SerializeField]GameObject[] waves;
    public string[] virusList;
    public string[] fileList;
    bool alreadyComplete;
    public bool done;
    bool switchingWaves;
    [SerializeField]int waveNumber;

    void Awake()
    {
        done = false;
        taskManager = GameObject.FindGameObjectWithTag("TaskManager").GetComponent<TaskManager>();
        fishManager = GameObject.FindGameObjectWithTag("FISH").GetComponent<FISHManager>();
    }

   public void VirusDeleted()
   {
       viruses = GameObject.FindGameObjectsWithTag("virus");
       if (viruses.Length == 1 && !switchingWaves)
       {
           if (!alreadyComplete && waveNumber == 3)
           {
               taskManager.TaskComplete(5);
               fishManager.SendMessageToChat("> Task Completed! [Clean Up Junk]");
               done = true;
               alreadyComplete = true;
        if (waveNumber < 3)
        {
            StartCoroutine(nextWave());
        }
    }
       }
           
   }

   void Update()
   {
       viruses = GameObject.FindGameObjectsWithTag("virus");
       if (viruses.Length == 0 && !switchingWaves)
       {
           if (!alreadyComplete && waveNumber == 3)
           {
               taskManager.TaskComplete(5);
               fishManager.SendMessageToChat("> Task Completed! [Clean Up Junk]");
               done = true;
               alreadyComplete = true;
           }
           if (waveNumber < 3)
        {
            StartCoroutine(nextWave());
        }
       }
   }

   public void FileDeleted()
   {
       taskManager.Mistake(30);
       fishManager.SendMessageToChat("> not a virus[30m]");
   }

   IEnumerator nextWave()
  {
            switchingWaves = true;
            done = true;
            fishManager.SendMessageToChat("> There's more...");
            yield return new WaitForSeconds(1f);
            waves[waveNumber].SetActive(false);
            waveNumber++;
            waves[waveNumber].SetActive(true);
            done = false;
            switchingWaves = false;
   }
}
