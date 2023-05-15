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

    [SerializeField] private NPCInteractable chimieGuy;
    public Animator transition;
    private bool begin = false;
    

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

        List<string> dia = new List<string>();
        dia.Add("Et oui ! Quoi de mieux que l'eau pour combattre le feu.");
        dia.Add("Maintenant, il ne te reste plus qu'à produire cette réaction. Sur la table à ta gauche, tu trouveras une pipette et un soluté que tu devras mettre dans un erlenmyer.");
        dia.Add("Ensuite, allume la taque qui se trouve derrière toi et fais chauffer ta solution pour accélérer la réaction.");
        dia.Add("Si tu perds un objet, appuie sur le bouton Réapparaitre dans le menu Pause.");
        chimieGuy.SetDialogues(dia);
        FirstPersonController.ChimieTalk2 = true;
    }


}
