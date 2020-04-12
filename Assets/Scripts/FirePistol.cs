using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class FirePistol : MonoBehaviour
{
    public GameObject MuzzleShot;
    public AudioClip GunFire;
    public int DamageAmount = 1;

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
        this.audioSource.Play();

        this.MuzzleShot.SetActive(true);
        this.MuzzleShot.GetComponent<Animation>().Play("MuzzleAnim");

        RaycastHit Shot;
        if (Physics.Raycast(transform.position,transform.TransformDirection(Vector3.forward), out Shot))
            Shot.transform.SendMessage("DamageZombie", DamageAmount, SendMessageOptions.DontRequireReceiver);

        yield return new WaitForSeconds(0.5f);
        IsFiring = false;
    }
}
