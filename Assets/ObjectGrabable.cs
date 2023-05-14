using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectGrabable : MonoBehaviour
{
    private Rigidbody objectRigidbody;
    private MeshCollider[] objectColliders;
    private Transform objectGrabPointTransform;
    float initialDrag;
    private Collider[] colliders;

    private void Awake()
    {
        objectRigidbody = GetComponent<Rigidbody>();
        objectColliders = GetComponents<MeshCollider>();
    }
    public void Grab(Transform objectGrabPointTransform)
    {
        this.objectGrabPointTransform = objectGrabPointTransform; 
        objectRigidbody.useGravity = false;
        objectRigidbody.transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 0f);
        objectRigidbody.freezeRotation = true;
        objectRigidbody.isKinematic = true;
        initialDrag = objectRigidbody.drag;
        objectRigidbody.drag = 5f;
        for (int i = 0; i < objectColliders.Length; i++)
        {
            objectColliders[i].enabled = false;
        }
    }

    public void Drop()
    {
        this.objectGrabPointTransform = null;
        objectRigidbody.useGravity = true;
        objectRigidbody.freezeRotation = false;
        objectRigidbody.isKinematic = false;
        objectRigidbody.drag = initialDrag;
        for (int i = 0; i < objectColliders.Length; i++)
        {
            objectColliders[i].enabled = true;
        }
    }

    private void FixedUpdate()
    {
        
        if (objectGrabPointTransform != null)
        {
            float lerpSpeed = 10f;
            Vector3 newposition = Vector3.Lerp(transform.position, objectGrabPointTransform.position, lerpSpeed);
            objectRigidbody.MovePosition(newposition);
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(gameObject.name);
        Debug.Log(collision.gameObject.name);
        
    }
}

