using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class CouloirLoad : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private AudioClip dramaSound;
    [SerializeField] private AudioSource audio;
    private Vector3 targetPosition11;
    private Vector3 targetPosition12;
    private FirstPersonController fpscontroller;

    private void Awake() {
        fpscontroller = GetComponent<FirstPersonController>();
        FirstPersonController.Couloir = true;
        targetPosition11 = transform.GetChild(0).position;
        targetPosition12 = transform.GetChild(1).position;

        if (FirstPersonController.ChimieGame)
        {
            audio.clip = dramaSound;
            audio.Play();
        }
        if (FirstPersonController.Ho11)
        {   
            player.SetActive(false);
            player.transform.position = targetPosition11;
            player.transform.rotation = Quaternion.Euler(0f, 90f, 0f); 
            FirstPersonController.Ho11 = false;
            player.SetActive(true);
        }

        else if (FirstPersonController.Ho12)
        {
            player.SetActive(false);
            player.transform.position = targetPosition12;
            player.transform.rotation = Quaternion.Euler(0f, 0f, 0f); 
            FirstPersonController.Ho12 = false;
            player.SetActive(true);
        }
        transform.Find("StartPoint").position = player.transform.position;
        transform.Find("StartPoint").rotation = player.transform.rotation;
    }
    
    public void Reset()
    {
        player.SetActive(false);
        player.transform.position = transform.Find("StartPoint").position;
        player.transform.rotation =  transform.Find("StartPoint").rotation;
        player.SetActive(true);
    }

}
