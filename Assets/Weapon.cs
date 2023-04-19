using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int damage;
    public bool canSwing;
    public float swingTime;
    public string swingAnimName;
    public bool Pickaxe;

    // Start is called before the first frame update
    void Start()
    {
        canSwing = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0) && canSwing)
        {
            SWING();
        }
    }

    public void SWING()
    {
        canSwing = false;
        GetComponent<Animation>().Play(swingAnimName);
        StartCoroutine(swingDelay());
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, 4))
        {
            //if(hit.transform.gameObject.GetComponent<AI>()) !=null)
            //{
                //hit.transform.gameObject.GetComponent<AI>().Damage(damage);
            //}
        }

        if (Pickaxe)
        {
            if(hit.collider.tag == "Rock")
            {
                hit.collider.GetComponent<Resource>().Tapped();
            }
        }
    }

    IEnumerator swingDelay()
    {
        yield return new WaitForSeconds(swingTime);
        canSwing = true;
    }
}
