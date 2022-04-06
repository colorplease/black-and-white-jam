using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class BootUpController : MonoBehaviour
{
    public GameObject[] bootUpObjects;
    public AudioClip[] audioClips;
    public AudioSource audioSource;
   void Awake()
   {
       StartCoroutine(bootUp());
   }

   IEnumerator bootUp()
   {
       audioSource.clip = audioClips[0];
       audioSource.Play();
       bootUpObjects[0].SetActive(true);
       yield return new WaitForSeconds(0.025f);
       bootUpObjects[0].SetActive(false);
       yield return new WaitForSeconds(0.25f);
       bootUpObjects[1].SetActive(true);
       bootUpObjects[11].SetActive(true);
       yield return new WaitForSeconds(0.25f);
       bootUpObjects[2].SetActive(true);
       bootUpObjects[3].GetComponentInChildren<TextMeshProUGUI>().text = "Memory Test: 0K";
       yield return new WaitForSeconds(0.15f);
       bootUpObjects[3].GetComponentInChildren<TextMeshProUGUI>().text = "Memory Test: 104867K";
       yield return new WaitForSeconds(0.15f);
       bootUpObjects[3].GetComponentInChildren<TextMeshProUGUI>().text = "Memory Test: 305940K";
       yield return new WaitForSeconds(0.15f);
       bootUpObjects[3].GetComponentInChildren<TextMeshProUGUI>().text = "Memory Test: 624958K";
       yield return new WaitForSeconds(0.15f);
       bootUpObjects[3].GetComponentInChildren<TextMeshProUGUI>().text = "Memory Test: 1293921K";
       yield return new WaitForSeconds(0.15f);
       bootUpObjects[3].GetComponentInChildren<TextMeshProUGUI>().text = "Memory Test: 1893102K";
       yield return new WaitForSeconds(0.15f);
       bootUpObjects[3].GetComponentInChildren<TextMeshProUGUI>().text = "Memory Test: 2000000K OK";
       yield return new WaitForSeconds(0.25f);
       bootUpObjects[4].SetActive(true);
       yield return new WaitForSeconds(0.25f);
       bootUpObjects[5].SetActive(true);
       yield return new WaitForSeconds(0.1f);
       bootUpObjects[5].GetComponentInChildren<TextMeshProUGUI>().text = "Detecting fish.exe ROM.";
       yield return new WaitForSeconds(0.1f);
       bootUpObjects[5].GetComponentInChildren<TextMeshProUGUI>().text = "Detecting fish.exe ROM..";
       yield return new WaitForSeconds(0.1f);
       bootUpObjects[5].GetComponentInChildren<TextMeshProUGUI>().text = "Detecting fish.exe ROM...";
       yield return new WaitForSeconds(0.1f);
       bootUpObjects[6].SetActive(true);
       yield return new WaitForSeconds(0.25f);
       bootUpObjects[7].SetActive(true);
       yield return new WaitForSeconds(0.1f);
       bootUpObjects[7].GetComponentInChildren<TextMeshProUGUI>().text = "Verifying fish.exe.";
       yield return new WaitForSeconds(0.1f);
       bootUpObjects[7].GetComponentInChildren<TextMeshProUGUI>().text = "Verifying fish.exe..";
       yield return new WaitForSeconds(0.1f);
       bootUpObjects[7].GetComponentInChildren<TextMeshProUGUI>().text = "Verifying fish.exe...";
       yield return new WaitForSeconds(0.1f);
       bootUpObjects[8].SetActive(true);
       yield return new WaitForSeconds(0.25f);
       bootUpObjects[9].SetActive(true);
       yield return new WaitForSeconds(0.1f);
       bootUpObjects[9].GetComponentInChildren<TextMeshProUGUI>().text = "Executing fish.exe.";
       yield return new WaitForSeconds(0.1f);
       bootUpObjects[9].GetComponentInChildren<TextMeshProUGUI>().text = "Executing fish.exe..";
       yield return new WaitForSeconds(0.1f);
       bootUpObjects[9].GetComponentInChildren<TextMeshProUGUI>().text = "Executing fish.exe...";
       yield return new WaitForSeconds(0.1f);
       bootUpObjects[10].SetActive(true);
       yield return new WaitForSeconds(0.25f);
       bootUpObjects[12].SetActive(true);
       yield return new WaitForSeconds(0.2f);
       bootUpObjects[12].GetComponentInChildren<TextMeshProUGUI>().text = "Initializing.";
       yield return new WaitForSeconds(0.2f);
       bootUpObjects[12].GetComponentInChildren<TextMeshProUGUI>().text = "Initializing..";
       yield return new WaitForSeconds(0.2f);
       bootUpObjects[12].GetComponentInChildren<TextMeshProUGUI>().text = "Initializing...";
       yield return new WaitForSeconds(0.2f);
       bootUpObjects[12].GetComponentInChildren<TextMeshProUGUI>().text = "Initializing....";
       yield return new WaitForSeconds(0.2f);
       bootUpObjects[12].GetComponentInChildren<TextMeshProUGUI>().text = "Initializing.....";
       yield return new WaitForSeconds(0.2f);
       bootUpObjects[13].SetActive(true);
       yield return new WaitForSeconds(0.25f);
       bootUpObjects[14].SetActive(true);
       yield return new WaitForSeconds(0.2f);
       bootUpObjects[14].GetComponentInChildren<TextMeshProUGUI>().text = "Activating Root Access.";
       yield return new WaitForSeconds(0.2f);
       bootUpObjects[14].GetComponentInChildren<TextMeshProUGUI>().text = "Activating Root Access..";
       yield return new WaitForSeconds(0.2f);
       bootUpObjects[14].GetComponentInChildren<TextMeshProUGUI>().text = "Activating Root Access...";
       yield return new WaitForSeconds(0.2f);
       bootUpObjects[14].GetComponentInChildren<TextMeshProUGUI>().text = "Activating Root Access....";
       yield return new WaitForSeconds(0.2f);
       bootUpObjects[14].GetComponentInChildren<TextMeshProUGUI>().text = "Activating Root Access.....";
       yield return new WaitForSeconds(0.2f);
       bootUpObjects[15].SetActive(true);
       yield return new WaitForSeconds(0.25f);
       bootUpObjects[16].SetActive(true);
       yield return new WaitForSeconds(0.2f);
       bootUpObjects[16].GetComponentInChildren<TextMeshProUGUI>().text = "Beginning fish.exe Boot Sequence.";
       yield return new WaitForSeconds(0.2f);
       bootUpObjects[16].GetComponentInChildren<TextMeshProUGUI>().text = "Beginning fish.exe Boot Sequence..";
       yield return new WaitForSeconds(0.2f);
       bootUpObjects[16].GetComponentInChildren<TextMeshProUGUI>().text = "Beginning fish.exe Boot Sequence...";
       yield return new WaitForSeconds(0.2f);
       bootUpObjects[16].GetComponentInChildren<TextMeshProUGUI>().text = "Beginning fish.exe Boot Sequence....";
       yield return new WaitForSeconds(0.2f);
       bootUpObjects[16].GetComponentInChildren<TextMeshProUGUI>().text = "Beginning fish.exe Boot Sequence.....";
       yield return new WaitForSeconds(0.2f);
       bootUpObjects[17].SetActive(true);
       yield return new WaitForSeconds(0.25f);
       bootUpObjects[18].SetActive(false);
       audioSource.volume = 0f;
       audioSource.Stop();
       audioSource.clip = audioClips[1];
       audioSource.volume = 1f;
       audioSource.Play();
       bootUpObjects[19].SetActive(true);
       yield return new WaitForSeconds(6f);
       SceneManager.LoadScene(2);
       
       
   }
}
