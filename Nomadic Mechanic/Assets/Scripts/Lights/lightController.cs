using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject light_src;
    Light lightsrc;
    Renderer rend;
    Material[] copyMaterials;
    void Start()
    {
        rend = GetComponent<Renderer>();
        lightsrc = light_src.GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeLightMaterial(Material newmat)
    {
        copyMaterials = rend.sharedMaterials;
        copyMaterials[1] = newmat;
        rend.sharedMaterials = copyMaterials;
    }

    public void changeLightColor(int color)
    {
        if(color == 1)
        {
            lightsrc.color = Color.green;
        }
        else
        {
            lightsrc.color = Color.red;
        }
        
    }
}
