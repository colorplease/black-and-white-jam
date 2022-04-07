using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishPlace : MonoBehaviour
{
    [SerializeField]GameObject fishPlace;
    
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("recycle") != null)
        {
            fishPlace.SetActive(true);
        }
        else
        {
            fishPlace.SetActive(false);
        }
    }
}
