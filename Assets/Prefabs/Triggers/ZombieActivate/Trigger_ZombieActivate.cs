using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class TriggerScript : MonoBehaviour
{
    public int TriggerID = -1;
    public GameObject[] ZombiesToActivate;

    void Start()
    {
        // automatically assign an ID based on the amount of triggers in the level
        if (this.TriggerID == -1)
            this.TriggerID = FindObjectsOfType<TriggerScript>().Length - 1;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.ToLower() != "player")
            return;

        AnalyticsEvent.TutorialStep(this.TriggerID);

        foreach (GameObject zombie in this.ZombiesToActivate)
            zombie.GetComponent<ZombieScript>().Activate();

        Destroy(this.gameObject);
    }
}
