using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    [SerializeField]Texture2D cursor;
    [SerializeField] TaskManager taskManager;
    [SerializeField] FISHManager fishManager;
    [SerializeField]GameObject[] viruses;
    public string[] virusList;
    public string[] fileList;
    bool alreadyComplete;
    public bool done;

    void Awake()
    {
        done = false;
        taskManager = GameObject.FindGameObjectWithTag("TaskManager").GetComponent<TaskManager>();
        fishManager = GameObject.FindGameObjectWithTag("FISH").GetComponent<FISHManager>();
    }

   public void VirusDeleted()
   {
       viruses = GameObject.FindGameObjectsWithTag("virus");
       if (viruses.Length == 1)
       {
           if (!alreadyComplete)
           {
               taskManager.TaskComplete(5);
               fishManager.SendMessageToChat("> Task Completed! [Clean Up Junk]");
               done = true;
               alreadyComplete = true;
           }
       }
   }

   void Update()
   {
       viruses = GameObject.FindGameObjectsWithTag("virus");
       if (viruses.Length == 0)
       {
           if (!alreadyComplete)
           {
               taskManager.TaskComplete(5);
               fishManager.SendMessageToChat("> Task Completed! [Clean Up Junk]");
               done = true;
               alreadyComplete = true;
           }
       }
   }

   public void FileDeleted()
   {
       taskManager.Mistake(30);
       fishManager.SendMessageToChat("> not a virus[30m]");
   }
}
