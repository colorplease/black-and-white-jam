using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FishNet : MonoBehaviour
{
    GameObject[] wires;
    [SerializeField]wire[] wireScripts; 
    public bool puzzleComplete;
    [SerializeField] TaskManager taskManager;
    [SerializeField] FISHManager fishManager;
    [SerializeField] GameObject[] puzzles;
    [SerializeField] TextMeshProUGUI textButton;
    bool alreadyComplete;
    bool confirmed;
    int currentPuzzle;

    void Awake()
    {
        taskManager = GameObject.FindGameObjectWithTag("TaskManager").GetComponent<TaskManager>();
        fishManager = GameObject.FindGameObjectWithTag("FISH").GetComponent<FISHManager>();
        alreadyComplete = false;
    }
    
    private bool puzzleCheck()
    {
        wires = GameObject.FindGameObjectsWithTag("wire");
        wireScripts = new wire[wires.Length];
        for(int i = 0; i < wires.Length; ++i)
        {
            wireScripts[i] = wires[i].GetComponent<wire>();
            if (wireScripts[i].solved == false)
            {
                return false;
            }
        }
        return true;
    }

    void Update()
    {
        if (puzzleCheck() && confirmed)
        {
            confirmed = false;
            if (currentPuzzle < 3)
            {
            puzzles[currentPuzzle].SetActive(false);
            currentPuzzle++;
            puzzles[currentPuzzle].SetActive(true);
            }
            else
            {
               if (!alreadyComplete)
               {
                   alreadyComplete = true;
                   taskManager.TaskComplete(6);
                   fishManager.SendMessageToChat("> Task Complete! [Fix Fish Network]");
                   puzzles[currentPuzzle].SetActive(false);
                   currentPuzzle++;
                   puzzles[currentPuzzle].SetActive(true);
               }
            }
        }
        else if (!puzzleCheck() && confirmed)
        {
            confirmed = false;
            taskManager.Mistake(30);
            fishManager.SendMessageToChat("> Not Connected [-30m]");
        }

        if (!confirmed)
        {
            textButton.color = Color.white;
        }
    }

    public void Confirm()
    {
        textButton.color = Color.black;
        confirmed = true;
    }
}
