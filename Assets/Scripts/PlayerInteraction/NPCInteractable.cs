using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using StarterAssets;
using UnityEngine.InputSystem;
using TMPro;

//Ce script sert à définir l'interaction d'un PNJ

public class NPCInteractable : InteractableObject
{
    [Header("Physique")]
    [SerializeField] private GameObject player; 
    public GameObject head;

    [Header("Dialogues")]
    [SerializeField] private string professeur;
    [SerializeField] private List<GameObject> canvas = new List<GameObject>();
    private string Nom;
    private List<string> dialogues = new List<string>();

    [Header("Template Canva")]
    public GameObject d_template;
    public GameObject canva;

    private FirstPersonController fpscontroller;
    private Animator animator;
    private NPCLookAt npcLookAt;
    private ReadFileLine read;
    private string Lg;

    private void Awake()
    {
        read = new ReadFileLine();
        animator = GetComponent<Animator>();
        npcLookAt = GetComponent<NPCLookAt>();
        fpscontroller = GetComponent<FirstPersonController>();
        Lg = FirstPersonController.Language;

        //Associer le texte du fichier aux dialogues du PNJ
        switch(professeur)
        {
            case "doyen":
                SetNPCtxt("Dialogues" + Lg + "_Doyenne.txt");
                break;
            
            case "mine":
                SetNPCtxt("Dialogues" + Lg + "_Mine1.txt");
                if(FirstPersonController.MineGame) {SetNPCtxt("Dialogues" + Lg + "_Mine2.txt");}
                break;
            
            case "meca":
                SetNPCtxt("Dialogues" + Lg + "_Meca.txt");
                break;

            case "math":
                SetNPCtxt("Dialogues" + Lg + "_Math.txt");
                break;

            case "chimie":
                SetNPCtxt("Dialogues" + Lg + "_Chimie1.txt");
                break;
            
            case "fortemps":
                SetNPCtxt("Dialogues" + Lg + "_Jobs.txt");
                break;

        }
        if(FirstPersonController.etape == 0 && professeur == "doyen") {
            foreach (GameObject canva in canvas)
            {
                canva.SetActive(false);
            }
            Interact(player.transform);
        }
        
    }

    //Fonction qui lance un dialogue lors d'étape précise
    private void Update()
    {
        if ((!FirstPersonController.dialogue && !FirstPersonController.pause && FirstPersonController.MineTalk2 && !FirstPersonController.MineTalkEnd2 && professeur == "mine") 
        ||(!FirstPersonController.dialogue && !FirstPersonController.pause && FirstPersonController.MecaTalk && !FirstPersonController.MecaTalkEnd && professeur == "meca")
        || (!FirstPersonController.dialogue && !FirstPersonController.pause && FirstPersonController.ChimieTalk2 && !FirstPersonController.ChimieTalk2End && professeur == "chimie")
        || (!FirstPersonController.dialogue && !FirstPersonController.pause && FirstPersonController.FortempsTalk && !FirstPersonController.FortempsTalkEnd && professeur == "fortemps") ) {
            if(professeur=="chimie") {SetNPCtxt("Dialogues" + Lg + "_Chimie2.txt");}
            foreach (GameObject canva in canvas)
            {
                canva.SetActive(false);
            }
            Interact(player.transform);
        }
    }

    //Fonction qui permet de créer des boites de dialogues à partir d'un template
    public void NewDialogue(string text) 
    {
        GameObject template_clone = Instantiate(d_template, d_template.transform);
        template_clone.transform.SetParent(canva.transform, false);
        template_clone.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = text;
        template_clone.transform.GetChild(2).GetChild(1).GetComponent<TextMeshProUGUI>().text = Nom;
    }

    public override void Interact(Transform interactorTransform) 
    {
        //On marque la fin d'une étape en fonction du NPC
        switch(professeur) {
            case "doyen":
                FirstPersonController.Doyen = true;
                break;
            case "mine":
                FirstPersonController.MineTalk = true;
                break;
            case "math":
                FirstPersonController.MathTalk = true;
                break;
            case "chimie":
                FirstPersonController.ChimieTalk = true;
                break;
        }

        //Changement d'animation et on tourne le NPC vers le joueur
        animator.SetTrigger("Talk");
        float playerHeight = 0f;
        npcLookAt.LookAtPosition(interactorTransform.position + Vector3.up * playerHeight);

        //On fait appairaitre les boites de dialogues
        canva.SetActive(true);
        FirstPersonController.dialogue = true;
        foreach (string dialogue in dialogues) {
            NewDialogue(dialogue);
        }
        canva.transform.GetChild(2).gameObject.SetActive(true); 
    }

    //Fonction qui permet de changer les dialogues
    public void SetDialogues(List<string> dia){
        dialogues = dia;
    }


    public void SetNom(string name){
        Nom = name;
    }

    public void SetNPCtxt(string fileName)
    {
        List<string> text = new List<string>();
        text = read.Lecture(fileName);
        SetNom(text[0]);
        text.RemoveAt(0);
        SetInteractText(text[0]);
        text.RemoveAt(0);
        SetDialogues(text);
    }

    public List<string> SetNPCAstuce(string fileName)
    {
        List<string> text = new List<string>();
        List<string> objectif = new List<string>();
        text = read.Lecture(fileName);
        SetNom(text[0]);
        text.RemoveAt(0);
        SetInteractText(text[0]);
        text.RemoveAt(0);
        objectif.Add(text[0]);
        text.RemoveAt(0);
        objectif.Add(text[0]);
        text.RemoveAt(0);
        SetDialogues(text);
        return objectif;
    }

    public NPCLookAt GetLookAt() {
        return npcLookAt;
    }
}
