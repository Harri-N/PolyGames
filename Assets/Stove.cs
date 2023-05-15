using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stove : MonoBehaviour

{   private List<Material> materials;

    [SerializeField]
    private List<Renderer> renderers;

    [SerializeField]
    private Color color = Color.red;

    [SerializeField]
    private Shader shader1;
    [SerializeField]
    private Shader shader2;

    private bool stoveState = false;
    private void Awake()
    {
        materials = new List<Material>();
        foreach (var renderer in renderers)
        {
            materials.AddRange(new List<Material>(renderer.materials));
        }
    }
    //premet aux autres scirpts de connaitre l état du four
    public bool GetStoveState()
    {
        return stoveState;
    }
    //permet d allumer et éteindre le four et change les shaders en fonction de son état
    public void Power(bool val)
    {
        Debug.Log(val);
        stoveState = val;
        if (val)
        {
            Debug.Log("ok");
            foreach (var material in materials)
            {
                
                material.shader = shader2;

            }
        }
        else
        {
            Debug.Log("pas ok");

            foreach (var material in materials)
            {

                material.shader = shader1;
            }
        }
    }

    
}
