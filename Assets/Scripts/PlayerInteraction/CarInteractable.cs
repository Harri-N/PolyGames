using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEditor;
using TMPro;

public class CarInteractable : InteractableObject
{
    public GameObject player;
    public GameObject car;
    public GameObject carCamera;

    private bool isInside;
    private AudioSource[] carAudio;
    private float timeLeft;
    private bool canLeave = false;
    private Collider collider;

    private float timeRemaining = 60.0f;
    private float timer = 0.0f;
    [SerializeField] private TextMeshProUGUI TimerText;

    // Start is called before the first frame update
    void Start()
    {
        car = transform.parent.gameObject;
        player = GameObject.FindGameObjectWithTag("Player");
        collider = gameObject.GetComponent<Collider>();
        timeLeft = 1f;
    }

    // Update is called once per frame
    public override void Interact() 
    {
        //Si on entre dans la voitue
        if(!isInside)
        {
            isInside = true;
            StarterAssets.FirstPersonController.MecaCar = true;
            player.transform.parent = car.transform;
            player.SetActive(false);
            collider.enabled = false;
            carCamera.SetActive(true);

            car.GetComponent<CarController>().enabled = true;
            car.GetComponent<CarUserControl>().enabled = true;

            //car.GetComponent<MyCarController>().enabled = true;  Autre script pour controller la voiture (moins soffistiqu�)
            //car.GetComponent<PlayerController>().enabled = true;

            car.GetComponent<CarAudio>().enabled = true;

            timeLeft = 1f;





            //On r�cup�re et on active toutes les audios sources
            carAudio = car.GetComponents<AudioSource>();

            foreach(AudioSource single in carAudio)
            {
                single.enabled = true;
            }
            
        }

        /*
        //Si on sort de la voiture
        if(isInside && canLeave)
        {
            player.transform.parent = null;
            player.SetActive(true);

            carCamera.SetActive(false);
            
            car.GetComponent<CarController>().enabled = false;
            car.GetComponent<CarUserControl>().enabled = false;

            //car.GetComponent<MyCarController>().enabled = false;
            //car.GetComponent<PlayerController>().enabled = false;

            car.GetComponent<CarAudio>().enabled = false;
            
            isInside = false;
            canLeave = false;
            timeLeft = 1f;

            
            foreach (AudioSource single in carAudio)
            {
                single.enabled = false;
            }
            
        }
      
        //D�lais d'attente entre l'entr�e et la sortie de la voiture
        //Permet aussi d'utiliser la m�me touche pour entrer et sortir
        if(timeLeft > 0 && isInside)
        {
            timeLeft -= Time.deltaTime;
            canLeave = false;
        }
        else if(timeLeft <= 0 && isInside)
        {
            canLeave = true;
        }
        */
    }

    private void Update()
    {
        float interactRange = 5f;
        Collider [] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
        foreach (Collider collider in colliderArray) {

            if (!StarterAssets.FirstPersonController.pause && !StarterAssets.FirstPersonController.dialogue && isInside)
            {
                if(collider.TryGetComponent(out DoorInteractable doorInteractable)) {
                    StarterAssets.FirstPersonController.MecaGame = true;
                    
                }
            }
        }
            
        if(isInside && StarterAssets.FirstPersonController.MecaGameBegin && !StarterAssets.FirstPersonController.MecaGame)
        {
            timeRemaining -= Time.deltaTime;
            Display(timeRemaining);
            if (timeRemaining <= 0f)
            {
                StarterAssets.FirstPersonController.GameOver = true;
            }
        }

    }

    private void Display(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay/60);
        float seconds = Mathf.FloorToInt(timeToDisplay%60);
        if (timeToDisplay >= 0) {TimerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);}
        else {TimerText.text = "00:00";}
    }
}