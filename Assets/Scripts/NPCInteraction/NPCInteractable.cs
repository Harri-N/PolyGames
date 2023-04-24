using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
using UnityEngine.InputSystem;
using TMPro;

public class NPCInteractable : InteractableObject
{
    [SerializeField] private List<string> dialogues = new List<string>();
    [SerializeField] private string Nom;
    public GameObject head;
    private FirstPersonController fpscontroller;
    private Animator animator;
    private NPCLookAt npcLookAt;

    public GameObject d_template;
    public GameObject canva;

    [SerializeField] private string professeur;
    [SerializeField] private List<GameObject> canvas = new List<GameObject>();
    
    

    private void Awake()
    {
        animator = GetComponent<Animator>();
        npcLookAt = GetComponent<NPCLookAt>();
        fpscontroller = GetComponent<FirstPersonController>();
        if(FirstPersonController.etape == 0 && professeur == "doyen") {
            foreach (GameObject canva in canvas)
            {
                canva.SetActive(false);
            }
            Interact(npcLookAt.transform);
        }
        
    }
    private void Update()
    {
        if (!FirstPersonController.dialogue && !FirstPersonController.pause && FirstPersonController.MineTalk2 && !FirstPersonController.MineTalkEnd2 && professeur == "mine") {
            foreach (GameObject canva in canvas)
            {
                canva.SetActive(false);
            }
            Interact(npcLookAt.transform);
        }
    }

    public void NewDialogue(string text) 
    {
        GameObject template_clone = Instantiate(d_template, d_template.transform);
        template_clone.transform.SetParent(canva.transform, false);
        template_clone.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = text;
        template_clone.transform.GetChild(2).GetChild(1).GetComponent<TextMeshProUGUI>().text = Nom;
    }

    public void Interact(Transform interactorTransform) 
    {
        switch(professeur) {
            case "doyen":
                FirstPersonController.Doyen = true;
                break;
            case "mine":
                FirstPersonController.MineTalk = true;
                break;
        }
        Debug.Log("Interact!");
        animator.SetTrigger("Talk");
        float playerHeight = 0f;
        npcLookAt.LookAtPosition(interactorTransform.position + Vector3.up * playerHeight);

        canva.SetActive(true);
        FirstPersonController.dialogue = true;
        foreach (string dialogue in dialogues) {
            NewDialogue(dialogue);
        }
        canva.transform.GetChild(2).gameObject.SetActive(true); 
    }

    public void SetDialogues(List<string> dia){
        dialogues = dia;
    }

    public NPCLookAt GetLookAt() {
        return npcLookAt;
    }
}
