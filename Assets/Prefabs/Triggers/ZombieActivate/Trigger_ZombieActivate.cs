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

        Analytics.CustomEvent("level_step", new Dictionary<string, object>
        {
            { "step", this.TriggerID },
            { "time", (int)(System.DateTime.UtcNow - Finish.startTime).TotalSeconds }
        });
        Debug.Log("AnalyticsEvent: level_step");

        foreach (GameObject zombie in this.ZombiesToActivate)
            zombie.GetComponent<ZombieScript>().Activate();

        Destroy(this.gameObject);
    }
}
