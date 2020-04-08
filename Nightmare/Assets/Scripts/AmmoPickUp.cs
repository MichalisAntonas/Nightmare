using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickUp : MonoBehaviour
{
    public AudioClip ReloadClip;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.ToLower() != "player")
            return;

        GlobalAmmo.ammoCount += 10;
        other.gameObject.GetComponent<AudioSource>().PlayOneShot(this.ReloadClip);

        this.gameObject.SetActive(false);
        Destroy(this.gameObject, 5);
    }
}
