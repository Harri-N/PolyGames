using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using StarterAssets;

public class Pioche : MonoBehaviour
{
    private FirstPerson playerControls;
    private InputAction swing;
    private FirstPersonController fpscontroller;
    private Animator anim;

    public bool canSwing;
    public float swingTime = 0.8f;
    public bool Pickaxe = true;

    
    void Awake(){
        playerControls = new FirstPerson();
        fpscontroller = GetComponent<FirstPersonController>();
        anim = GetComponent<Animator>();
        canSwing = true;
    }
    
    private void OnEnable()
    {
        swing = playerControls.Player.Swing;
        swing.Enable();

        swing.performed += Swing;
    }

    private void OnDisable()
    {
        swing.Disable();
    }
/*
    private void Update() 
    {
        if(FirstPersonController.m_IsWalking){
            anim.SetBool("Walk", true);
            //anim.speed = fpscontroller.GetSpeed();
        }
        else {
            anim.SetBool("Walk", false);
            anim.speed = 1f;
        }

    }
*/
    public void Swing(InputAction.CallbackContext context)
    {
        if (canSwing && Pickaxe && !FirstPersonController.pause && !FirstPersonController.dialogue)
        {
            canSwing = false;
            StartCoroutine(swingDelay());
            anim.SetTrigger("Swing");

            float interactRange = 1f;
            Collider [] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
            foreach (Collider collider in colliderArray) {
                if(collider.TryGetComponent(out Resource resource)) {    
                    Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
                    RaycastHit hit;

                    if(Physics.Raycast(ray, out hit, 4))
                    {
                        //if(hit.transform.gameObject.GetComponent<AI>()) !=null)
                        //{
                            //hit.transform.gameObject.GetComponent<AI>().Damage(damage);
                        //}
                    }
                    
                
                    if(hit.collider.tag == "Rock")
                    {
                        hit.collider.GetComponent<Resource>().Tapped();
                    }
                    
                }
            }
        }

    }
    
    IEnumerator swingDelay()
    {
        yield return new WaitForSeconds(swingTime);
        canSwing = true;
        anim.ResetTrigger("Swing");
        anim.Play("PiocheIdle");
    }
}
