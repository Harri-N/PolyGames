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
    [SerializeField] private DoorInteractable porteEntree;
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
            player.transform.rotation = Quaternion.Euler(0f,-90f,0f);
            List<string> dia = new List<string>();
            dia.Add("Merci d'avoir récupéré ces matériaux. Nous les utiliserons pour t'aider dans ta quête.");
            mineGuy.SetDialogues(dia);
            FirstPersonController.MineTalk2 = true;
        }
        targetPosition2 = transform.GetChild(1).position;
        if (FirstPersonController.Couloir)
        {
            player.transform.position = targetPosition2;
            player.transform.rotation = Quaternion.Euler(0f,180f,0f);
            FirstPersonController.Couloir = false;
        }
        transform.Find("StartPoint").position = player.transform.position;
        transform.Find("StartPoint").rotation = player.transform.rotation;
    }

    private void Update()
    {
        if(FirstPersonController.etape == 4)
        {
            porteEntree.SetScene("CouloirCar");
        }
    }

    public void Reset()
    {
        player.transform.position = transform.Find("StartPoint").position;
        player.transform.rotation =  transform.Find("StartPoint").rotation;
    }

}
