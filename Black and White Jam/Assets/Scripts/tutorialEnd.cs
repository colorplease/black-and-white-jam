using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class tutorialEnd : MonoBehaviour
{
    public TMP_InputField inputField;
    [SerializeField] GameObject granted;
    [SerializeField] GameObject denied;
    [SerializeField] TaskManager taskManager;
    [SerializeField] FISHManager fishManager;
    public GameObject windowToOpen;
    public RectTransform Canvas;
    public Transform shakeaShakea;
    bool alreadyComplete;
    


    void Awake()
    {
        taskManager = GameObject.FindGameObjectWithTag("TaskManager").GetComponent<TaskManager>();
        inputField.characterLimit = 4;
        Canvas = GameObject.Find("Canvas").GetComponent<RectTransform>();
        shakeaShakea = GameObject.FindGameObjectWithTag ("ShakeaShakea").GetComponent<RectTransform>();
        fishManager = GameObject.FindGameObjectWithTag("FISH").GetComponent<FISHManager>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            string passwordTry = inputField.text;
            if (passwordTry.Equals("6822"))
            {
                StartCoroutine(AccessGranted());
            }
            else
            {
                StartCoroutine(AccessDenied());
                taskManager.Mistake(0);
                fishManager.SendMessageToChat("> KatF!sh: Usually when you make a mistake, time gets deducted from your timer, but you're still learning so i won't do that");
            }
        }
    }

    IEnumerator AccessGranted()
    {
        granted.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        granted.SetActive(false);
        GameObject window = Instantiate(windowToOpen, new Vector3(Random.Range(-100, 100) / shakeaShakea.localScale.x, Random.Range(-87, 155), 0)/shakeaShakea.localScale.y, transform.rotation);
        window.transform.localScale = new Vector3(window.transform.localScale.x / shakeaShakea.localScale.x, window.transform.localScale.y / shakeaShakea.localScale.y, 1f);
        window.transform.SetParent(shakeaShakea); 
        taskManager.TaskComplete(0);
        if (!alreadyComplete)
        {
            fishManager.SendMessageToChat("> Task Completed! [Complete Tutorial]");
            fishManager.complete = true;
            alreadyComplete = true;
        }
        Destroy(gameObject);
    }

    IEnumerator AccessDenied()
    {
        denied.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        denied.SetActive(false);
    }

}
