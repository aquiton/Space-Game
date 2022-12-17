using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class Cannon : MonoBehaviour
{
    public GameObject[] muzzle;
    public GameObject shotPrefab;
    ShotBehavior laserBehavior;
    public bool fire = false;
    public bool burstFire = false;
    public AudioSource laserSound;
    public AudioClip[] sfx;
    Random randomshot = new Random();

    // Start is called before the first frame update
    void Start()
    {
        laserBehavior = shotPrefab.GetComponent<ShotBehavior>();
        laserBehavior.speed = 200;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void fireCannon()
    {
        StartCoroutine(shoot());
    }

    IEnumerator shoot()
    {
        int randomMuzzle = randomshot.Next(0,muzzle.Length);
        laserSound.PlayOneShot(sfx[0]);
        yield return new WaitForSeconds(0.3f);
        
        GameObject laser = GameObject.Instantiate(shotPrefab, muzzle[randomMuzzle].transform.position, muzzle[randomMuzzle].transform.rotation);
        
        
        GameObject.Destroy(laser, 1);
    }
}
