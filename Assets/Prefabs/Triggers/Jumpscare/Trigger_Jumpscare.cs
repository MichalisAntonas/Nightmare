using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class Trigger_Jumpscare : MonoBehaviour
{
    [Tooltip("The percentage chance for this trigger to activate when walked into. This object will destroy itself when colliding with the player, whether or not the trigger was activated.")]
    public float Chance = 100;
    public List<AudioClip> AudioClips;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Player")
            return;

        if (this.Chance >= Random.Range(0f, 100f))
        {
            other.GetComponent<AudioSource>().PlayOneShot(this.AudioClips[Random.Range(0, this.AudioClips.Count)], .4f);
            Analytics.CustomEvent("trigger_jumpscare");
            Debug.Log("AnalyticsEvent: trigger_jumpscare");
        }

        Destroy(this.gameObject);
    }
}
