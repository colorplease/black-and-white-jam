using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class File : MonoBehaviour, IPointerDownHandler
{
    [SerializeField]float speed;
    [SerializeField]Vector3 move;
    public float waitTime;
    [SerializeField]bool isVirus;
    [SerializeField]Crosshair crossHair;
    public Animator animator;
    [SerializeField]bool canMove;
    [SerializeField]TextMeshProUGUI text;
    void Awake()
    {
        StartCoroutine(moveit());
        if (isVirus)
        {
            text.text = crossHair.virusList[Random.Range(0, crossHair.virusList.Length)];   
        }
        else
        {
            text.text = crossHair.fileList[Random.Range(0, crossHair.fileList.Length)]; 
        }
    }

    void Update()
    {
        if (canMove)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, move, speed);
        }

        if (crossHair.done == true)
        {
            canMove = false;
        }
        
    }

    IEnumerator moveit()
    {
        waitTime = Random.Range(0.5f, 3f);
        speed = Random.Range(0.5f, 1);
        move = new Vector3(Random.Range(-1449.83f, -307.8f), Random.Range(-1283f, -719.5f), 1);
        yield return new WaitForSeconds(waitTime);
        StartCoroutine(moveit());
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (!crossHair.done)
        {
            if (isVirus)
        {
            crossHair.VirusDeleted();
        }
        else
        {
            crossHair.FileDeleted();
        }
        animator.SetBool("explode", true);
        Destroy(gameObject, 0.6f);
        }
    }
}