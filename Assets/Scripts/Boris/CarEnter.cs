using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEditor;
using StarterAssets;

public class CarEnter : MonoBehaviour
{
    public GameObject player;
    public GameObject car;
    public GameObject carCamera;

    private bool canEnter;
    private bool isInside;
    private AudioSource[] carAudio;
    private float timeLeft;
    //private bool canLeave = false;

    private StarterAssets.FirstPersonController fpscontroller;
    
    private void Awake() {
        fpscontroller = GetComponent<StarterAssets.FirstPersonController>();
        isInside = false;
        timeLeft = 60f;
    }

    // Start is called before the first frame update
    void Start()
    {
        car = transform.parent.gameObject;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //Si on entre dans la voitue
        if(StarterAssets.FirstPersonController.MecaTalkEnd && !isInside)
        {
            isInside = true;

            player.transform.parent = car.transform;
            player.SetActive(false);

            carCamera.SetActive(true);

            car.GetComponent<CarController>().enabled = true;
            car.GetComponent<CarUserControl>().enabled = true;

            //car.GetComponent<MyCarController>().enabled = true;  Autre script pour controller la voiture (moins soffistiqu�)
            //car.GetComponent<PlayerController>().enabled = true;

            car.GetComponent<CarAudio>().enabled = true;


            //On r�cup�re et on active toutes les audios sources
            carAudio = car.GetComponents<AudioSource>();

            foreach(AudioSource single in carAudio)
            {
                single.enabled = true;
            }
            
        }

        float interactRange = 5f;
        Collider [] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
        foreach (Collider collider in colliderArray) {

            if (!StarterAssets.FirstPersonController.pause && !StarterAssets.FirstPersonController.dialogue && isInside)
            {
                if(collider.TryGetComponent(out DoorInteractable doorInteractable)) {
                    StarterAssets.FirstPersonController.MecaGame = true;
                    
                }
            }
        if(isInside && timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft == 0 && !StarterAssets.FirstPersonController.MecaGame)
            {
                StarterAssets.FirstPersonController.GameOver = true;
                isInside = false;
                timeLeft = 60f;
            }
        }

            
            
        }
    }
}
