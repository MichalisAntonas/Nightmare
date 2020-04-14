using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    public static System.DateTime startTime;

    void Start()
    {
        startTime = System.DateTime.UtcNow;
        Analytics.CustomEvent("level_start", new Dictionary<string, object>
        {
            { "timestamp", startTime.ToString("s") }
        });
        Debug.Log(startTime.ToString("s"));
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag != "Player")
            return;

        Analytics.CustomEvent("level_complete", new Dictionary<string, object>
        {
            { "timestamp", System.DateTime.UtcNow.ToString("s") },
            { "seconds_taken", (int)(System.DateTime.UtcNow - startTime).TotalSeconds }
        });

        Debug.Log(System.DateTime.UtcNow.ToString("s"));
        Debug.Log((int)(System.DateTime.UtcNow - startTime).TotalSeconds);

        SceneManager.LoadScene(4);
        Cursor.visible = true;
    }
}
