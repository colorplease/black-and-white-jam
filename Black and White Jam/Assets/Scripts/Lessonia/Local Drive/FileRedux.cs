using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FileRedux : MonoBehaviour, IPointerDownHandler
{
    [SerializeField]LocalDrive localDrive;
    [SerializeField]FishManagerRedux fishManager;
    [SerializeField]Vector3 move;
    float speed;
    public void OnPointerDown(PointerEventData eventData)
    {

    }
    // Start is called before the first frame update
    void OnEnable()
    {
        localDrive = GetComponentInParent<LocalDrive>();
        fishManager = GameObject.FindWithTag("TaskManager").GetComponent<FishManagerRedux>();
        StartCoroutine(moving());
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
