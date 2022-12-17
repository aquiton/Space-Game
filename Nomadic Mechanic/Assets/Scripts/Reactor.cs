using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reactor : MonoBehaviour
{
    public bool reactorOn = false;
    public bool shipOs = false;
    public bool canRepair = true;
    public bool reactorPrimed = false;
    public AudioSource reactorSrcAudio;

    private void Start()
    {
        
    }

    private void Update()
    {
        checkCanRepair();
        if(reactorPrimed && shipOs)
        {
            reactorOn = true;
        }
    }

    private void checkCanRepair()
    {
        if (!reactorOn)
        {
            canRepair = true;
        }
        else
        {
            canRepair = false;
        }
    }

    



}
