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
        Debug.Log("Bonjour ! Je suis Mr. Verlinden, professeur dans le service de m�canique.");
        Debug.Log("Pour t'aider � te d�placer plus vite dans ta qu�te de combat contre le dragon, je te laisse utiliser la voiture Eco Shell.");
        Debug.Log("Utilise la pour te rendre � l'auditoire 11. D�p�che toi, Mr. Decroly t'y attends d�j� !");

        prof.GetComponent<TalkToVerlinden>().enabled = false;
    }

}
