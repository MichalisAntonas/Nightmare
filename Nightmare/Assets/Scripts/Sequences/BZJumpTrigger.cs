using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BZJumpTrigger : MonoBehaviour
{
    public AudioSource ZombieGrowl;
    public GameObject TheZombie;
    

    void OnTriggerEnter ()
    {
        GetComponent<BoxCollider>().enabled = false;
        ZombieGrowl.Play();
        TheZombie.SetActive(true);
    }
}
