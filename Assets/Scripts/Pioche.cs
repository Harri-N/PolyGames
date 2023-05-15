using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using StarterAssets;

//script permettant d'associer l'action de la pioche � une fonction
public class Pioche : MonoBehaviour
{
    private FirstPerson playerControls;
    private InputAction swing;
    private FirstPersonController fpscontroller;
    private Animator anim;

    public bool canSwing;
    public float swingTime = 0.8f;
    public bool Pickaxe = true;

    
    //on d�finit le Controller du player et l'Animator
    void Awake(){
        playerControls = new FirstPerson();
        fpscontroller = GetComponent<FirstPersonController>();
        anim = GetComponent<Animator>();
        canSwing = true;
    }
    
    //Fonction appel�e quand le Swing est activ�
    private void OnEnable()
    {
        swing = playerControls.Player.Swing;
        swing.Enable();

        swing.performed += Swing;
    }

    //Fonction appel�e quand le Swing est d�sactiv�
    private void OnDisable()
    {
        swing.Disable();
    }

    //Fonction d�finissant l'action Swing
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
                    
                    
                    //Quand on frappe un objet avec la pioche est que celui-ci est un rocher (tag = "Rock"
                    //La fonction Tapped() de cet objet est appel�e (elle permet la destruction de l'objet)
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
