using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

//Ce script stocke la position de départ du joueur et de l'erlenmeyer, la pipette, le caillou pour permettre de réapparaitre à cet endroit

public class Ho11Load : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject Rock;
    [SerializeField] private GameObject pipette;
    [SerializeField] private GameObject Erlenmyer;
    [SerializeField] private GameObject ChimieNPC;
    [SerializeField] private GameObject tableau;
    [SerializeField] private GameObject four;

    private FirstPersonController fpscontroller;
    private void Awake() {
        fpscontroller = GetComponent<FirstPersonController>();
        FirstPersonController.Ho11 = true;
        FirstPersonController.Couloir = false;
        transform.Find("StartPoint").position = player.transform.position;
        transform.Find("StartPoint").rotation = player.transform.rotation;

        transform.Find("p1").position = Rock.transform.position;
        transform.Find("p2").position = pipette.transform.position;
        transform.Find("p3").position = Erlenmyer.transform.position;
        transform.Find("p1").rotation = Rock.transform.rotation;
        transform.Find("p2").rotation = pipette.transform.rotation;
        transform.Find("p3").rotation = Erlenmyer.transform.rotation;
        
        //Si on a fini le jeu de math, on fait apparaitre un tableau, le four et un PNJ
        if(FirstPersonController.MathGame)
        {
            tableau.SetActive(true);
            ChimieNPC.SetActive(true);
            four.SetActive(true);
        }
        
    }

    public void Reset()
    {
        player.SetActive(false);
        player.transform.position = transform.Find("StartPoint").position;
        player.transform.rotation =  transform.Find("StartPoint").rotation;
        player.SetActive(true);

        FirstPersonController.Release = true;
        Rock.transform.position = transform.Find("p1").position;
        pipette.transform.position = transform.Find("p2").position;
        Erlenmyer.transform.position = transform.Find("p3").position;

        Rock.transform.rotation = transform.Find("p1").rotation;
        pipette.transform.rotation = transform.Find("p2").rotation;
        Erlenmyer.transform.rotation = transform.Find("p3").rotation;
    }
}
