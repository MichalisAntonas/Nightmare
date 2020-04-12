using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieScript : MonoBehaviour
{
    public bool Active = false;
    public List<AudioClip> Growls;

    void Start()
    {
        this.gameObject.SetActive(this.Active);
    }

    public void Activate()
    {
        this.gameObject.SetActive(true);
        AudioSource.PlayClipAtPoint(this.Growls[Random.Range(0, this.Growls.Count)], this.gameObject.transform.position);
    }
}
