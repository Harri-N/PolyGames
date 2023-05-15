using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
using UnityEngine.SceneManagement;
using TMPro;

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
    [SerializeField] private GameObject HealthBar;
    [SerializeField] private GameObject CameraObject;
    [SerializeField] private GameObject Camera2;
    [SerializeField] private DoorInteractable porteEntree;
    [SerializeField] private List<GameObject> canvas = new List<GameObject>();
    [SerializeField] private Transform CameraDragon;
    [SerializeField] private GameObject Flammes;
    [SerializeField] private AudioSource Dragonaudio;
    [SerializeField] private GameObject InGameCanva;
    [SerializeField] private GameObject DragonFlammes;
    
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
    public Animator transition;

    private float timeRemaining = 60.0f;
    private float timer = 0f;

    private string Lg;

    [SerializeField] private TextMeshProUGUI TimerText;

    private void Awake() {
        
        mineNPC = mineGuy.GetComponent<NPCInteractable>();
        animDragon = dragon.GetComponent<Animator>();

        targetPosition = transform.GetChild(0).position;
        targetPosition2 = transform.GetChild(1).position;

        Lg = FirstPersonController.Language;

        if (FirstPersonController.MineGame)
        {
            doyenne.SetActive(false);
            player.transform.position = targetPosition;
            player.transform.rotation = Quaternion.Euler(0f,-90f,0f);
            mineNPC.SetNPCtxt("Dialogues" + Lg + "_Mine2.txt");
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

        if (FirstPersonController.ChimieGame)
        {
            mineGuy.SetActive(false);
            Fortemps.SetActive(true);
            dragon.SetActive(true);
            FirstPersonController.FortempsTalk = true;
            RenderSettings.skybox = skyMaterial;
            light.intensity = 0;
            audio.clip = drama;
            Flammes.SetActive(true);
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

        if (FirstPersonController.TutoDragonEnd && !FirstPersonController.pause && !FirstPersonController.dialogue && !FirstPersonController.DragonGame)
        {
            timeRemaining -= Time.deltaTime;
            Display(timeRemaining);
            if (timeRemaining <= 0f)
            {
                FirstPersonController.GameOver = true;
            }
            timer += Time.deltaTime;
        }
    }

    private void Display(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay/60);
        float seconds = Mathf.FloorToInt(timeToDisplay%60);
        if (timeToDisplay >= 0) {TimerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);}
        else {TimerText.text = "00:00";}
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
        
        player.SetActive(false);
        transition.SetTrigger("FadeOut");
        yield return new WaitForSeconds(1f);
        Fortemps.SetActive(false);
        Camera2.SetActive(true);
        InGameCanva.SetActive(false);
        DragonFlammes.SetActive(false);
        transition.ResetTrigger("FadeOut");
        animDragon.SetTrigger("Graou");
        yield return new WaitForSeconds(0.1f);


        animDragon.ResetTrigger("Graou");
        yield return new WaitForSeconds(0.1f);
        DragonFlammes.SetActive(true);
        Dragonaudio.Play(0);
        
        yield return new WaitForSeconds(4f);
        

        transition.SetTrigger("FadeOut");
        yield return new WaitForSeconds(1f);
        Camera2.SetActive(false);
        player.SetActive(true);
        InGameCanva.SetActive(true);
        transition.ResetTrigger("FadeOut");
        gun.SetActive(true);
        AimingPoint.SetActive(true);
        HealthBar.SetActive(true);
        yield return new WaitForSeconds(1f);
        FirstPersonController.DragonGameBegin2 = true;
        animDragon.SetTrigger("Move");
        
    }

}
