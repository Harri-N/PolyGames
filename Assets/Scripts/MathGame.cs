using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

//Ce script sert à gérer le jeu de math

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
        //Lancement du jeu de math après la fin du dialogue avec le prof
        if (FirstPersonController.MathTalkEnd && !begin)
        {
            StartCoroutine(GameBegin());
        }
    }

    //Cette fonction lance le jeu de Math 
    //Elle change de caméra et lance le canva des QCM
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

    //Cette fonction termine le jeu de Math et rechange de point de vue
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
