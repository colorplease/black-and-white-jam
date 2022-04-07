using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class wire : MonoBehaviour, IPointerDownHandler
{
    [SerializeField]float[] rotations;
    int rotation;
    [SerializeField]float solution;
    public bool solved;
    [SerializeField] int limitRotations;

    void Awake()
    {
        int rand = Random.Range(0, rotations.Length);
        transform.eulerAngles = new Vector3(0, 0, rotations[rand]);
        if (transform.eulerAngles.z == solution)
        {
            solved = true;
        }
    }
    public void OnPointerDown(PointerEventData pointerEventData)
    {
        if (rotation + 1 < limitRotations)
        {
            rotation++;
        transform.eulerAngles = new Vector3(0, 0, rotations[rotation]);

        if (transform.eulerAngles.z == solution)
        {
            solved = true;
        }
        else
        {
            solved = false;
        }
        }
        else
        {
            rotation = 0;
             transform.eulerAngles = new Vector3(0, 0, rotations[rotation]);

        if (transform.eulerAngles.z == solution)
        {
            solved = true;
        }
        else
        {
            solved = false;
        }
        }
    }
}
