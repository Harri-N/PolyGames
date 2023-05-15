using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour
{

    public GameObject resourcePrefab;
    public GameObject animationFx;
    public Transform PrefabSpawn;
    public AudioSource audio;
    
    //Appel de la fonction Tap()
    public void Tapped()
    {
        StartCoroutine(Tap());   
    }

    //Cette fonction lance l'animation de poussière, l'audio des rochers, fait apparaitre les petits cailloux et étruit le plus gros caillou de départ
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
