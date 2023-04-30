using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class MineLoad : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private FirstPersonController fpscontroller;

    private void Awake() {
        fpscontroller = GetComponent<FirstPersonController>();
        FirstPersonController.MineTalkEnd = true;
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
