using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour
{

    public GameObject resourcePrefab;
    public GameObject animationFx;
    public Transform PrefabSpawn;
    public AudioSource audio;

    public void Tapped()
    {
        StartCoroutine(Tap());   
    }

    IEnumerator Tap()
    {   
        yield return new WaitForSeconds(0.25f);
        animationFx.SetActive(true);
        resourcePrefab.SetActive(true);
        audio.Play(0);
        //Instantiate(resourcePrefab, PrefabSpawn.position, PrefabSpawn.rotation);
        Destroy(gameObject, 0.1f);
    }

}
