using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MachineHealth : MonoBehaviour
{
    public float health = 0;
    public float temp_health = 0f;
    public GameObject healthbar;
    
    Image healthbarUI;
    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.name == "Reactor" || gameObject.name == "Oxygen Generator")
        {
            healthbarUI = healthbar.GetComponent<Image>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.name == "Reactor" || gameObject.name == "Oxygen Generator")
        {
            healthbarUI.fillAmount = health / 100f;
        }
    }
}
