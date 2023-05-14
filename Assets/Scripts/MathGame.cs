using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class MathGame : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject camera;
    [SerializeField] private GameObject InGameCanvas;
    [SerializeField] private GameObject MathCanvas;
    public Animator transition;
    private bool begin = false;

    private void Update() 
    {
        if (FirstPersonController.MathTalkEnd && !begin)
        {
            StartCoroutine(GameBegin());
        }
    }

    IEnumerator GameBegin()
    {
        begin = true;
        transition.SetTrigger("FadeOut");
        yield return new WaitForSeconds(1f);
        InGameCanvas.SetActive(false);
        MathCanvas.SetActive(true);
        player.SetActive(false);
        camera.SetActive(true);
        transition.ResetTrigger("FadeOut");
    }

    public void Succes()
    {
        StartCoroutine(GameSucces());
    }

    IEnumerator GameSucces()
    {
        transition.SetTrigger("FadeOut");
        yield return new WaitForSeconds(1f);
        InGameCanvas.SetActive(true);
        MathCanvas.SetActive(false);
        player.SetActive(true);
        camera.SetActive(false);
        transition.ResetTrigger("FadeOut");
        FirstPersonController.MathGame = true;
    }


}
