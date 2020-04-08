using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieAI : MonoBehaviour
{
    public float enemySpeed = .01f;
    public AudioClip[] hurtSounds;

    AudioSource audioSource;
    Animation anim;
    NavMeshAgent navAgent;
    GameObject uiFlash;

    private GameObject thePlayer;
    private bool isAttacking = false;
    private bool attackTrigger = false;

    void Start()
    {
        thePlayer = GameObject.FindGameObjectWithTag("Player");

        audioSource = this.GetComponent<AudioSource>();

        anim = this.GetComponentInChildren<Animation>();
        anim.wrapMode = WrapMode.Loop;

        navAgent = this.GetComponent<NavMeshAgent>();
        navAgent.speed = 1f;

        uiFlash = GameObject.FindGameObjectWithTag("HurtFlash");
    }

   //Zombie looks towards Player and follows him
    void Update()
    {
        Vector3 point;
        if (RandomPoint(thePlayer.transform.position, 10f, out point))
            navAgent.destination = thePlayer.transform.position;

        if (attackTrigger && !isAttacking)
        {
            anim.Play("Z_Attack");
            StartCoroutine(InflictDamage());
        }
    }

    //Zombie attacks if its in Players Collider
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.transform.parent.gameObject.tag == "MainCamera")
        {
            attackTrigger = true;
            enemySpeed = 0;
        }
    }
    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.transform.parent.gameObject.tag == "MainCamera")
        {
            enemySpeed = 0.02f;
            anim.Play("Z_Walk_InPlace");
            attackTrigger = false;
        }
    }

    IEnumerator InflictDamage()
    {
        isAttacking = true;
        this.audioSource.clip = hurtSounds[Random.Range(0, 3)];
        this.audioSource.Play();

        uiFlash.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        uiFlash.SetActive(false);
        yield return new WaitForSeconds(1f);
        GlobalHealth.currentHealth -= 5;

        yield return new WaitForSeconds(0.09f);
        isAttacking = false;
    }

    bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {
        for (int i = 0; i < 30; i++)
        {
            Vector3 randomPoint = center + Random.insideUnitSphere * range;
            NavMeshHit hit;
            if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
            {
                result = hit.position;
                return true;
            }
        }
        result = Vector3.zero;
        return false;
    }
}
