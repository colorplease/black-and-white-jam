using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KatFinTools : MonoBehaviour
{
    [SerializeField]float lowSec;
    [SerializeField]float highSec;
    [SerializeField]GameObject[] adSelection;
    [SerializeField] TaskManager taskManager;
    [SerializeField] FISHManager fishManager;
    public Transform shakeaShakea;
    void OnEnable()
    {
        taskManager = GameObject.FindGameObjectWithTag("TaskManager").GetComponent<TaskManager>();
        fishManager = GameObject.FindGameObjectWithTag("FISH").GetComponent<FISHManager>();
        shakeaShakea = GameObject.FindGameObjectWithTag ("ShakeaShakea").GetComponent<RectTransform>();
        StartCoroutine(fishPopUp());
    }

    public IEnumerator fishPopUp()
    {
        var randomSeconds = Random.Range(lowSec, highSec);
        var randomPopUp = Random.Range(0, adSelection.Length);
        yield return new WaitForSeconds(randomSeconds);
        taskManager.Mistake(0);
        GameObject window = Instantiate(adSelection[randomPopUp], new Vector3(Random.Range(-100, 100) / shakeaShakea.localScale.x, Random.Range(-87, 155), 0)/shakeaShakea.localScale.y, transform.rotation);
        window.transform.localScale = new Vector3(window.transform.localScale.x / shakeaShakea.localScale.x, window.transform.localScale.y / shakeaShakea.localScale.y, 1f);
        window.transform.SetParent(shakeaShakea);
        StartCoroutine(fishPopUp());
    }

    void Start()
    {

    }
}
