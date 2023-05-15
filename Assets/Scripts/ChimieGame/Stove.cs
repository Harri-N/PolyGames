using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stove : MonoBehaviour

{   private List<Material> materials;

    [SerializeField]
    private List<Renderer> renderers;

    [SerializeField]
    private Color color;

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
            //A single child-object might have mutliple materials on it
            //that is why we need to all materials with "s"
            materials.AddRange(new List<Material>(renderer.materials));
        }
    }
    public bool GetStoveState()
    {
        return stoveState;
    }
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
                //we can just disable the EMISSION
                //if we don't use emission color anywhere else
                material.shader = shader1;
            }
        }
    }
    // Start is called before the first frame update
    
}
