using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    public int ammo = 6;
    public bool readyTofire;
    public Material[] cannonMaterial;
    public GameObject cannonLights;
    public GameObject cannonLightEmission;
    public GameObject GOCannon;
    AudioSource generatorSoundsrc;
    public AudioClip[] sfx;
    Material[] copyMaterials;
    Renderer rend;
    Light cannonLTem;
    MachineHealth machine_health;
    SphereCollider cannonTrigger;
    Cannon cannon;
    bool canFire = false;
    

    void Start()
    {
        rend = cannonLights.GetComponent<Renderer>();
        rend.enabled = true;
        cannonLTem = cannonLightEmission.GetComponent<Light>();
        machine_health = GetComponent<MachineHealth>();
        cannonTrigger = GetComponent<SphereCollider>();
        cannon = GOCannon.GetComponent<Cannon>();
        generatorSoundsrc = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            canFire = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            canFire = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (ammo == 0 || ammo == 0 && machine_health.health <= 0f)
        {
            readyTofire = false;
        }
        else if (ammo > 0f && machine_health.health >= 1f)
        {
            readyTofire = true;
        }

        if (readyTofire)
            {
                copyMaterials = rend.sharedMaterials;
                copyMaterials[1] = cannonMaterial[0];
                rend.sharedMaterials = copyMaterials;
                cannonLTem.color = Color.green;
            if (Input.GetKeyDown(KeyCode.P) && canFire)
            {
                ammo -= 1;
                cannon.fireCannon();
                StartCoroutine(delayAmmosound());
            }
            }
            else
            {
                copyMaterials = rend.sharedMaterials;
                copyMaterials[1] = cannonMaterial[1];
                rend.sharedMaterials = copyMaterials;
                cannonLTem.color = Color.red;
                
            }
        
        
    }

    IEnumerator delayAmmosound()
    {
        yield return new WaitForSeconds(0.2f);
        generatorSoundsrc.PlayOneShot(sfx[0]);
    }

}
