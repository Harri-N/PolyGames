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
    [SerializeField] private GameObject dragon;
    [SerializeField] private GameObject gun;
    [SerializeField] private GameObject AimingPoint;
    [SerializeField] private GameObject CameraObject;
    [SerializeField] private GameObject Camera2;
    [SerializeField] private DoorInteractable porteEntree;
    [SerializeField] private List<GameObject> canvas = new List<GameObject>();
    [SerializeField] private Transform CameraDragon;
    
    private NPCInteractable mineNPC;
    private Vector3 targetPosition;
    private Vector3 targetPosition2;

    private Vector3 startCamPosition;
    private Quaternion startCamRotation;
    private Vector3 targetDragonPosition;
    private Quaternion targetDragonRotation;
    private Animator animDragon;
    
    public Material skyMaterial;
    public Light light;
    public AudioClip drama;
    public AudioSource audio;

    private void Awake() {
        
        mineNPC = mineGuy.GetComponent<NPCInteractable>();
        animDragon = dragon.GetComponent<Animator>();

        targetPosition = transform.GetChild(0).position;
        targetPosition2 = transform.GetChild(1).position;

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
        
        if (FirstPersonController.Couloir)
        {
            player.SetActive(false);
            player.transform.position = targetPosition2;
            player.transform.rotation = Quaternion.Euler(0f,180f,0f);
            player.SetActive(true);
            FirstPersonController.Couloir = false;
            //FirstPersonController.MathGame = true;
        }

        if (FirstPersonController.MathGame)
        {
            mineGuy.SetActive(false);
            Fortemps.SetActive(true);
            dragon.SetActive(true);
            FirstPersonController.FortempsTalk = true;
            RenderSettings.skybox = skyMaterial;
            light.intensity = 0;
            audio.clip = drama;
            audio.Play();
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

        if(FirstPersonController.FortempsTalkEnd && !FirstPersonController.DragonGameBegin)
        {
            startCamPosition = CameraObject.transform.position;
            startCamRotation = CameraObject.transform.rotation;
            targetDragonPosition = CameraDragon.transform.position;
            targetDragonRotation = CameraDragon.transform.rotation;
            StartCoroutine(DragonBegin());
        }
    }

    public void Reset()
    {
        player.SetActive(false);
        player.transform.position = transform.Find("StartPoint").position;
        player.transform.rotation =  transform.Find("StartPoint").rotation;
        player.SetActive(true);
    }

    IEnumerator DragonBegin()
    {
        float speed = 1f;
        FirstPersonController.DragonGameBegin = true;
        FirstPersonController.dialogue = true;
        /*
        Camera2.transform.position = startCamPosition;
        Camera2.transform.rotation = startCamRotation;
        player.SetActive(false);
        Camera2.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        /*while(Camera2.transform.position != targetDragonPosition || Camera2.transform.rotation != targetDragonRotation)
        {
            
        }
        Camera2.transform.position = Vector3.Lerp(Camera2.transform.position, targetDragonPosition, Time.deltaTime * speed);
        Camera2.transform.rotation = Quaternion.Lerp(Camera2.transform.rotation, targetDragonRotation, Time.deltaTime * speed);    
        
        yield return new WaitForSeconds(4f);
        gun.SetActive(true);
        /*while(Camera2.transform.position != startCamPosition || Camera2.transform.rotation != startCamRotation)
        {
            
        }
        Camera2.transform.position = Vector3.Lerp(Camera2.transform.position, startCamPosition, Time.deltaTime * speed);
        Camera2.transform.rotation = Quaternion.Lerp(Camera2.transform.rotation, startCamRotation, Time.deltaTime * speed);    
        yield return new WaitForSeconds(2f);
        player.SetActive(true);
        Camera2.SetActive(false);
        */
        gun.SetActive(true);
        AimingPoint.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        FirstPersonController.DragonGameBegin2 = true;
        yield return new WaitForSeconds(10f);
        animDragon.SetTrigger("Move");
        Fortemps.SetActive(false);
    }

}
