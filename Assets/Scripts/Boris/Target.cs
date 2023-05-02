using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class Target : MonoBehaviour
{

    public GameObject dragon;

    public float health = 50f;

    public void TakeDamage(float amount)
    {
        health -= amount;
        Debug.Log("Damage");
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
