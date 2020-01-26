using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAI : MonoBehaviour
{

    public GameObject thePlayer;
    public GameObject theEnemy;
    public float enemySpeed = 0.01f;
    public bool attackTrigger = false;
    public bool isAttacking = false;
    public AudioSource hurtSound1;
    public AudioSource hurtSound2;
    public AudioSource hurtSound3;
    public int hurtGen;
    public GameObject theFlash;
 

   //Zombie looks towards Player and follows him
    void Update()
    {
        transform.LookAt(thePlayer.transform);
        if(attackTrigger==false)
        {
            enemySpeed = 0.02f;
            theEnemy.GetComponent<Animation>().Play("Z_Walk_InPlace");
            transform.position = Vector3.MoveTowards(transform.position, thePlayer.transform.position, enemySpeed);
        }
        if (attackTrigger == true && isAttacking == false)
        {
            enemySpeed = 0;
            theEnemy.GetComponent<Animation>().Play("Z_Attack");
            StartCoroutine(InflictDamage());
        }
       

    }
    //Zombie attacks if its in Players Collider
    void OnTriggerEnter(Collider other)
    {

        attackTrigger = true;

    }

    void OnTriggerExit(Collider other)
    {

        attackTrigger = false;
    }
    IEnumerator InflictDamage()
    {
        isAttacking = true;
        hurtGen = Random.Range(1, 4);
        if (hurtGen == 1)
        {
            hurtSound1.Play();
        }
        if (hurtGen == 2)
        {
            hurtSound2.Play();
        }
        if (hurtGen == 3)
        {
            hurtSound3.Play();
        }
        
        
        theFlash.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        theFlash.SetActive(false);
        yield return new WaitForSeconds(1f);
        GlobalHealth.currentHealth -= 5;
        

        yield return new WaitForSeconds(0.09f);
        isAttacking = false;
    }
}
