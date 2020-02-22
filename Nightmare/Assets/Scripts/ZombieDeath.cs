using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieDeath : MonoBehaviour
{
    private int EnemyHealth;
    public int StatusCheck;
    public AudioSource ZombieDeathSound;

    Animation anim;
    NavMeshAgent navAgent;

    void Start()
    {
        EnemyHealth = Random.Range(3, 6);

        anim = this.GetComponentInChildren<Animation>();
        navAgent = this.GetComponent<NavMeshAgent>();
    }

    void DamageZombie(int DamageAmount)
    {
        EnemyHealth -= DamageAmount;
        if (EnemyHealth <= 0 && StatusCheck == 0)
        {
            navAgent.enabled = false;
            this.GetComponent<ZombieAI>().enabled = false;
            this.GetComponent<BoxCollider>().enabled = false;
            StatusCheck = 2;

            anim.wrapMode = WrapMode.Once;
            anim.Play("Z_FallingBack");
            ZombieDeathSound.Play();
        }
    }
}
