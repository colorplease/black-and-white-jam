using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Resume : MonoBehaviour
{
    public TMP_InputField inputField;
    [SerializeField] GameObject granted;
    [SerializeField] GameObject denied;
    [SerializeField] GameObject fish;
    [SerializeField] GameObject fish1;

    void Awake()
    {
        inputField.characterLimit = 4;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            string passwordTry = inputField.text;
            if (passwordTry.Equals("9215"))
            {
                StartCoroutine(AccessGranted());
            }
            else if (passwordTry.Equals("fish"))
            {
                StartCoroutine(fish2());
            }
            else
            {
                StartCoroutine(AccessDenied());
            }
        }
    }

    IEnumerator AccessGranted()
    {
        fish.SetActive(false);
        granted.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        fish.SetActive(true);
        granted.SetActive(false);
        Destroy(gameObject);
    }

    IEnumerator AccessDenied()
    {
        fish.SetActive(false);
        denied.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        fish.SetActive(true);
        denied.SetActive(false);
    }

    IEnumerator fish2()
    {
        fish.SetActive(false);
        fish1.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        fish.SetActive(true);
        fish1.SetActive(false);
    }
}
