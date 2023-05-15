using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class Ho12Load : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private FirstPersonController fpscontroller;
    private void Awake() {
        fpscontroller = GetComponent<FirstPersonController>();
        FirstPersonController.Ho12 = true;
        FirstPersonController.Couloir = false;
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
