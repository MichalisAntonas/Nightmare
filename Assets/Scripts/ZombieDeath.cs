using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Analytics;

public class ZombieDeath : MonoBehaviour
{
    public int StatusCheck;
    public AudioClip ZombieGrowl;
    public AudioClip ZombieDeathSound;

    private int Health { get; set; }

    AudioSource audioSource;
    Animation anim;
    NavMeshAgent navAgent;

    void Start()
    {
        this.Health = Random.Range(3, 5);

        this.anim = this.GetComponentInChildren<Animation>();
        this.navAgent = this.GetComponent<NavMeshAgent>();
    }

    void DamageZombie(int DamageAmount)
    {
        Analytics.CustomEvent("zombie_receive_damage");
        Debug.Log("AnalyticsEvent: zombie_receive_damage");

        this.Health -= DamageAmount;
        if (this.Health <= 0 && this.StatusCheck == 0)
        {
            AudioSource.PlayClipAtPoint(this.ZombieDeathSound, this.gameObject.transform.position);
            this.navAgent.enabled = false;
            this.GetComponent<ZombieAI>().enabled = false;
            this.GetComponent<BoxCollider>().enabled = false;
            this.StatusCheck = 2;

            this.anim.wrapMode = WrapMode.Once;
            this.anim.Play("Z_FallingBack");

            Analytics.CustomEvent("zombie_death");
            Debug.Log("AnalyticsEvent: zombie_death");
        }
    }
}
