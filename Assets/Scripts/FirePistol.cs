﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class FirePistol : MonoBehaviour
{
    public int DamageAmount = 1;

    [Header("Asset References")]
    public AudioClip GunFire;
    //public GameObject MuzzleShot;
    public GameObject MuzzleParticles;
    public GameObject ParticleSpawnTransform;

    [Header("Audio Settings")]
    public float PitchThresholdLow = .8f;
    public float PitchThresholdHigh = 1.2f;

    AudioSource audioSource;
    AmmoController ammoControl;

    private bool IsFiring = false;

    void Start()
    {
        this.audioSource = this.GetComponent<AudioSource>();
        this.audioSource.clip = this.GunFire;

        this.ammoControl = this.GetComponentInParent<AmmoController>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && this.ammoControl.AmmoCount > 0 && !this.IsFiring)
        {
            this.ammoControl.AmmoCount--;
            StartCoroutine(FiringPistol());
        }
    }

    IEnumerator FiringPistol()
    {
        IsFiring = true;
        this.GetComponent<Animation>().Play("PistolShot");

        this.audioSource.pitch = Random.Range(this.PitchThresholdLow, this.PitchThresholdHigh);
        this.audioSource.Play();

        //this.MuzzleShot.SetActive(true);
        //this.MuzzleShot.GetComponent<Animation>().Play("MuzzleAnim");

        Transform particleTransform;
        if (this.ParticleSpawnTransform != null)
            particleTransform = this.ParticleSpawnTransform.transform;
        else
            particleTransform = this.gameObject.transform;

        Object.Instantiate(this.MuzzleParticles, particleTransform);

        Analytics.CustomEvent("gun_fire");
        Debug.Log("AnalyticsEvent: gun_fire");

        RaycastHit Shot;
        if (Physics.Raycast(transform.position,transform.TransformDirection(Vector3.forward), out Shot))
            Shot.transform.SendMessage("DamageZombie", this.DamageAmount, SendMessageOptions.DontRequireReceiver);

        yield return new WaitForSeconds(0.5f);
        IsFiring = false;
    }
}
