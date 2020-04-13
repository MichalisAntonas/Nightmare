using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieDeath : MonoBehaviour
{
    private int EnemyHealth;
    public int StatusCheck;
    public AudioClip ZombieGrowl;
    public AudioClip ZombieDeathSound;
    AudioSource audioSource;
    Animation anim;
    NavMeshAgent navAgent;

    void Start()
    {
        EnemyHealth = Random.Range(3, 5);

        anim = this.GetComponentInChildren<Animation>();
        navAgent = this.GetComponent<NavMeshAgent>();
    }

    void DamageZombie(int DamageAmount)
    {
        EnemyHealth -= DamageAmount;
        if (EnemyHealth <= 0 && StatusCheck == 0)
        {
            AudioSource.PlayClipAtPoint(this.ZombieDeathSound, this.gameObject.transform.position);
            navAgent.enabled = false;
            this.GetComponent<ZombieAI>().enabled = false;
            this.GetComponent<BoxCollider>().enabled = false;
            StatusCheck = 2;
            
            anim.wrapMode = WrapMode.Once;
            anim.Play("Z_FallingBack");
       
          
        }
    }
}
