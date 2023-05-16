using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;



public class Ho12Load : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject mathNPC;
    [SerializeField] private GameObject tableau;
    private FirstPersonController fpscontroller;
    private void Awake() {
        fpscontroller = GetComponent<FirstPersonController>();
        FirstPersonController.Ho12 = true;
        FirstPersonController.Couloir = false;
        transform.Find("StartPoint").position = player.transform.position;
        transform.Find("StartPoint").rotation = player.transform.rotation;
        
        //Si on a finit le jeu de math, on fait apparaitre un PNJ et le tableau
        if(FirstPersonController.MecaGame)
        {
            mathNPC.SetActive(true);
            tableau.SetActive(true);
        }
    }
    
    //Cette fonction permet de faire réapparaitre le personnage 
    public void Reset()
    {
        player.SetActive(false);
        player.transform.position = transform.Find("StartPoint").position;
        player.transform.rotation =  transform.Find("StartPoint").rotation;
        player.SetActive(true);
    }
}
