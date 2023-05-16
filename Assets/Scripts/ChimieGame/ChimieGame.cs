using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class ChimieGame : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject camera;
    [SerializeField] private GameObject InGameCanvas;
    [SerializeField] private GameObject ChimieCanvas;
    [SerializeField] private GameObject AimPoint;

    [SerializeField] private GameObject Rock;
    [SerializeField] private GameObject pipette;
    [SerializeField] private GameObject Erlenmyer;
    public Animator transition;
    private bool begin = false;

    private string Lg;

    private void Awake() {
        Lg = FirstPersonController.Language;
    }
    

    private void Update() 
    {
        if (FirstPersonController.ChimieTalkEnd && !begin && !FirstPersonController.ChimieTalk2)
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
        ChimieCanvas.SetActive(true);
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
        ChimieCanvas.SetActive(false);
        player.SetActive(true);
        camera.SetActive(false);
        Rock.SetActive(true);
        pipette.SetActive(true);
        Erlenmyer.SetActive(true);
        AimPoint.SetActive(true);
        transition.ResetTrigger("FadeOut");

        FirstPersonController.ChimieGame0 = true;        
        FirstPersonController.ChimieTalk2 = true;
    }


}
