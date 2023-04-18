using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
using TMPro;

public class AstucesManager : MonoBehaviour
{
    [SerializeField] private NPCInteractable NPCAstuces;
    [SerializeField] private TextMeshProUGUI Astuces;
    [SerializeField] private List<GameObject> canvas = new List<GameObject>();
    private FirstPersonController fpscontroller;
    static public int success = 0;


    private void Awake() 
    {
        fpscontroller = GetComponent<FirstPersonController>();
    }

    void Update()
    {
        if (FirstPersonController.DoyenEnd && success == 0)
        {
            List<string> dia = new List<string>();
            dia.Add("Bonjour ! Je me présente, je m’appelle Glubulu et je fais partie de la cellule de pédagogie facultaire QAP-Polytech.");
            dia.Add("À la Polytech de Mons, nous avons mis en place un dispositif de réussite pour les nouveaux jeunes arrivants. C’est pourquoi je serai là pour t’accompagner et te conseiller tout au long de ton aventure.");
            dia.Add("N’hésite pas à me consulter en appuyant sur le bouton start et en allant dans la rubrique « astuces ».");
            dia.Add("Pour commencer, rends-toi devant l’aile gauche du bâtiment. À l’entrée du service de Génie Minier, tu trouvera M. Goderniaux. Il te donnera la 1ère épreuve.");
            NPCAstuces.SetDialogues(dia);
            success += 1;
            string text = "Pour commencer, rends-toi devant l’aile gauche du bâtiment. À l’entrée du service de Génie Minier, tu trouvera M. Goderniaux. Il te donnera la 1ère épreuve.";
            float timewait = 2f;
            StartCoroutine(ChangeAstuces(timewait, text));
            
            
        }
    }

    IEnumerator ChangeAstuces(float t, string text) {
        yield return new WaitForSeconds(t);
        foreach (GameObject canva in canvas)
        {
            canva.SetActive(false);
        }
        NPCAstuces.Interact(NPCAstuces.GetLookAt().transform);
        Astuces.text = text;
    }

}
