using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieDeath : MonoBehaviour
{
    public int EnemyHealth = 15;
    public GameObject TheEnemy;
    public int StatusCheck;
    public AudioSource ZombieDeathSound;

    void DamageZombie(int DamageAmount)
    {
        EnemyHealth -= DamageAmount;
    }


    // Update is called once per frame
    void Update()
    {
        if(EnemyHealth <=0 && StatusCheck == 0)
        {
            this.GetComponent<ZombieAI>().enabled = false;
            this.GetComponent<BoxCollider>().enabled = false;
            StatusCheck = 2;
            TheEnemy.GetComponent<Animation>().Stop("Z_Walk_InPlace");
            TheEnemy.GetComponent<Animation>().Play("Z_FallingBack");
            ZombieDeathSound.Play();
        }
    }
}
