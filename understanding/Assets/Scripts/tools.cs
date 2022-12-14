using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tools : MonoBehaviour
{
    // Start is called before the first frame update
    BoxCollider trigger;
    public bool canRepair;
    public float repairRegen = 0.5f;
    public GameObject GOsparks;
    public GameObject spark_light;
    public GameObject GOreactor;
    public AudioSource weldingSound;
    Reactor reactor;
    MachineHealth machine_health;
    ParticleSystem sparks;
    

    void Start()
    {
        trigger = GetComponent<BoxCollider>();
        sparks = GOsparks.GetComponent<ParticleSystem>();
        reactor = GOreactor.GetComponent<Reactor>();
        weldingSound = GetComponent<AudioSource>();
        canRepair = false;
        sparks.Stop();
        
        weldingSound.Stop();
        spark_light.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if(other.gameObject.tag == "Machine")
        {
            machine_health = other.gameObject.GetComponent<MachineHealth>();
            
            if(other.gameObject.name == "Reactor")
            {
                reactor = other.gameObject.GetComponent<Reactor>();
                if (reactor.canRepair)
                {
                    canRepair = true;
                }
            }
            else
            {
                if (machine_health.health < 100f)
                {
                    canRepair = true;
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Machine")
        {
            canRepair = false;
        }
    }

    // Update is called once per frame
    void Update()
    {




        if (canRepair && Input.GetKey(KeyCode.P)) 
        {

            if (machine_health.health >= 100f)
            {
                sparks.Stop();
                weldingSound.Stop();
                canRepair = false;
            } else if (machine_health.health < 100f)
            {
                spark_light.SetActive(true);
                if (Input.GetKeyDown(KeyCode.P))
                {
                    weldingSound.Play();
                }
                sparks.Play();
                
                machine_health.health += repairRegen * Time.deltaTime;
            }
            else
            {
                spark_light.SetActive(false);
                weldingSound.Stop();
                sparks.Stop();
            }


        }
        else
        {
            spark_light.SetActive(false);
            weldingSound.Stop();
            sparks.Stop();
        }
    }


}
