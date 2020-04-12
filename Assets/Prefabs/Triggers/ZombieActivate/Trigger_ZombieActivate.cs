using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class Trigger_ZombieActivate : MonoBehaviour
{
    public int TriggerID = -1;
    public GameObject[] ZombiesToActivate;

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
