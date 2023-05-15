using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
using UnityEngine.UI;


public class Target : MonoBehaviour
{
    public Image healthBar; //Image de la bar de vie du dragon

    public GameObject dragon; //Objet de l'ennemi

    public float startHealth = 100f; //Vie de départ 

    private float health; //Vie actuelle


    public void Start()
    {
        health = startHealth; //Au début on fixe la vie à la vie de départ
    }

    //Fonction permettant de faire perdre de la vie à l'ennemi en fonction d'un certain nombre de damage
    public void TakeDamage(float amount)
    {
        health -= amount; 

        healthBar.fillAmount = health / startHealth; //Pour diminiuer la barre de vie visuelle

        //Si on a plus de vie, on meurt
        if(health <= 0f)
        {
            Die();
        }
    }

    //Désactive l'ennemi
    void Die()
    {
        dragon.SetActive(false);
        FirstPersonController.DragonGame = true;
    }
  
}
