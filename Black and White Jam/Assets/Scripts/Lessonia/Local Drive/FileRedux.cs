using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class FileRedux : MonoBehaviour, IPointerDownHandler
{
    LocalDrive localDrive;
    FishManagerRedux fishManager;
    Vector3 move;
    [SerializeField]bool isVirus;
    float speed;
    TextMeshProUGUI fileName;

    [SerializeField]Animator animator;
    public void OnPointerDown(PointerEventData eventData)
    {
        animator.SetBool("destroyed", true);
        if (isVirus)
        {
            localDrive.virusDestroyed();
        }
        else
        {
            localDrive.normalDestroyed();
        }
        Destroy(gameObject, 0.55f);
    }
    // Start is called before the first frame update
    void OnEnable()
    {
        localDrive = GetComponentInParent<LocalDrive>();
        fileName = GetComponentInChildren<TextMeshProUGUI>();
        RandomFileName(isVirus);
        fishManager = GameObject.FindWithTag("TaskManager").GetComponent<FishManagerRedux>();
        StartCoroutine(moving());
    }

    void RandomFileName(bool isVirus)
    {
        if (isVirus)
        {
            var randomName = Random.Range(0, localDrive.virusNames.Length);
            fileName.SetText(localDrive.virusNames[randomName] + ".virus");
        }
        else
        {
            var randomName = Random.Range(0, localDrive.fileNames.Length);
            fileName.SetText(localDrive.fileNames[randomName] + ".fish");
        }
    }

    void FixedUpdate()
    {
        if(localDrive.canMove)
        {
            transform.localPosition = Vector2.MoveTowards(transform.localPosition, move, speed);
        }
    }

    IEnumerator moving()
    {
        float waitTime = Random.Range(fishManager.minWait, fishManager.maxWait);
        speed = Random.Range (fishManager.minSpeed, fishManager.maxSpeed);
        move = new Vector3(Random.Range(-374, 376.3f), Random.Range(-222.9f, 193.3f), 0);
        yield return new WaitForSeconds(waitTime);
        StartCoroutine(moving());
    }
}
