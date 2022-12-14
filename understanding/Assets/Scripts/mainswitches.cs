using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainswitches : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject obReactor;
    Reactor reactor;
    public SphereCollider trigger;
    public bool isMainpower;
    public bool isInterfaceSystem;
    public bool isShieldGenerator;
    public bool entered = false;
    public GameObject mainSwitchAudio;
    AudioSource audioSrc;
    public AudioClip sfx, sfx2, sfx3;

    void Start()
    {
        reactor = obReactor.GetComponent<Reactor>();
        trigger = GetComponent<SphereCollider>();
        audioSrc = mainSwitchAudio.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            entered = true;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            entered = false;
        }
        
    }

    private void Update()
    {
        if (entered)
        {

            if (isMainpower)
            {
                if (Input.GetKeyUp(KeyCode.P))
                {
                    reactor.mainpower = !reactor.mainpower;
                    if (reactor.criticalCondition)
                    {
                        
                        audioSrc.PlayOneShot(sfx3);
                    }
                    else if (!reactor.mainpower)
                    {
                        //audioSrc.clip = sfx;
                        audioSrc.PlayOneShot(sfx);
                    }
                    else
                    {
                        //audioSrc.clip = sfx2;
                        audioSrc.PlayOneShot(sfx2);
                    }
                    
                }
            }
            if (isInterfaceSystem)
            {
                if (Input.GetKeyUp(KeyCode.P))
                {
                    reactor.interfacesystem = !reactor.interfacesystem;
                    if (!reactor.interfacesystem)
                    {
                        audioSrc.clip = sfx;
                        audioSrc.PlayOneShot(sfx);
                    }
                    else
                    {
                        audioSrc.clip = sfx2;
                        audioSrc.PlayOneShot(sfx2);
                    }
                }
            }
            if (isShieldGenerator)
            {
                if (Input.GetKeyUp(KeyCode.P))
                {
                    reactor.shieldGenerator = !reactor.shieldGenerator;
                    if (!reactor.shieldGenerator)
                    {
                        audioSrc.clip = sfx;
                        audioSrc.PlayOneShot(sfx);
                    }
                    else
                    {
                        audioSrc.clip = sfx2;
                        audioSrc.PlayOneShot(sfx2);
                    }
                }
            }
            
        }
    }
}
