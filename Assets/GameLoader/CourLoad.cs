using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
using UnityEngine.SceneManagement;

public class CourLoad : MonoBehaviour
{
    private FirstPersonController fpscontroller;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject doyenne;
    [SerializeField] private GameObject Fortemps;
    [SerializeField] private GameObject mineGuy;
    [SerializeField] private DoorInteractable porteEntree;
    [SerializeField] private List<GameObject> canvas = new List<GameObject>();
    
    private NPCInteractable mineNPC;
    private Vector3 targetPosition;
    private Vector3 targetPosition2;
    
    public Material skyMaterial;
    public Light light;

    private void Awake() {
        mineNPC = mineGuy.GetComponent<NPCInteractable>();
        targetPosition = transform.GetChild(0).position;
        if (FirstPersonController.MineGame)
        {
            doyenne.SetActive(false);
            player.transform.position = targetPosition;
            player.transform.rotation = Quaternion.Euler(0f,-90f,0f);
            List<string> dia = new List<string>();
            dia.Add("Merci d'avoir récupéré ces matériaux. Nous les utiliserons pour t'aider dans ta quête.");
            mineNPC.SetDialogues(dia);
            FirstPersonController.MineTalk2 = true;
        }
        targetPosition2 = transform.GetChild(1).position;
        if (FirstPersonController.Couloir)
        {
            player.SetActive(false);
            player.transform.position = targetPosition2;
            player.transform.rotation = Quaternion.Euler(0f,180f,0f);
            player.SetActive(true);
            FirstPersonController.Couloir = false;
        }
        
        if (FirstPersonController.MathGame)
        {
            mineGuy.SetActive(false);
            Fortemps.SetActive(true);
            FirstPersonController.FortempsTalk = true;
            RenderSettings.skybox = skyMaterial;
            light.intensity = 0;

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
        player.SetActive(false);
        player.transform.position = transform.Find("StartPoint").position;
        player.transform.rotation =  transform.Find("StartPoint").rotation;
        player.SetActive(true);
    }

}
