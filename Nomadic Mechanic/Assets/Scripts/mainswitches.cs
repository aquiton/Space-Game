using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BigBlit.ActivePack;

public class mainswitches : MonoBehaviour
{
    public bool mainPower = false;
    public bool interfaceSystem = false;
    public bool shieldGenerator = false;
    public Reactor reactor;
    public Lever interfaceSystemlever;
    public Lever shieldGeneratorlever;
    private bool setupShipsystem = false;
    private bool reactorPrimed = false;
    public AudioSource switchAudiosrc;
    public AudioClip sfx;


    public void Start()
    {
        
    }

    private void Update()
    {
        checkPowerswitch();

    }

    private void ShipSystem()
    {
        if (mainPower)
        {
            setupInterfaceSystem();
            if (interfaceSystem && reactor.reactorPrimed)
            {
                setupShieldGenerator();
            }
        }
    }

    public void PlayPowerAudio(bool set)
    {
        if (set)
        {
            switchAudiosrc.Play();
        }
        else
        {
            switchAudiosrc.Stop();
        }
    }

    private void checkPowerswitch()
    {
        if (!mainPower)
        {
            reactor.reactorOn = false;
            reactor.shipOs = false;
            reactor.reactorPrimed = false;
            setupShipsystem = true;

        }
        
        
        
        
        if (setupShipsystem)
        {
            ShipSystem();
        }
        if (shieldGenerator)
        {
            setupShipsystem = false;
        }
        
    }

    private void setupInterfaceSystem()
    {
        if (reactor.shipOs)
        {
            interfaceSystemlever.disableLever(false);
        }
    }

    private void setupShieldGenerator()
    {
        shieldGeneratorlever.disableLever(false);
    }

    public void setMainpower(bool set)
    {
        mainPower = set;
    }

    public void setInterfacesystem(bool set)
    {
        interfaceSystem = set;
    }
    public void setShieldGenerator(bool set)
    {
        shieldGenerator = set;
    }
}
