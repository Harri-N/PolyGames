using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class Flask : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private List<Renderer> renderers;

    [SerializeField]
    private Color color;
    [SerializeField]
    private Color brownColor;
    [SerializeField]
    private Color readyColor;
    [SerializeField]
    public GameObject parent;
    //helper list to cache all the materials ofd this object
    private List<Material> materials;
    
    //Gets all the materials from each renderer
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

    public void Fill(bool val)
    {
        if (val)
        {
            foreach (var material in materials)
            {
                //We need to enable the EMISSION
                material.EnableKeyword("_EMISSION");
                //before we can set the color
                if (material.GetColor("_EmissionColor") == brownColor)
                {
                    material.SetColor("_EmissionColor", readyColor);
                }
                else if (material.GetColor("_EmissionColor") != readyColor)
                {
                    material.SetColor("_EmissionColor", color);
                }
                
            }
        }
        else
        {
            foreach (var material in materials)
            {
                //we can just disable the EMISSION
                //if we don't use emission color anywhere else
                material.DisableKeyword("_EMISSION");
            }
        }

    }

    public void Full(bool val)
    {
        if (val)
        {
            foreach (var material in materials)
            {
                //We need to enable the EMISSION
                material.EnableKeyword("_EMISSION");
                //before we can set the color
                if (material.GetColor("_EmissionColor") == color)
                {
                    material.SetColor("_EmissionColor", readyColor);
                }
                else if (material.GetColor("_EmissionColor") != readyColor)
                {
                    material.SetColor("_EmissionColor", brownColor);
                }

            }
        }
        else
        {
            foreach (var material in materials)
            {
                //we can just disable the EMISSION
                //if we don't use emission color anywhere else
                material.DisableKeyword("_EMISSION");
            }
        }

    }
    private void OnCollisionStay(Collision collision)
    {
        foreach (var material in materials)
        {
            if (collision.collider.GetComponent<Stove>() != null && material.GetColor("_EmissionColor") == readyColor)
            {
                if(collision.collider.GetComponent<Stove>().GetStoveState() == true)
                {
                    Debug.Log("fum�e");
                    parent.transform.GetChild(1).gameObject.SetActive(true);
                    FirstPersonController.ChimieGame = true;
                }
            }

        }
                  
    }
}
