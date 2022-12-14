using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator animator;
    public SphereCollider trigger;

    void Start()
    {
        animator = GetComponent<Animator>();
        trigger = GetComponent<SphereCollider>();
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.name == "Player")
        {
            animator.SetBool("character_nearby", true);
        }
        else
        {
            animator.SetBool("character_nearby", false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        animator.SetBool("character_nearby", false);
    }
}
