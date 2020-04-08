﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class FirePistol : MonoBehaviour
{
    public AudioClip GunFire;
    public int DamageAmount = 1;

    AudioSource audioSource;

    private bool IsFiring = false;

    void Start()
    {
        this.audioSource = this.GetComponent<AudioSource>();
        this.audioSource.clip = this.GunFire;
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && GlobalAmmo.ammoCount >= 1 && !this.IsFiring)
        {
            GlobalAmmo.ammoCount -= 1;
            StartCoroutine(FiringPistol());
        }
    }

    IEnumerator FiringPistol()
    {
        IsFiring = true;
        this.GetComponent<Animation>().Play("PistolShot");
        this.audioSource.Play();

        RaycastHit Shot;
        if (Physics.Raycast(transform.position,transform.TransformDirection(Vector3.forward), out Shot))
            Shot.transform.SendMessage("DamageZombie", DamageAmount, SendMessageOptions.DontRequireReceiver);

        yield return new WaitForSeconds(0.5f);
        IsFiring = false;
    }
}
