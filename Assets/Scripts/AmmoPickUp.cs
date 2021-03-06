﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class AmmoPickUp : MonoBehaviour
{
    public int Amount = 8;
    public AudioClip ReloadClip;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.ToLower() != "player")
            return;

        other.gameObject.GetComponent<AmmoController>().AmmoCount += this.Amount;
        other.gameObject.GetComponent<AudioSource>().PlayOneShot(this.ReloadClip);

        this.gameObject.SetActive(false);
        Destroy(this.gameObject, 5);

        Analytics.CustomEvent("ammo_pickup");
        Debug.Log("AnalyticsEvent: ammo_pickup");
    }
}
