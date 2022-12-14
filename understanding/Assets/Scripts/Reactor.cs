using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reactor : MonoBehaviour
{
    public bool mainpower = true;
    public bool interfacesystem = true;
    public bool shieldGenerator = true;
    public bool canRepair = false;
    public bool criticalCondition = false;
    public GameObject[] pointLights;
    public Material lockDoor;
    public GameObject healthbar;
    private float lightcount;
    public Material doorMaterial;
    public GameObject audioSrc;
    MachineHealth machine_health;
    Material[] copyDoorMaterials;
    Color lightColor = Color.white;
    Light doorlight;
    bool colorset = false;
    
    
    
    AudioSource reactorAudio;
    Renderer rend;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        lightcount = pointLights.Length;
        machine_health = GetComponent<MachineHealth>();
        reactorAudio = audioSrc.GetComponent<AudioSource>();
        lightColor.r = 0.35f;
        lightColor.g = 0.55f;
        lightColor.b = 0.89f;
        lightColor.a = 1f;

    }

    // Update is called once per frame
    void Update()
    {
        
        healthCheck();
        mainpowerCheck();
        

        if(!mainpower && !interfacesystem && !shieldGenerator)
        {
            canRepair = true;
        }
        else
        {
            canRepair = false;
        }
        
    }

    public void mainpowerCheck()
    {
        if (!mainpower)
        {
            for (int i = 0; i < lightcount; i++)
            {
                
                if (pointLights[i].tag == "DoorLightMat")
                {

                    rend = pointLights[i].GetComponent<Renderer>();
                    rend.enabled = true;
                    copyDoorMaterials = rend.sharedMaterials;

                    copyDoorMaterials[1] = lockDoor;
                    rend.sharedMaterials = copyDoorMaterials;


                }
                else if (pointLights[i].tag == "DoorLights")
                {

                    if (colorset == false)
                    {
                        lightColor = doorlight.color;
                        colorset = true;
                    }
                    doorlight = pointLights[i].GetComponent<Light>();
                    doorlight.color = Color.red;
                }
                else
                {

                    pointLights[i].SetActive(false);
                }

            }


        }
        else
        {
            for (int i = 0; i < lightcount; i++)
            {
                if (pointLights[i].tag == "DoorLightMat")
                {

                    rend = pointLights[i].GetComponent<Renderer>();
                    rend.enabled = true;
                    copyDoorMaterials = rend.sharedMaterials;
                    copyDoorMaterials[1] = doorMaterial;
                    rend.sharedMaterials = copyDoorMaterials;

                }
                else if (pointLights[i].tag == "DoorLights")
                {
                    doorlight = pointLights[i].GetComponent<Light>();
                    doorlight.color = lightColor;
                }
                else
                {
                    
                    pointLights[i].SetActive(true);
                    
                }
            }
        }


    }

    public void healthCheck()
    {
        
        if (machine_health.health <= 10f)
        {
            criticalCondition = true;
            mainpower = false;
            for (int i = 0; i < lightcount; i++)
            {
                if (pointLights[i].tag == "DoorLights")
                {
                    if (reactorAudio.isPlaying == false)
                    {
                        reactorAudio.Play();
                    }
                    animator = pointLights[i].GetComponent<Animator>();
                    animator.SetBool("Emergency", true);
                }
            }
        }
        else
        {
            criticalCondition = false;
            reactorAudio.Stop();
            for (int i = 0; i < lightcount; i++)
            {
                if (pointLights[i].tag == "DoorLights")
                {
                    
                    animator = pointLights[i].GetComponent<Animator>();
                    animator.SetBool("Emergency", false);
                }
            }
        }
    }

  

}
