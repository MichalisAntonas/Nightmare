using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
                SceneManager.LoadScene(3);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
