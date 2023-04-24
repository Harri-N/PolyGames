using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
using UnityEngine.SceneManagement;

public class CourLoad : MonoBehaviour
{
    private FirstPersonController fpscontroller;
    [SerializeField] private Transform player;
    [SerializeField] private NPCInteractable mineGuy;
    [SerializeField] private List<GameObject> canvas = new List<GameObject>();
    private Vector3 targetPosition;
    private Vector3 targetPosition2;


    private void Awake() {
        fpscontroller = GetComponent<FirstPersonController>();
        //npcLookAt = mineGuy.GetComponent<NPCLookAt>();
        targetPosition = transform.GetChild(0).position;
        if (FirstPersonController.MineGame)
        {
            player.transform.position = targetPosition;
            player.transform.Rotate(0,-84,0);
            List<string> dia = new List<string>();
            dia.Add("Merci d'avoir récupéré ces matériaux. Nous les utiliserons pour t'aider dans ta quête.");
            mineGuy.SetDialogues(dia);
            FirstPersonController.MineTalk2 = true;
        }
        targetPosition2 = transform.GetChild(1).position;
        if (FirstPersonController.Couloir)
        {
            player.transform.position = targetPosition2;
            player.transform.Rotate(0,180,0);
            FirstPersonController.Couloir = false;
        }
    }

}
