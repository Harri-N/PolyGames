using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
using TMPro;

public class AstucesManager : MonoBehaviour
{
    [SerializeField] private NPCInteractable NPCAstuces;
    [SerializeField] private TextMeshProUGUI Astuces;
    [SerializeField] private TextMeshProUGUI Objectif;
    [SerializeField] private List<GameObject> canvas = new List<GameObject>();
    private FirstPersonController fpscontroller;
    [SerializeField] private GameLoader gameLoader;


    private void Awake() 
    {
        fpscontroller = GetComponent<FirstPersonController>();
    }

    void Update()
    {
        if (FirstPersonController.GameOver) {FirstPersonController.GameOver = false; gameLoader.ChangeScene("GameOver");}
        if (FirstPersonController.DoyenEnd && FirstPersonController.etape == 0)
        {
            FirstPersonController.etape += 1;
            FirstPersonController.Tuto1 = true;
            List<string> dia = new List<string>();
            dia.Add("Bonjour ! Je me présente, je m’appelle Qapi et je fais partie de la cellule de pédagogie facultaire QAP-Polytech.");
            dia.Add("À la Polytech de Mons, nous avons mis en place un dispositif de réussite pour les nouveaux jeunes arrivants. C’est pourquoi je serai là pour t’accompagner et te conseiller tout au long de ton aventure.");
            dia.Add("N’hésite pas à me consulter en appuyant sur le bouton start ou la touche Tab. Tu trouveras dans la rubrique « astuces » un rappel de la mission en cours.");
            dia.Add("Pour commencer, rends-toi devant l’aile gauche du bâtiment. À l’entrée du service de Génie Minier, tu trouvera M. Goderniaux. Il te donnera la 1ère épreuve.");
            dia.Add("Pour te déplacer, utilise les touches ZQSD de ton clavier ou le joystick gauche de ta manette.");
            dia.Add("Pour orienter la caméra, utilise ta souris ou le joystick droit de ta manette. Tu peux modifier la sensibilité dans les paramètres du menu pause.");
            dia.Add("Pour interagir avec ton environnement, utilise la touche E de ton clavier ou le bouton X de ta manette.");
            NPCAstuces.SetDialogues(dia);
            string text = "Rends-toi devant l’aile gauche du bâtiment. À l’entrée du service de Génie Minier et va parler à M.Young.";
            string obj = "Objectif : Aller parler à M.Young.";
            float timewait = 1f;
            StartCoroutine(ChangeAstuces(timewait, text, obj));
        }

        if (FirstPersonController.MineTalkEnd && FirstPersonController.etape == 1)
        {
            FirstPersonController.etape += 1;
            FirstPersonController.Tuto2 = true;
            List<string> dia = new List<string>();
            dia.Add("Nous voilà dans la grotte. Tu trouveras les matières premières au fond de celle-ci.");
            dia.Add("Pour sauter et éviter les obstacles, utilise la touche espace de ton clavier ou le bouton A de ta manette.");
            dia.Add("Pour frapper avec la pioche, utilise le clic gauche de ta souris ou la touche RB de ta manette.");
            NPCAstuces.SetDialogues(dia);
            string text = "Aller au fond de la grotte et casser des cailloux.";
            string obj = "Objectif : Récolter des cailloux.";
            float timewait = 0f;
            StartCoroutine(ChangeAstuces(timewait, text, obj));    
        }

        if (FirstPersonController.MineGame && FirstPersonController.etape == 2)
        {
            FirstPersonController.etape += 1;
            List<string> dia = new List<string>();
            dia.Add("Super ! Tu as pu récolter les cailloux. Allons les rapporter M. Young");
            NPCAstuces.SetDialogues(dia);
            string text = "";
            string obj = "";
            float timewait = 1f;
            StartCoroutine(ChangeAstuces(timewait, text, obj));   
        }

        if (FirstPersonController.MineTalkEnd2 && FirstPersonController.etape == 3)
        {
            FirstPersonController.etape += 1;
            List<string> dia = new List<string>();
            dia.Add("Maintenat que tu as réussi la 1ère épreuve, va rejoindre M. Reynolds. Il t’attend dans le hall. Tu peux rentrer dans le bâtiment par l’entrée principale.");
            NPCAstuces.SetDialogues(dia);
            string text = "Va voir M. Reynolds à l'entrée du bâtiment principal.";
            string obj = "Objectif : Aller parler à M. Reynolds.";
            float timewait = 1f;
            StartCoroutine(ChangeAstuces(timewait, text, obj));    
        }

        if (FirstPersonController.MecaTalkEnd && FirstPersonController.etape == 4)
        {
            FirstPersonController.etape += 1;
            List<string> dia = new List<string>();
            dia.Add("Pour sortir de la faille spatio-temporelle, dirige-toi vers l'auditoire 12. Il se trouve au 1er étage et au fond du couloir de droite.");
            NPCAstuces.SetDialogues(dia);
            string text = "Aller à l'auditoire 12. Il se trouve au 1er étage et au fond du couloir de droite.";
            string obj = "Objectif : Aller à l'auditoire 12.";
            float timewait = 0f;
            StartCoroutine(ChangeAstuces(timewait, text, obj));    
        }

        if (FirstPersonController.MecaGame && FirstPersonController.etape == 5)
        {
            FirstPersonController.etape += 1;
            List<string> dia = new List<string>();
            dia.Add("Super, tu es arrivé à temps ! Rentrons vite à l'intérieur.");
            NPCAstuces.SetDialogues(dia);
            string text = "";
            string obj = "";
            float timewait = 0f;
            StartCoroutine(ChangeAstuces(timewait, text, obj));    
        }

        if (FirstPersonController.MathGame && FirstPersonController.etape == 6)
        {
            FirstPersonController.etape += 1;
            List<string> dia = new List<string>();
            dia.Add("GG Bro.");
            NPCAstuces.SetDialogues(dia);
            string text = "";
            string obj = "";
            float timewait = 0f;
            StartCoroutine(ChangeAstuces(timewait, text, obj));    
        }

    }

    IEnumerator ChangeAstuces(float t, string text, string obj) {
        yield return new WaitForSeconds(t);
        foreach (GameObject canva in canvas)
        {
            canva.SetActive(false);
        }
        NPCAstuces.Interact(NPCAstuces.GetLookAt().transform);
        Astuces.text = text;
        Objectif.text = obj;
    }

}
