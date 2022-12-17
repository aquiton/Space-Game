using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ComputerUI : MonoBehaviour
{
    public Reactor reactor;
    public Image loadbar;
    public double loadtime = 0;
    public bool loadOs = false;
    private bool booted = false;
    private bool primed = false;
    public bool prime_Reactor = false;
    public mainswitches switches;
    public PrimeSwitches pswitches;
    public AudioSource src1, src2;
    public AudioClip sfx1, sfx2, sfx3;

    public void Update()
    {
        if (loadOs)
        {
           
            loadtime += 0.25 * Time.deltaTime;
            loadbar.fillAmount = (float)loadtime;
            if(loadtime >= 1)
            {
                if (switches.mainPower) {
                    reactor.shipOs = true;
                    loadOs = false;
                    loadtime = 0;
                    src1.Stop();
                    src1.PlayOneShot(sfx2);
                }
                else
                {
                    src1.Stop();
                    src1.PlayOneShot(sfx3);
                    loadbar.color = Color.red;
                    loadOs = false;
                    loadtime = 0;
                    
                }
                
            }
            booted = false;
        }

        if (prime_Reactor)
        {
            loadtime += 0.25 * Time.deltaTime;
            loadbar.fillAmount = (float)loadtime;
            if (loadtime >= 1)
            {
                if (switches.mainPower && switches.interfaceSystem && pswitches.allPrimed)
                {
                    src1.Stop();
                    src1.PlayOneShot(sfx2);
                    reactor.reactorPrimed = true;
                    prime_Reactor = false;
                    loadtime = 0;
                    pswitches.switches[0].ToggleOff();
                    pswitches.switches[1].ToggleOff();
                    pswitches.switches[2].ToggleOff();
                    


                }
                else
                {
                    src1.Stop();
                    src1.PlayOneShot(sfx3);
                    loadbar.color = Color.red;
                    prime_Reactor = false;
                    loadtime = 0;
                    
                }

            }
            primed = false;
        }

        if (!switches.mainPower)
        {
            loadbar.color = Color.red;
        }
        
        

    }
    public void bootShipOS()
    {
        booted = true;
        if (switches.mainPower && booted)
        {
            
            loadOs = true;
            loadbar.color = Color.green;
            src1.transform.position = transform.position;
            src1.PlayOneShot(sfx1);
        }
        
        //make error noise for else
    }

    public void primeReactor()
    {
        primed = true;
        if(switches.interfaceSystem && switches.mainPower && primed && pswitches.allPrimed)
        {
            prime_Reactor = true;
            loadbar.color = Color.green;
            src1.transform.position = transform.position;
            src1.PlayOneShot(sfx1);
        }
    }


}
