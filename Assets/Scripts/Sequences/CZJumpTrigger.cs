using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CZJumpTrigger : MonoBehaviour
{
    public AudioSource ZombieGrowl;
    public GameObject TheZombie;


    void OnTriggerEnter()
    {
        GetComponent<BoxCollider>().enabled = false;
        ZombieGrowl.Play();
        TheZombie.SetActive(true);
    }
}
