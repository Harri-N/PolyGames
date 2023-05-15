using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;
using StarterAssets;

public class ProjectileGun : MonoBehaviour
{
    public GameObject gun;

    //bullet
    public GameObject bullet;

    //bullet force
    public float shootForce, upwardForce;

    //gun stats
    public float timeBetweenShooting, spread, reloadTime, timeBetweenShots;
    public int magazineSize, bulletsPerTap;
    public bool allowButtonHold;

    int bulletsLeft, bulletsShot;

    //recoil
    public Rigidbody playerRb;
    public float recoilForce;

    //bools
    bool shooting, readyToShoot, reloading;

    //reference
    public Camera fpsCam;
    public Transform attackPoint;

    //graphics
    public GameObject muzzleFlash;
    public TextMeshProUGUI ammunitionDisplay;

    //bug fixing :D
    public bool allowInvoke = true;

    //New Input System
    private FirstPerson playerControls;
    private InputAction fire;
    private FirstPersonController fpscontroller;

    private void Awake()
    {
        //make sure magazine is full
        bulletsLeft = magazineSize;
        readyToShoot = true;

        playerControls = new FirstPerson();
        fpscontroller = GetComponent<FirstPersonController>();
    }


    private void OnEnable()
    {
        fire = playerControls.Player.Fire;
        fire.Enable();
        
        fire.performed += Shoot;
    }

    private void OnDisable()
    {
        fire.Disable();
    }

    
    //Bout de code rendant l'arme très réaliste (recharger, etc)
/*
    private void Update()
    {
        MyInput();

        //set ammo display, if it exists :D
        if (ammunitionDisplay != null)
        {
            ammunitionDisplay.SetText(bulletsLeft / bulletsPerTap + " / " + magazineSize / bulletsPerTap);
        }
    }

    private void MyInput()
    {
        //check if allowed to hold down button and take corresponding input
        if (allowButtonHold)
        {
            shooting = Input.GetKey(KeyCode.Mouse0);
        }
        else
        {
            shooting = Input.GetKeyDown(KeyCode.Mouse0);
        }

        //Reloading
        if(Input.GetKeyDown(KeyCode.R) && bulletsLeft < magazineSize && !reloading)
        {
            Reload();
        }
        //Reload automatically when trying to shoot without ammo
        if(readyToShoot && shooting && !reloading && bulletsLeft <= 0)
        {
            Reload();
        }

        //shotting
        if(readyToShoot && shooting && !reloading && bulletsLeft > 0)
        {
            //set bullets shot to 0
            bulletsShot = 0;

            Shoot();
        }
    }
*/
    private void Shoot(InputAction.CallbackContext context)
    {
        if (!FirstPersonController.dialogue && !FirstPersonController.pause)
        {
            readyToShoot = false;

            //find the exact hit position using a raycast
            Ray ray = fpsCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0)); //just a ray through the middle of your screen
            RaycastHit hit;

            //check if ray hits something
            Vector3 targetPoint;
            if(Physics.Raycast(ray, out hit))
            {
                targetPoint = hit.point;
            }
            else
            {
                targetPoint = ray.GetPoint(75); //just a point far away from the player
            }

            //calculate direction from attackPoint to targetPoint
            Vector3 directionWithoutSpread = targetPoint - attackPoint.position;

            //calculate spread
            float x = Random.Range(-spread, spread);
            float y = Random.Range(-spread, spread);

            //calculate new direction with spread
            Vector3 directionWithSpread = directionWithoutSpread + new Vector3(x, y, 0); //just add spread to last direction 

            //Instantiate bullet/projectile
            GameObject currentBullet = Instantiate(bullet, attackPoint.position, Quaternion.identity); //store instantiated bullet 
            //rotate bullet to shoot direction
            currentBullet.transform.forward = directionWithSpread.normalized;

            //add forces to bullet
            currentBullet.GetComponent<Rigidbody>().AddForce(directionWithSpread.normalized * shootForce, ForceMode.Impulse);
            currentBullet.GetComponent<Rigidbody>().AddForce(fpsCam.transform.up * upwardForce, ForceMode.Impulse);

            //Instantiate muzzle flash, if you have one
            if(muzzleFlash != null)
            {
                GameObject currentMuzzleFlash = Instantiate(muzzleFlash, attackPoint.position, Quaternion.identity);

                KillBulletAndMuzzleFlash(currentBullet, currentMuzzleFlash);
            }

            bulletsLeft--;
            bulletsShot++;

            //Invoke resetShot function (if not already invoked), with your timeBetweenShooting
            if (allowInvoke)
            {
                Invoke("ResetShot", timeBetweenShooting);
                allowInvoke = false;

                //add recoilto player
                //playerRb.AddForce(-directionWithSpread.normalized * recoilForce, ForceMode.Impulse);
            }

            //if more than one bulletPerTap make sure to repeat shoot function
            if (bulletsShot < bulletsPerTap && bulletsLeft > 0)
            {
                Invoke("Shoot", timeBetweenShots);
            }

            //Sound of shot
            gun.GetComponent<AudioSource>().Play();
        }
    }

    private void ResetShot()
    {
        //Allow shooting and invoking again
        readyToShoot = true;
        allowInvoke = true;
    }

    private void Reload()
    {
        reloading = true;
        Invoke("ReloadFinished", reloadTime);
    }

    private void ReloadFinished()
    {
        bulletsLeft = magazineSize;
        reloading = false;
    }

    private void KillBulletAndMuzzleFlash(GameObject currentBullet, GameObject currentMuzzleFlash)
    {
        Destroy(currentBullet, 5f);
        Destroy(currentMuzzleFlash, 5f);
    }

}
