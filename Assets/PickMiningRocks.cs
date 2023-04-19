using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickMiningRocks : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 3))
            {
                Destroy(gameObject, 2.0f);
            }
        }
    }

}
