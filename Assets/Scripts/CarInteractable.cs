using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEditor;

public class CarInteractable : InteractableObject
{
    public GameObject player;
    public GameObject car;
    public GameObject carCamera;

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
    public void EnterCar()
    {
        //Si on entre dans la voitue
        if(!isInside)
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

            timeLeft = 1f;





            //On r�cup�re et on active toutes les audios sources
            carAudio = car.GetComponents<AudioSource>();

            foreach(AudioSource single in carAudio)
            {
                single.enabled = true;
            }
            
        }

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
    }
}
