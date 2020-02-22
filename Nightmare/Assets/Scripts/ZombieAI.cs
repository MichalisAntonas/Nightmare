using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAI : MonoBehaviour
{
    public GameObject thePlayer;
    public float enemySpeed = .02f;
    bool attackTrigger = false;
    public bool isAttacking = false;
    public AudioSource[] hurtSounds;
    public GameObject theFlash;

    void Start()
    {
        this.GetComponentInChildren<Animation>().wrapMode = WrapMode.Loop;
    }

   //Zombie looks towards Player and follows him
    void Update()
    {
        transform.LookAt(thePlayer.transform);
        transform.position = Vector3.MoveTowards(transform.position, thePlayer.transform.position, enemySpeed);
        
        if (attackTrigger && !isAttacking)
        {
            this.GetComponentInChildren<Animation>().Play("Z_Attack");
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
            this.GetComponentInChildren<Animation>().Play("Z_Walk_InPlace");
            attackTrigger = false;
        }
    }

    IEnumerator InflictDamage()
    {
        isAttacking = true;
        hurtSounds[Random.Range(0, 3)].Play();
        
        theFlash.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        theFlash.SetActive(false);
        yield return new WaitForSeconds(1f);
        GlobalHealth.currentHealth -= 5;

        yield return new WaitForSeconds(0.09f);
        isAttacking = false;
    }
}
