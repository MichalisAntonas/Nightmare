using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FZJumpTrigger : MonoBehaviour
{
    public AudioSource ZombieGrowl;
    public GameObject TheZombie;
    public GameObject TheZombie1;
    public GameObject TheZombie2;

    void OnTriggerEnter()
    {
        GetComponent<BoxCollider>().enabled = false;
        ZombieGrowl.Play();
        TheZombie.SetActive(true);
        TheZombie1.SetActive(true);
        TheZombie2.SetActive(true);
    }
}
