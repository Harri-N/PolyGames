using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class CouloirLoad : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private Vector3 targetPosition11;
    private Vector3 targetPosition12;
    private FirstPersonController fpscontroller;

    private void Awake() {
        fpscontroller = GetComponent<FirstPersonController>();
        FirstPersonController.Couloir = true;
        targetPosition11 = transform.GetChild(0).position;
        targetPosition12 = transform.GetChild(1).position;

        if (FirstPersonController.Ho11)
        {
            player.transform.position = targetPosition11;
            player.transform.rotation = Quaternion.Euler(0f, 180f, 0f); 
            FirstPersonController.Ho11 = false;
        }

        else if (FirstPersonController.Ho12)
        {
            player.transform.position = targetPosition12;
            player.transform.rotation = Quaternion.Euler(0f, 0f, 0f); 
            FirstPersonController.Ho12 = false;
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
