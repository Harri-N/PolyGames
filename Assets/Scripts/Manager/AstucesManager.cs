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

    private string Lg;

    private void Awake() 
    {
        fpscontroller = GetComponent<FirstPersonController>();
        Lg = FirstPersonController.Language;
        AstuceDialogue = true;
    }

    void Update()
    {
        if (FirstPersonController.GameOver) {FirstPersonController.GameOver = false; gameLoader.ChangeScene("GameOver");}
        if (FirstPersonController.DoyenEnd && FirstPersonController.etape == 0)
        {
            FirstPersonController.etape += 1;
            FirstPersonController.Tuto1 = true;
            List<string> objectifs = new List<string>();
            objectifs = NPCAstuces.SetNPCAstuce("Dialogues" + Lg + "_Qapi0.txt");
            float timewait = 0.5f;
            StartCoroutine(ChangeAstuces(timewait, objectifs[0], objectifs[1]));
        }

        if (FirstPersonController.MineTalkEnd && FirstPersonController.etape == 1)
        {
            FirstPersonController.etape += 1;
            FirstPersonController.TutoMine = true;
            List<string> objectifs = new List<string>();
            objectifs = NPCAstuces.SetNPCAstuce("Dialogues" + Lg + "_Qapi1.txt");
            float timewait = 0f;
            StartCoroutine(ChangeAstuces(timewait, objectifs[0], objectifs[1]));
        }

        if (FirstPersonController.MineGame && FirstPersonController.etape == 2)
        {
            FirstPersonController.etape += 1;
            List<string> objectifs = new List<string>();
            objectifs = NPCAstuces.SetNPCAstuce("Dialogues" + Lg + "_Qapi2.txt");
            float timewait = 1f;
            StartCoroutine(ChangeAstuces(timewait, objectifs[0], objectifs[1]));   
        }

        if (FirstPersonController.MineTalkEnd2 && FirstPersonController.etape == 3)
        {
            FirstPersonController.etape += 1;
            List<string> objectifs = new List<string>();
            objectifs = NPCAstuces.SetNPCAstuce("Dialogues" + Lg + "_Qapi3.txt");
            float timewait = 0.5f;
            StartCoroutine(ChangeAstuces(timewait, objectifs[0], objectifs[1]));   
        }

        if (FirstPersonController.MecaTalkEnd && FirstPersonController.etape == 4)
        {
            FirstPersonController.etape += 1;
            AstuceDialogue = false;
            List<string> objectifs = new List<string>();
            objectifs = NPCAstuces.SetNPCAstuce("Dialogues" + Lg + "_Qapi4.txt");
            float timewait = 0f;
            StartCoroutine(ChangeAstuces(timewait, objectifs[0], objectifs[1]));   
        }

        if (FirstPersonController.MecaCar && FirstPersonController.etape == 5)
        {
            FirstPersonController.etape += 1;
            FirstPersonController.TutoCar = true;
            List<string> objectifs = new List<string>();
            objectifs = NPCAstuces.SetNPCAstuce("Dialogues" + Lg + "_Qapi5.txt");
            float timewait = 0f;
            StartCoroutine(ChangeAstuces(timewait, objectifs[0], objectifs[1]));   
        }

        if (FirstPersonController.MecaGame && FirstPersonController.etape == 6)
        {
            FirstPersonController.etape += 1;
            List<string> objectifs = new List<string>();
            objectifs = NPCAstuces.SetNPCAstuce("Dialogues" + Lg + "_Qapi6.txt");
            float timewait = 0f;
            StartCoroutine(ChangeAstuces(timewait, objectifs[0], objectifs[1]));    
        }

        if (FirstPersonController.Ho12 && FirstPersonController.etape == 7)
        {
            FirstPersonController.etape += 1;
            List<string> objectifs = new List<string>();
            objectifs = NPCAstuces.SetNPCAstuce("Dialogues" + Lg + "_Qapi7.txt");
            float timewait = 0f;
            StartCoroutine(ChangeAstuces(timewait, objectifs[0], objectifs[1]));    
        }

        if (FirstPersonController.MathGame && FirstPersonController.etape == 8)
        {
            FirstPersonController.etape += 1;
            List<string> objectifs = new List<string>();
            objectifs = NPCAstuces.SetNPCAstuce("Dialogues" + Lg + "_Qapi8.txt");
            float timewait = 0f;
            StartCoroutine(ChangeAstuces(timewait, objectifs[0], objectifs[1]));    
        }

        if (FirstPersonController.Couloir && FirstPersonController.etape == 9)
        {
            FirstPersonController.etape += 1;
            FirstPersonController.Tuto11 = true;
            List<string> objectifs = new List<string>();
            objectifs = NPCAstuces.SetNPCAstuce("Dialogues" + Lg + "_Qapi9.txt");
            float timewait = 0f;
            StartCoroutine(ChangeAstuces(timewait, objectifs[0], objectifs[1]));   
        }

        if (FirstPersonController.Ho11 && FirstPersonController.etape == 10)
        {
            FirstPersonController.etape += 1;
            List<string> objectifs = new List<string>();
            objectifs = NPCAstuces.SetNPCAstuce("Dialogues" + Lg + "_Qapi10.txt");
            float timewait = 0f;
            StartCoroutine(ChangeAstuces(timewait, objectifs[0], objectifs[1]));    
        }

        if (FirstPersonController.ChimieTalk2End && FirstPersonController.etape == 11)
        {
            FirstPersonController.etape += 1;
            AstuceDialogue = false;
            List<string> objectifs = new List<string>();
            objectifs = NPCAstuces.SetNPCAstuce("Dialogues" + Lg + "_Qapi11.txt");
            float timewait = 0f;
            StartCoroutine(ChangeAstuces(timewait, objectifs[0], objectifs[1]));   
        }


        if (FirstPersonController.ChimieGame && FirstPersonController.etape == 12)
        {
            FirstPersonController.etape += 1;
            List<string> objectifs = new List<string>();
            objectifs = NPCAstuces.SetNPCAstuce("Dialogues" + Lg + "_Qapi12.txt");
            float timewait = 2f;
            StartCoroutine(ChangeAstuces(timewait, objectifs[0], objectifs[1]));   
        }

        if (FirstPersonController.Couloir && FirstPersonController.etape == 13)
        {
            FirstPersonController.etape += 1;
            AstuceDialogue = false;
            List<string> objectifs = new List<string>();
            objectifs = NPCAstuces.SetNPCAstuce("Dialogues" + Lg + "_Qapi13.txt");
            float timewait = 0f;
            StartCoroutine(ChangeAstuces(timewait, objectifs[0], objectifs[1]));   
        }

        if (FirstPersonController.DragonGameBegin2 && FirstPersonController.etape == 14)
        {
            FirstPersonController.etape += 1;
            FirstPersonController.TutoDragon = true;
            List<string> objectifs = new List<string>();
            objectifs = NPCAstuces.SetNPCAstuce("Dialogues" + Lg + "_Qapi14.txt");
            float timewait = 0f;
            StartCoroutine(ChangeAstuces(timewait, objectifs[0], objectifs[1]));    
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
