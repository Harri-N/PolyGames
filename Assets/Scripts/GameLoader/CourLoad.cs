using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
using UnityEngine.SceneManagement;
using TMPro;

//Ce script gère le chargement de la cour et le jeu du dragon

public class CourLoad : MonoBehaviour
{
    private FirstPersonController fpscontroller;
    
    [Header("Joueur")]
    [SerializeField] private GameObject player;

    [Header("PNJ")]
    [SerializeField] private GameObject doyenne;
    [SerializeField] private GameObject Fortemps;
    [SerializeField] private GameObject mineGuy;

    [Header("Jeu Dragon")]
    [SerializeField] private GameObject dragon;
    [SerializeField] private GameObject Flammes;
    [SerializeField] private AudioSource Dragonaudio;
    [SerializeField] private GameObject DragonFlammes;
    [SerializeField] private GameObject gun;
    [SerializeField] private GameObject AimingPoint;
    [SerializeField] private GameObject HealthBar;
    [SerializeField] private GameObject CameraObject;
    [SerializeField] private Transform CameraDragon;
    [SerializeField] private GameObject Camera2;

    [Header("Canva")]
    [SerializeField] private List<GameObject> canvas = new List<GameObject>();
    [SerializeField] private GameObject InGameCanva;
    [SerializeField] private DoorInteractable porteEntree;
    public Animator transition;
    

    [Header("Decor et musique")]
    public Material skyMaterial;
    public Light light;
    public AudioClip drama;
    public AudioSource audio;
    
    
    private Vector3 targetPosition;
    private Vector3 targetPosition2;

    private Vector3 startCamPosition;
    private Quaternion startCamRotation;
    private Vector3 targetDragonPosition;
    private Quaternion targetDragonRotation;
    private Animator animDragon;
    
    

    private float timeRemaining = 60.0f;
    private float timer = 0f;

    private string Lg;

    [SerializeField] private TextMeshProUGUI TimerText;

    private void Awake() {
        
        animDragon = dragon.GetComponent<Animator>();

        targetPosition = transform.GetChild(0).position;
        targetPosition2 = transform.GetChild(1).position;

        //Désactive la doyenne et change la position de départ qd fin du jeu de mine et lance le dialogue
        if (FirstPersonController.MineGame)
        {
            doyenne.SetActive(false);
            player.transform.position = targetPosition;
            player.transform.rotation = Quaternion.Euler(0f,-90f,0f);
            FirstPersonController.MineTalk2 = true;
        }
        
        //Change de position de départ qd on sort du couloir
        if (FirstPersonController.Couloir)
        {
            player.SetActive(false);
            player.transform.position = targetPosition2;
            player.transform.rotation = Quaternion.Euler(0f,180f,0f);
            player.SetActive(true);
            FirstPersonController.Couloir = false;
        }

        //On désactive le PNJ de mine si on a fini le jeu de Meca
        if (FirstPersonController.MecaGame)
        {
            mineGuy.SetActive(false);
        }

        //On change le ciel, la musique 
        //On fait apparaitre le dragon et les flammes et un PNJ Jobs
        if (FirstPersonController.ChimieGame)
        {
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
        //Active le changement de scène vers le jeu de méca
        if(FirstPersonController.etape == 4)
        {
            porteEntree.SetScene("CouloirCar");
        }

        //Lance le jeu et la cinématique du dragon
        if(FirstPersonController.FortempsTalkEnd && !FirstPersonController.DragonGameBegin)
        {
            startCamPosition = CameraObject.transform.position;
            startCamRotation = CameraObject.transform.rotation;
            targetDragonPosition = CameraDragon.transform.position;
            targetDragonRotation = CameraDragon.transform.rotation;
            StartCoroutine(DragonBegin());
        }

        //Décompte du temps si le jeu du dragon commence
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

    //Affichage du timer
    private void Display(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay/60);
        float seconds = Mathf.FloorToInt(timeToDisplay%60);
        if (timeToDisplay >= 0) {TimerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);}
        else {TimerText.text = "00:00";}
    }


    //Cette fonction fait réapparaitre le joueur
    public void Reset()
    {
        player.SetActive(false);
        player.transform.position = transform.Find("StartPoint").position;
        player.transform.rotation =  transform.Find("StartPoint").rotation;
        player.SetActive(true);
    }

    //Cette fonction lance le début du jeu de dragon
    IEnumerator DragonBegin()
    {
        float speed = 1f;
        FirstPersonController.DragonGameBegin = true;
        FirstPersonController.dialogue = true;
        
        //Desactive le joueur et change de caméra pour la cinématique
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

        //Lancement de la cinématique
        animDragon.ResetTrigger("Graou");
        yield return new WaitForSeconds(0.1f);
        DragonFlammes.SetActive(true);
        Dragonaudio.Play(0);
        
        yield return new WaitForSeconds(4f);
        
        //Fin de la cinématique et on active le fusil et la barre de vie 
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
