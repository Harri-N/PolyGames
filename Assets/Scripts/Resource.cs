using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour
{

    public GameObject resourcePrefab;
    public Transform PrefabSpawn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Tapped()
    {
        resourcePrefab.SetActive(true);
        //Instantiate(resourcePrefab, PrefabSpawn.position, PrefabSpawn.rotation);
        Destroy(gameObject, 0.5f);
        
    }

}
