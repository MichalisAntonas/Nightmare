using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAIRun : MonoBehaviour
{

    public GameObject thePlayer1;
    public GameObject theEnemy1;
    public float enemySpeed1 = 0.01f;
    public bool attackTrigger1 = false;
    public bool isAttacking1 = false;
    public AudioSource hurtSound11;
    public AudioSource hurtSound21;
    public AudioSource hurtSound31;
    public int hurtGen1;
    public GameObject theFlash1;
 

   //Zombie looks towards Player and follows him
    void Update()
    {
        transform.LookAt(thePlayer1.transform);
        if(attackTrigger1==false)
        {
            enemySpeed1 = 0.04f;
            theEnemy1.GetComponent<Animation>().Play("Z_Run_InPlace");
            transform.position = Vector3.MoveTowards(transform.position, thePlayer1.transform.position, enemySpeed1);
        }
        if (attackTrigger1 == true && isAttacking1 == false)
        {
            enemySpeed1 = 0;
            theEnemy1.GetComponent<Animation>().Play("Z_Attack");
            StartCoroutine(InflictDamage1());
        }
       

    }
    //Zombie attacks if its in Players Collider
    void OnTriggerEnter(Collider other)
    {

        attackTrigger1 = true;

    }

    void OnTriggerExit(Collider other)
    {

        attackTrigger1 = false;
    }
    IEnumerator InflictDamage1()
    {
        isAttacking1 = true;
        hurtGen1 = Random.Range(1, 4);
        if (hurtGen1 == 1)
        {
            hurtSound11.Play();
        }
        if (hurtGen1 == 2)
        {
            hurtSound21.Play();
        }
        if (hurtGen1 == 3)
        {
            hurtSound31.Play();
        }
        
        
        theFlash1.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        theFlash1.SetActive(false);
        yield return new WaitForSeconds(1f);
        GlobalHealth.currentHealth -= 5;
        

        yield return new WaitForSeconds(0.09f);
        isAttacking1 = false;
    }
}
