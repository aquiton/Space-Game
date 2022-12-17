using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BigBlit.ActivePack;
public class CoolantPump : MonoBehaviour
{
    public Lever pumpLever;
    public bool oneInchamber;
    public bool pumpGeneratorOn;
    public void ResetSwitch()
    {
        StartCoroutine(resetSwitchWait());
        
    }

    public IEnumerator resetSwitchWait()
    {
        yield return new WaitForSeconds(0.5f);
        pumpLever.ToggleOff();
        
    }
}
