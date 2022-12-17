using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BigBlit.ActivePack;

public class PrimeSwitches : MonoBehaviour
{
    public bool prime1 = false;
    public bool prime2 = false;
    public bool prime3 = false;
    public bool allPrimed = false;
    public Lever[] switches;


    private void Update()
    {
        if(prime1 && prime2 && prime3)
        {
            allPrimed = true;
        }
        else
        {
            allPrimed = false;
        }
    }

    public void prime1Flick(bool set)
    {
        prime1 = set;
    }

    public void prime2Flick(bool set)
    {
        prime2 = set;
    }

    public void prime3Flick(bool set)
    {
        prime3 = set;
    }


}
