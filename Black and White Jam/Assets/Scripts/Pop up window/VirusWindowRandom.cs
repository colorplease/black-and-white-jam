using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusWindowRandom : MonoBehaviour
{
    [SerializeField] private GameObject[] gameObjects;

    public GameObject GetRandomWindow()
    {
        int index = Random.Range(0, gameObjects.Length);
        return gameObjects[index];
    }
}
