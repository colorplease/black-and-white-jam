using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionFile : MonoBehaviour
{
    void Awake()
    {
        Destroy(gameObject, 1f);
    }
}
