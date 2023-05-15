using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Layer des objets avec lesquels ont peut interagir
    [SerializeField] private LayerMask pickableLayerMask;
    //origine du Raycast
    //[SerializeField] private Transform playerCameraTransform;
    //lien vers les différents éléments du UI
    [SerializeField] private GameObject pickUpUI;
    [SerializeField] private GameObject useUI;
    [SerializeField] private GameObject useUI2;
    [SerializeField] private GameObject useUI3;
    // Range 
    [SerializeField][Min(1)] private float hitRange;
    // lien vers le player
    [SerializeField] private Transform pickUpParent;
    // lien vers l item que le player à en main
    [SerializeField] private GameObject inHandItem;

    // différent Raycast dont on aura besoin
    private RaycastHit hit;
    private RaycastHit currentHit;
    private RaycastHit currentHit2;
    //initialise l objet en main comme étant null
    private void Awake()
    {
        inHandItem = null;
    }
    
    //à chaque frame on va regarder avec quoi rentre en collision le Raycast pour agir en fonction 
    private void Update()
    {
        
        if(hit.collider != null && inHandItem == null)
        {
        //reset les UI to false
            hit.collider.GetComponent<Highlight>()?.ToggleHighlight(false);
            pickUpUI.SetActive(false);
            useUI.SetActive(false);
            useUI2.SetActive(false);
            useUI3.SetActive(false);
            //prend en main l objet
            Rigidbody rigidbody = hit.collider.GetComponent<Rigidbody>();
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (hit.collider.GetComponent<Rock>())
                {
                    Debug.Log("C'est une pierre !");
                    inHandItem = hit.collider.gameObject;
                    inHandItem.transform.position = Vector3.zero;
                    inHandItem.transform.rotation = Quaternion.identity;
                    inHandItem.transform.SetParent(pickUpParent, false);
                    if(rigidbody != null)
                    {
                        rigidbody.isKinematic = true;
                    }
                    return;
                }
                if (hit.collider.GetComponent<Pipette>())
                {
                    Debug.Log("C'est une pipette !");
                    inHandItem = hit.collider.gameObject;
                    inHandItem.transform.position = Vector3.zero;
                    inHandItem.transform.rotation = Quaternion.identity;
                    inHandItem.transform.SetParent(pickUpParent, false);
                    if(rigidbody != null)
                    {
                        rigidbody.isKinematic = true;
                    }
                    return;
                }
                if (hit.collider.GetComponent<Flask>())
                {
                    Debug.Log("C'est une flask !");
                    inHandItem = hit.collider.gameObject;
                    inHandItem.transform.position = Vector3.zero;
                    inHandItem.transform.rotation = Quaternion.identity;
                    inHandItem.transform.SetParent(pickUpParent, false);
                    if(rigidbody != null)
                    {
                        rigidbody.isKinematic = true;
                    }
                    return;
                }
                if (hit.collider.GetComponent<Stove>())
                {
                    Debug.Log("Allumer le feu");
                    Boolean stoveState;
                    stoveState = !hit.collider.GetComponent<Stove>().GetStoveState();
                    Debug.Log(stoveState.GetType());
                    hit.collider.GetComponent<Stove>().Power(stoveState);
                }
            }
        }
        //si le player a qqch en main 
        if (inHandItem != null)
        {
            //on le lache quand on appuie sur E
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("");
                Rigidbody rigidbody = hit.collider.GetComponent<Rigidbody>();
                //
                Debug.Log(inHandItem.transform);
                inHandItem.transform.SetParent(null);
                Debug.Log(inHandItem.transform);
                //inHandItem.transform.position = rigidbody.transform.position;
                inHandItem = null;
                Debug.Log(inHandItem);


                if (rigidbody != null)
                {
                    rigidbody.isKinematic = false;
                }
                return;
            }
            //si c est un pipette et que l on presse R on l utilise grace à la fonction Fill de Flask.cs
            if (inHandItem.GetComponent<Pipette>())
            {
                if (currentHit.collider != null)
                {
                    currentHit.collider.GetComponent<Highlight>()?.ToggleHighlight(false);
                    useUI.SetActive(false);
                    if (currentHit.collider.GetComponent<Flask>() != null)
                    {
                        if (Input.GetKeyDown(KeyCode.R))
                        {
                            Debug.Log("R");
                            currentHit.collider.GetComponent<Flask>().Fill(true);
                        }
                    }
                    
                }
                
                if (Physics.Raycast(
                    Camera.main.transform.transform.position,
                    Camera.main.transform.transform.forward,
                    out currentHit,
                    hitRange,
                    pickableLayerMask))
                {
                    if(currentHit.collider.GetComponent<Flask>() != null)
                    {
                        currentHit.collider.GetComponent<Highlight>()?.ToggleHighlight(true);
                        useUI.SetActive(true);
                    }
                    
                }
                
            }
            if (inHandItem.GetComponent<Rock>())
            {
                //si c est un rock et que l on presse R on l utilise grace à la fonction Full de Flask.cs
                if (currentHit2.collider != null)
                {
                    currentHit2.collider.GetComponent<Highlight>()?.ToggleHighlight(false);
                    useUI2.SetActive(false);
                    if (currentHit2.collider.GetComponent<Flask>() != null)
                    {
                        if (Input.GetKeyDown(KeyCode.R))
                        {
                            Debug.Log("R");
                            currentHit2.collider.GetComponent<Flask>().Full(true);
                        }
                    }

                }

                if (Physics.Raycast(
                    Camera.main.transform.transform.position,
                    Camera.main.transform.transform.forward,
                    out currentHit2,
                    hitRange,
                    pickableLayerMask))
                {
                    if (currentHit2.collider.GetComponent<Flask>() != null)
                    {
                        currentHit2.collider.GetComponent<Highlight>()?.ToggleHighlight(true);
                        useUI2.SetActive(true);
                    }

                }

            }

            return;
        }
        //check la collision du Raycast
        if (Physics.Raycast(
            Camera.main.transform.transform.position,
            Camera.main.transform.transform.forward,
            out hit,
            hitRange,
            pickableLayerMask))
        {
            hit.collider.GetComponent<Highlight>()?.ToggleHighlight(true);
            if(hit.collider.GetComponent<Stove>() != null)
            {
                useUI3.SetActive(true);
            }
            else
            {
                pickUpUI.SetActive(true);
            }
            
                   
        }
    }
}
