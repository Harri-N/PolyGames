using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

public class TalkToVerlinden : MonoBehaviour
{
    public GameObject prof;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Bonjour ! Je suis Mr. Verlinden, professeur dans le service de mécanique.");
        Debug.Log("Pour t'aider à te déplacer plus vite dans ta quête de combat contre le dragon, je te laisse utiliser la voiture Eco Shell.");
        Debug.Log("Utilise la pour te rendre à l'auditoire 11. Dépêche toi, Mr. Decroly t'y attends déjà !");

        prof.GetComponent<TalkToVerlinden>().enabled = false;
    }

}
