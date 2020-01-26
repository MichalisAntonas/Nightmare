using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickUp : MonoBehaviour
{
    public GameObject theAmmo;
    public GameObject ammoDisplayBox;
    public AudioSource ammoPickUp;
    void OnTriggerEnter(Collider other)
    {
        ammoPickUp.Play();
        theAmmo.SetActive(true);
        GlobalAmmo.ammoCount += 10;
        theAmmo.SetActive(false);
    }
}
