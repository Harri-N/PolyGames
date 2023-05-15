using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using StarterAssets;

public class Player : MonoBehaviour
{
    // Layer of the pickable objects
    [SerializeField] private LayerMask pickableLayerMask;
    // For de Raycast origin
    //[SerializeField] private Transform playerCameraTransform;
    // Display the key to press
    [SerializeField] private GameObject pickUpUI;
    [SerializeField] private GameObject useUI;
    [SerializeField] private GameObject useUI2;
    [SerializeField] private GameObject useUI3;
    [SerializeField] private GameObject dropUI;
    [SerializeField] private GameObject pipette;
    [SerializeField] private GameObject rocks;
    // Range 
    [SerializeField][Min(1)] private float hitRange;

    [SerializeField] private Transform pickUpParent;

    [SerializeField] private GameObject inHandItem;


    private RaycastHit hit;
    private RaycastHit currentHit;
    private RaycastHit currentHit2;

    private void Awake()
    {
        inHandItem = null;
    }

    private void Update()
    {
        if(!FirstPersonController.dialogue && !FirstPersonController.pause)
        {
            if(hit.collider != null && inHandItem == null)
            {
                hit.collider.GetComponent<Highlight>()?.ToggleHighlight(false);
                dropUI.SetActive(false);
                pickUpUI.SetActive(false);
                useUI.SetActive(false);
                useUI2.SetActive(false);
                useUI3.SetActive(false);
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
            if (inHandItem != null)
            {
                dropUI.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E) || FirstPersonController.Release)
                {
                    FirstPersonController.Release = false;
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
                                pipette.SetActive(false);
                                inHandItem = null;
                                return;
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
                            dropUI.SetActive(false);
                            useUI.SetActive(true);
                        }
                        
                    }
                    
                }
                if (inHandItem.GetComponent<Rock>())
                {
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
                                rocks.SetActive(false);
                                inHandItem = null;
                                return;
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
                            dropUI.SetActive(false);
                            useUI2.SetActive(true);
                        }

                    }

                }

                return;
            }
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
                    dropUI.SetActive(false);
                    useUI3.SetActive(true);
                }
                else
                {
                    dropUI.SetActive(false);
                    pickUpUI.SetActive(true);
                }
                
                    
            }
        }
    }
}
