using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsLoad : MonoBehaviour
{

    [SerializeField] private Animator QapiDance;
    [SerializeField] private Animator transition;
    [SerializeField] private GameObject Image;
    [SerializeField] private GameObject Qapi;
    [SerializeField] private GameLoader gameLoader;
    
    void Start()
    {
        StartCoroutine(Credits());
    }

    IEnumerator Credits()
    {
        yield return new WaitForSeconds(7f);
        QapiDance.SetTrigger("T1");

        yield return new WaitForSeconds(7f);
        QapiDance.SetTrigger("T2");

        yield return new WaitForSeconds(7f);
        QapiDance.SetTrigger("T3");

        yield return new WaitForSeconds(7f);
        QapiDance.SetTrigger("T4");

        yield return new WaitForSeconds(8f);
        transition.SetTrigger("FadeOut");
        yield return new WaitForSeconds(1f);
        Qapi.SetActive(false);
        Image.SetActive(true);
        transition.ResetTrigger("FadeOut");
        yield return new WaitForSeconds(10f);
        gameLoader.ChangeScene("Demarrage");

    }
}
