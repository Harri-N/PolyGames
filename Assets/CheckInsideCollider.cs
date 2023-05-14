using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckInsideCollider : MonoBehaviour
{
    private Collider[] colliders;
    // Start is called before the first frame update
    private void Start()
    {
       //Collider[] colliders = Physics.OverlapSphere(transform.position, 0f);
       // foreach (Collider collider in colliders)
       // {
       //     //Debug.Log(collider.gameObject.name);
       //     ObjectGrabable grabableCollider = collider.gameObject.GetComponent<ObjectGrabable>();
       //     if (grabableCollider != null)
       //     {
       //         Debug.Log(grabableCollider.gameObject.name);
       //     }

       // } 
    }

    // Update is called once per frame
    private void Update()
    {
        
    }
    private void OnTriggerEnter(Collider collider)
    {
        Debug.Log(collider.gameObject.name);
    }
}
