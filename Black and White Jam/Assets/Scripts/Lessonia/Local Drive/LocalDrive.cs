using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LocalDrive : MonoBehaviour
{
    [SerializeField]TextMeshProUGUI title;
    [SerializeField]WindowDragRedux isFocused;
    public bool canMove;
    FishManagerRedux fishManager;
    [SerializeField]AudioClip[] destoryed;
    [SerializeField]GameObject virusFile;
    [SerializeField]GameObject file;
    [SerializeField]Transform files;
    [SerializeField]GameObject mainBody;
    [SerializeField]GameObject winner;
    [SerializeField]int virusQuota;
    public string[] virusNames;
    public string[] fileNames;
    // Start is called before the first frame update
    void OnEnable()
    {
        string letterRange = "QWERTYUIOPASDFGHJKLZXCVBNM";
        title.SetText("Local Drive " + letterRange[Random.Range(0, letterRange.Length)].ToString() + ":");
        fishManager = GameObject.FindWithTag("TaskManager").GetComponent<FishManagerRedux>();
        for (int i = 0; i < fishManager.virusFiles; i++)
        {
            GameObject virus = Instantiate(virusFile, Vector3.zero, Quaternion.identity, files);
            virus.transform.localPosition = new Vector3(Random.Range(-374, 376.3f), Random.Range(-222.9f, 193.3f), 0);
        }
        for (int i = 0; i < fishManager.normalFiles; i++)
        {
            GameObject fileObject = Instantiate(file, Vector3.zero, Quaternion.identity, files);
            fileObject.transform.localPosition = new Vector3(Random.Range(-374, 376.3f), Random.Range(-222.9f, 193.3f), 0);
        }
        virusQuota = fishManager.virusFiles;

    }

    // Update is called once per frame
    void Update()
    {
        if (isFocused.IsLastSibling())
        {
            canMove = true;
        }
        else
        {
            canMove = false;
        }
    }

    public void virusDestroyed()
    {
        var randomSound = Random.Range(0,3);
        fishManager.PlaySound(destoryed[randomSound], 0.7f);
        virusQuota--;
        if (virusQuota == 0)
        {
            fishManager.TaskComplete();
            winner.SetActive(true);
            files.gameObject.SetActive(false);
            Destroy(mainBody, 3f);

        }
        
    }

    public void normalDestroyed()
    {
        var randomSound = Random.Range(0,3);
        fishManager.PlaySound(destoryed[randomSound], 0.7f);
        fishManager.Mistake(0.25f);
    }
}
