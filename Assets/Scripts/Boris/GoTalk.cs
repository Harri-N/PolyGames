using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoTalk : MonoBehaviour
{
    private bool canTalk = false;
    public GameObject car;
    public GameObject prof;

    // Start is called before the first frame update
    void Start()
    {
        prof = transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (canTalk && Input.GetKeyDown("e"))
        {
            car.SetActive(true);

            prof.GetComponent<TalkToVerlinden>().enabled = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            canTalk = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            canTalk = false;
        }
    }
}
