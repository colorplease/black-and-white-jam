using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(VirusWindowRandom))] 
public class VirusWIndowSpawner : MonoBehaviour
{
    [SerializeField] private VirusWindowRandom virusWindowRandom;
    [SerializeField] private int minTimeValue = 5;
    [SerializeField] private int maxTimeValue = 10;

    public bool isActive = true;

    private Transform parent;
    private Transform shakeaShakea;
    private int timeToNextSpawn;
    private float nowTime;

    private void Start()
    {
        shakeaShakea = GameObject.FindGameObjectWithTag("ShakeaShakea").GetComponent<RectTransform>();
        virusWindowRandom = GetComponent<VirusWindowRandom>();
        timeToNextSpawn = Random.Range(minTimeValue, maxTimeValue);
        nowTime = Time.time;
        parent = transform;
    }


    void FixedUpdate()
    {
        if (isActive)
        {
            if (nowTime + timeToNextSpawn < Time.time)
            {
                ReloadTime();
                SpawnWindow();
            }
        } else
        {
            ReloadTime();
        }
    }
    private void ReloadTime()
    {
        nowTime = Time.time;
        timeToNextSpawn = Random.Range(minTimeValue, maxTimeValue);
    }

    private Vector3 SpawnPosition()
    {
        float posX = Random.Range(-100, 100);// / shakeaShakea.localScale.x;
        float posY = Random.Range(-87, 155);

        Vector3 pos = new Vector3(posX, posY, 0) / shakeaShakea.localScale.y;

        return pos;
    }

    private Vector3 SpawnScale(Transform window)
    {
        float scaleX = window.localScale.x;
        float scaleY = window.localScale.y;

        Vector3 scale = new Vector3(scaleX, scaleY, 1f);
        return scale;
    }

    public void SpawnWindow()
    {
        GameObject windowPrefab = virusWindowRandom.GetRandomWindow();
        Vector3 pos = SpawnPosition();
        Vector3 scale = SpawnScale(windowPrefab.transform);

        GameObject window = Instantiate(windowPrefab, pos, transform.rotation);
        //window.transform.localScale = scale;
        window.transform.SetParent(parent);
    }
}
