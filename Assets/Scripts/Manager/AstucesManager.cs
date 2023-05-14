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

    private bool AstuceDialogue;


    private void Awake() 
    {
        fpscontroller = GetComponent<FirstPersonController>();
        AstuceDialogue = true;
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
            dia.Add("À la Polytech de Mons, nous avons mis en place un dispositif de réussite pour les nouveaux arrivants. C’est pourquoi je serai là pour t’accompagner et te conseiller tout au long de ton aventure.");
            dia.Add("N’hésite pas à me consulter en appuyant sur le bouton start ou la touche Tab. Tu trouveras dans la rubrique « astuces » un rappel de la mission en cours.");
            dia.Add("Pour commencer, rends-toi devant l’aile gauche du bâtiment. À l’entrée du service de Génie Minier, tu trouveras M. Pierre. Il te donnera la 1ère épreuve.");
            dia.Add("Pour te déplacer, utilise les touches ZQSD de ton clavier ou le joystick gauche de ta manette.");
            dia.Add("Pour orienter la caméra, utilise ta souris ou le joystick droit de ta manette. Tu peux modifier la sensibilité dans les paramètres du menu pause.");
            dia.Add("Pour interagir avec ton environnement, utilise la touche E de ton clavier ou le bouton X de ta manette.");
            NPCAstuces.SetDialogues(dia);
            string text = "Rends-toi devant l’aile gauche du bâtiment. À l’entrée du service de Génie Minier et va parler à M.Pierre.";
            string obj = "Objectif : Aller parler à M.Pierre.";
            float timewait = 1f;
            StartCoroutine(ChangeAstuces(timewait, text, obj));
        }

        if (FirstPersonController.MineTalkEnd && FirstPersonController.etape == 1)
        {
            FirstPersonController.etape += 1;
            FirstPersonController.TutoMine = true;
            List<string> dia = new List<string>();
            dia.Add("Nous voilà dans la mine. Tu trouveras les matières premières au fond de celle-ci.");
            dia.Add("Pour sauter et éviter les obstacles, utilise la touche espace de ton clavier ou le bouton A de ta manette.");
            dia.Add("Pour frapper avec la pioche, utilise le clic gauche de ta souris ou la touche RT de ta manette.");
            NPCAstuces.SetDialogues(dia);
            string text = "Aller au fond de la grotte et récolter du calcaire.";
            string obj = "Objectif : Récolter du calcaire.";
            float timewait = 0f;
            StartCoroutine(ChangeAstuces(timewait, text, obj));    
        }

        if (FirstPersonController.MineGame && FirstPersonController.etape == 2)
        {
            FirstPersonController.etape += 1;
            List<string> dia = new List<string>();
            dia.Add("Super ! Tu as pu récolter le calcaire. Allons les rapporter M. Pierre");
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
            dia.Add("Maintenant que tu as réussi la 1ère épreuve, va rejoindre M. Newton. Il t’attend dans le hall. Tu peux rentrer dans le bâtiment par l’entrée principale.");
            NPCAstuces.SetDialogues(dia);
            string text = "Va voir M. Newton qui t’attend dans le hall. Tu peux rentrer dans le bâtiment par l’entrée principale.";
            string obj = "Objectif : Aller parler à M. Newton.";
            float timewait = 1f;
            StartCoroutine(ChangeAstuces(timewait, text, obj));    
        }

        if (FirstPersonController.MecaTalkEnd && FirstPersonController.etape == 4)
        {
            FirstPersonController.etape += 1;
            AstuceDialogue = false;
            string text = "Rentrer dans la voiture.";
            string obj = "Objectif : Rentrer dans la voiture.";
            float timewait = 0f;
            StartCoroutine(ChangeAstuces(timewait, text, obj));    
        }

        if (FirstPersonController.MecaCar && FirstPersonController.etape == 5)
        {
            FirstPersonController.etape += 1;
            FirstPersonController.TutoCar = true;
            List<string> dia = new List<string>();
            dia.Add("Pour sortir de la faille spatio-temporelle, dirige-toi vers l'auditoire 12 avant le temps imparti.");
            dia.Add("L'auditoire 12 se trouve au 1er étage, à droite au-dessus de l’escalier.");
            dia.Add("Pour te déplacer avec la voiture, utilise les touches ZQSD de ton clavier ou le joystick gauche de ta manette.");
            dia.Add("Si tu te retrouves coincé, tu peux aller dans le menu pause et appuyer sur Réapparaitre");
            NPCAstuces.SetDialogues(dia);
            string text = "Pour sortir de la faille spatio-temporelle, dirige-toi vers l'auditoire 12 avant le temps imparti. Il se trouve au 1er étage, à droite au-dessus de l’escalier.";
            string obj = "Objectif : Aller à l'auditoire 12.";
            float timewait = 0f;
            StartCoroutine(ChangeAstuces(timewait, text, obj));    
        }

        if (FirstPersonController.MecaGame && FirstPersonController.etape == 6)
        {
            FirstPersonController.etape += 1;
            List<string> dia = new List<string>();
            dia.Add("Super, tu es arrivé à temps ! Rentre maintenant vite à l'intérieur de l’auditoire 12. C’est là que la majorité des cours de première année se déroule.");
            NPCAstuces.SetDialogues(dia);
            string text = "";
            string obj = "";
            float timewait = 0f;
            StartCoroutine(ChangeAstuces(timewait, text, obj));    
        }

        if (FirstPersonController.Ho12 && FirstPersonController.etape == 7)
        {
            FirstPersonController.etape += 1;
            List<string> dia = new List<string>();
            dia.Add("Va voir M.Pyth. Il t'attend au fond de l'auditoire devant le tableau.");
            NPCAstuces.SetDialogues(dia);
            string text = "Va voir M.Pyth. Il t'attend au fond de l'auditoire devant le tableau.";
            string obj = "Objectif : Aller parler à M. Pyth";
            float timewait = 0f;
            StartCoroutine(ChangeAstuces(timewait, text, obj));    
        }

        if (FirstPersonController.MathGame && FirstPersonController.etape == 8)
        {
            FirstPersonController.etape += 1;
            List<string> dia = new List<string>();
            dia.Add("Génial ! La trigonométrie n'a plus de secret pour toi (ou presque). Retournons dans le couloir pour poursuivre la suite de ton aventure.");
            NPCAstuces.SetDialogues(dia);
            string text = "";
            string obj = "";
            float timewait = 0f;
            StartCoroutine(ChangeAstuces(timewait, text, obj));    
        }

        if (FirstPersonController.Couloir && FirstPersonController.etape == 9)
        {
            FirstPersonController.etape += 1;
            FirstPersonController.Tuto11 = true;
            List<string> dia = new List<string>();
            dia.Add("Pour la suite, dirige-toi vers l'auditoire 11 qui se trouve à l'autre bout du couloir de cet étage.");
            dia.Add("Voici une carte pour mieux te situer.");
            NPCAstuces.SetDialogues(dia);
            string text = "Pour la suite, dirige-toi vers l'auditoire 11 qui se trouve à l'autre bout du couloir de cet étage.";
            string obj = "Objectif : Aller dans l'auditoire 11.";
            float timewait = 0f;
            StartCoroutine(ChangeAstuces(timewait, text, obj));    
        }

        if (FirstPersonController.Ho11 && FirstPersonController.etape == 10)
        {
            FirstPersonController.etape += 1;
            List<string> dia = new List<string>();
            dia.Add("Va parler à M. Heisenberg qui t'attend en bas devant le tableau.");
            NPCAstuces.SetDialogues(dia);
            string text = "Va parler à M. Heisenberg qui t'attend en bas devant le tableau.";
            string obj = "Objectif : Aller parler à M.Heisenberg.";
            float timewait = 0f;
            StartCoroutine(ChangeAstuces(timewait, text, obj));    
        }

        if (FirstPersonController.ChimieTalk2End && FirstPersonController.etape == 11)
        {
            FirstPersonController.etape += 1;
            AstuceDialogue = false;
            string text = "Prépare la solution. Sur la table, tu trouveras une pipette et un soluté que tu devras mettre dans un erlenmyer. Ensuite, allume d'abord la taque puis pose ta solution pour la faire chauffer et accélérer la réaction.";
            string obj = "Objectif : Préparer la solution.";
            float timewait = 0f;
            StartCoroutine(ChangeAstuces(timewait, text, obj));    
        }


        if (FirstPersonController.ChimieGame && FirstPersonController.etape == 12)
        {
            FirstPersonController.etape += 1;
            List<string> dia = new List<string>();
            dia.Add("Super ! Tu as réussi toutes les épreuves. Tu es maintenant prêt pour le combat final. Va retrouver M. Jobs qui se trouve dans la cour. Il a quelques mots à te dire avant que tu n’entames la dernière étape de ton parcours.");
            NPCAstuces.SetDialogues(dia);
            string text = "Aller dans la cour pour parler à .M Jobs.";
            string obj = "Objectif : Aller dans la cour.";
            float timewait = 2f;
            StartCoroutine(ChangeAstuces(timewait, text, obj));    
        }

        if (FirstPersonController.Couloir && FirstPersonController.etape == 13)
        {
            FirstPersonController.etape += 1;
            AstuceDialogue = false;
            string text = "Aller dans la cour pour parler à .M Jobs.";
            string obj = "Aller dans la cour.";
            float timewait = 0f;
            StartCoroutine(ChangeAstuces(timewait, text, obj));    
        }

        if (FirstPersonController.DragonGameBegin2 && FirstPersonController.etape == 14)
        {
            FirstPersonController.etape += 1;
            FirstPersonController.TutoDragon = true;
            List<string> dia = new List<string>();
            dia.Add("Pour vaincre le dragon, il te suffit de le toucher avec les lasers.");
            dia.Add("Pour tirer, utilise le clic gauche de ta souris ou la touche RT de ta manette.");
            NPCAstuces.SetDialogues(dia);
            string text = "Vaincre le dragon.";
            string obj = "Vaincre le dragon.";
            float timewait = 0f;
            StartCoroutine(ChangeAstuces(timewait, text, obj));    
        }

        if (FirstPersonController.DragonGame)
        {
            gameLoader.ChangeScene("Credits");
        }

    }

    IEnumerator ChangeAstuces(float t, string text, string obj) {
        yield return new WaitForSeconds(t);
        if (AstuceDialogue) {
            foreach (GameObject canva in canvas)
            {
                canva.SetActive(false);
            }
            NPCAstuces.Interact(NPCAstuces.GetLookAt().transform);
        }
        Astuces.text = text;
        Objectif.text = obj;
        AstuceDialogue = true;
    }

}
