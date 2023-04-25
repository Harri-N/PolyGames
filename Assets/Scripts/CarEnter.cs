using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEditor;


public class CarEnter : MonoBehaviour
{
    public GameObject player;
    public GameObject car;
    public GameObject carCamera;

    private bool canEnter;
    private bool isInside;
    private AudioSource[] carAudio;
    private float timeLeft;
    private bool canLeave = false;

    // Start is called before the first frame update
    void Start()
    {
        car = transform.parent.gameObject;
        player = GameObject.FindGameObjectWithTag("Player");
        timeLeft = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        //Si on entre dans la voitue
        if(canEnter && Input.GetKeyDown("e"))
        {
            isInside = true;

            player.transform.parent = car.transform;
            player.SetActive(false);

            carCamera.SetActive(true);

            car.GetComponent<CarController>().enabled = true;
            car.GetComponent<CarUserControl>().enabled = true;

            //car.GetComponent<MyCarController>().enabled = true;  Autre script pour controller la voiture (moins soffistiqué)
            //car.GetComponent<PlayerController>().enabled = true;

            car.GetComponent<CarAudio>().enabled = true;

            timeLeft = 1f;





            //On récupère et on active toutes les audios sources
            carAudio = car.GetComponents<AudioSource>();

            foreach(AudioSource single in carAudio)
            {
                single.enabled = true;
            }
            
        }

        //Si on sort de la voiture
        if(isInside && canLeave && Input.GetKeyDown("e"))
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
      
        //Délais d'attente entre l'entrée et la sortie de la voiture
        //Permet aussi d'utiliser la même touche pour entrer et sortir
        if(timeLeft > 0 && isInside)
        {
            timeLeft -= Time.deltaTime;
            canLeave = false;
        }
        else if(timeLeft <= 0 && isInside)
        {
            canLeave = true;
        }
    }

    //Detection du joueur dans le cube d'entrée
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            canEnter = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            canEnter = false;
        }
    }
}
