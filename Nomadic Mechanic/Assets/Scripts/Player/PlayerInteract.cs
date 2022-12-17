using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BigBlit.ActivePack;

public class PlayerInteract : MonoBehaviour
{
    public Transform cam;
    public float playerActivatedistance;
    bool active = false;
    Renderer rend;
    KeyboardPressController controller;
    bool lookingAtSwitch = false;

    private void Update()
    {
        RaycastHit hit;
        active = Physics.Raycast(cam.position, cam.TransformDirection(Vector3.forward), out hit, playerActivatedistance);
        Debug.DrawRay(cam.position, cam.TransformDirection(Vector3.forward) * playerActivatedistance, Color.red);
        if (active)
        {
            
            rend = hit.collider.GetComponent<Renderer>();
            if(hit.collider.tag == "Switch")
            {
                
                controller = hit.collider.GetComponent<KeyboardPressController>();
                controller.enabled = true;
                lookingAtSwitch = true;
            }
            else
            {
                if (lookingAtSwitch)
                {
                    controller.enabled = false;
                    lookingAtSwitch = false;
                }
            }
            
        }
        else
        {
            if (lookingAtSwitch)
            {
                controller.enabled = false;
                lookingAtSwitch = false;
            }
        }

        
    }
}
