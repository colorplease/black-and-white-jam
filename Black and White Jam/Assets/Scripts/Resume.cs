using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Resume : MonoBehaviour
{
    public TMP_InputField inputField;
    [SerializeField] GameObject granted;
    [SerializeField] GameObject denied;
    [SerializeField] GameObject fish;
    [SerializeField] GameObject fish1;
    [SerializeField] TaskManager taskManager;
    [SerializeField] FISHManager fishManager;
    public GameObject windowToOpen;
    public RectTransform Canvas;
    public Transform shakeaShakea;


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
            if (passwordTry.Equals("9215"))
            {
                StartCoroutine(AccessGranted());
            }
            else if (passwordTry.Equals("fish"))
            {
                StartCoroutine(fish2());
                fishManager.SendMessageToChat("> fish?");
            }
            else
            {
                StartCoroutine(AccessDenied());
                taskManager.Mistake();
                fishManager.SendMessageToChat("> Incorrect Input [-5s]");
            }
        }
    }

    IEnumerator AccessGranted()
    {
        fish.SetActive(false);
        granted.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        fish.SetActive(true);
        granted.SetActive(false);
        GameObject window = Instantiate(windowToOpen, new Vector3(Random.Range(-100, 100) / shakeaShakea.localScale.x, Random.Range(-87, 155), 0)/shakeaShakea.localScale.y, transform.rotation);
        window.transform.localScale = new Vector3(window.transform.localScale.x / shakeaShakea.localScale.x, window.transform.localScale.y / shakeaShakea.localScale.y, 1f);
        window.transform.SetParent(shakeaShakea); 
        taskManager.TaskComplete(1);
        fishManager.SendMessageToChat("> Task Completed! [Find Resume]");
        Destroy(gameObject);
    }

    IEnumerator AccessDenied()
    {
        fish.SetActive(false);
        denied.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        fish.SetActive(true);
        denied.SetActive(false);
    }

    IEnumerator fish2()
    {
        fish.SetActive(false);
        fish1.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        fish.SetActive(true);
        fish1.SetActive(false);
    }
}
