using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Analytics;
using UnityEngine.UI;

public class ZombieAI : MonoBehaviour
{
    public float enemySpeed = 1.5f;
    public AudioClip[] hurtSounds;

    AudioSource audioSource;
    Animation anim;
    NavMeshAgent navAgent;
    GameObject uiFlash;

    private GameObject player;
    private bool isAttacking = false;
    private bool attackTrigger = false;

    void Start()
    {
        this.player = GameObject.FindGameObjectWithTag("Player");

        this.audioSource = player.GetComponent<AudioSource>();

        this.anim = this.GetComponentInChildren<Animation>();
        this.anim.wrapMode = WrapMode.Loop;

        this.navAgent = this.GetComponent<NavMeshAgent>();
        this.navAgent.speed = 1.5f;
    }

    void Update()
    {
        Vector3 point;
        if (RandomPoint(player.transform.position, 10f, out point))
            navAgent.destination = player.transform.position;

        if (attackTrigger && !isAttacking)
        {
            anim.Play("Z_Attack");
            StartCoroutine(InflictDamage());
        }
    }

    // Zombie attacks if its in Players Collider
    void OnTriggerEnter(Collider collider)
    {
        if (collider == null)
            return;

        if (collider.gameObject.tag == "Player")
        {
            attackTrigger = true;
            enemySpeed = 0;
        }
    }
    void OnTriggerExit(Collider collider)
    {
        if (collider == null)
            return;

        if (collider.gameObject.tag == "Player")
        {
            enemySpeed = 1.5f;
            anim.Play("Z_Walk_InPlace");
            attackTrigger = false;
        }
    }

    IEnumerator InflictDamage()
    {
        Analytics.CustomEvent("player_receive_damage", new Dictionary<string, object>
        {
            { "time", (int)(System.DateTime.UtcNow - Finish.startTime).TotalSeconds }
        });
        Debug.Log("AnalyticsEvent: player_receive_damage");

        isAttacking = true;
        this.player.GetComponent<HealthController>().Health -= Random.Range(10, 20) * Random.value;

        this.audioSource.clip = hurtSounds[Random.Range(0, 3)];
        this.audioSource.Play();

        GameObject flash = GameObject.FindGameObjectWithTag("HurtFlash");
        RawImage hurtImg = flash.GetComponent<RawImage>();

        hurtImg.color = new Color(1f, 0f, 0f, .25f);
        yield return new WaitForSeconds(.1f);
        hurtImg.color = new Color(1f, 0f, 0f, 0f);

        yield return new WaitForSeconds(1f);
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
