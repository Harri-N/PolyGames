using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
using UnityEngine.UI;


public class Target : MonoBehaviour
{
    public Image healthBar;

    public GameObject dragon;

    public float startHealth = 100f;

    private float health;


    public void Start()
    {
        health = startHealth;
    }

    public void TakeDamage(float amount)
    {
        health -= amount;

        healthBar.fillAmount = health / startHealth;

        if(health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        dragon.SetActive(false);
        FirstPersonController.DragonGame = true;
    }
  
}
