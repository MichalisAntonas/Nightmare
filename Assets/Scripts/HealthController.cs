using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;

public class HealthController : MonoBehaviour
{
    public float MAX_HEALTH = 100f;

    private float health = 100f;
    public float Health
    {
        get
        {
            return this.health;
        }
        set
        {
            this.health = Mathf.Min(MAX_HEALTH, value);
            if (this.Health <= 0)
            {
                Analytics.CustomEvent("player_death", new Dictionary<string, object>
                {
                    { "time", (int)(System.DateTime.UtcNow - Finish.startTime).TotalSeconds }
                });
                Debug.Log("AnalyticsEvent: player_death");
                SceneManager.LoadScene(3);
            }
        }
    }
}
