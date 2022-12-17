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
    public GameObject ammoslots;
    public GameObject firebutton;
    AudioSource generatorSoundsrc;
    public AudioClip[] sfx;
    Material[] copyMaterials;
    Renderer rend, rend2;
    Light cannonLTem;
    MachineHealth machine_health;
    SphereCollider cannonTrigger;
    BoxCollider ammoSlot;
    Cannon cannon;
    bool canFire = false;
    bool canReload = false;
    GameObject ammoclip;
    

    void Start()
    {
        rend = cannonLights.GetComponent<Renderer>();
        rend.enabled = true;
        cannonLTem = cannonLightEmission.GetComponent<Light>();
        machine_health = GetComponent<MachineHealth>();
        cannonTrigger = GetComponent<SphereCollider>();
        cannon = GOCannon.GetComponent<Cannon>();
        generatorSoundsrc = GetComponent<AudioSource>();
        ammoSlot = ammoslots.GetComponent<BoxCollider>();
        cannonTrigger = firebutton.GetComponent<SphereCollider>();
        //ammoSlot = ammoslots.GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        if (other.gameObject.tag == "Player")
        {
            canFire = true;
        }
        if(other.gameObject.tag == "Ammo")
        {
            rend2 = other.GetComponent<Renderer>();
            if (ammo == 0)
            {
                canReload = true;
                ammoclip = other.gameObject;
            }       
        }
        Debug.Log(canFire);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            canFire = false;
        }
        if (other.gameObject.tag == "Ammo")
        {
            canReload = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        checkReadytoFire();
        checkReload();
        
    }

    public void checkReadytoFire()
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

    public void checkReload()
    {
        if(canReload && Input.GetKey(KeyCode.P))
        {
            GameObject.Destroy(ammoclip);
            ammo = 6;
            canReload = false;
        }
    }
    

    IEnumerator delayAmmosound()
    {
        yield return new WaitForSeconds(0.2f);
        generatorSoundsrc.PlayOneShot(sfx[0]);
    }

}
