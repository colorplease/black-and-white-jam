using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishManagerRedux : MonoBehaviour
{
    public int difficulty;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("Difficulty", difficulty);
        print(PlayerPrefs.GetInt("Difficulty"));
    }

    void IncreaseDifficulty()
    {
        difficulty++;
        PlayerPrefs.SetInt("Difficulty", difficulty);
        print(PlayerPrefs.GetInt("Difficulty"));    
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            IncreaseDifficulty();
        }
    }
}
