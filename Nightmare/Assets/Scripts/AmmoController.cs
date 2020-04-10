using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoController : MonoBehaviour
{
    public int MAX_AMMO_COUNT = 20;

    public GameObject TextDisplay;
    private Text textComp;

    public GameObject BulletDisplay;

    private int count = 0;
    public int AmmoCount
    {
        get
        {
            return this.count;
        }
        set
        {
            this.count = Mathf.Max(0, Mathf.Min(MAX_AMMO_COUNT, value));
            this.textComp.text = this.count.ToString();

            // <GameObject>.transform implements an IEnumerator that holds all children GameObjects
            Transform bulletImages = this.BulletDisplay.transform;
            for (int i = 0; i < bulletImages.childCount; i++)
            {
                var image = bulletImages.GetChild(i);
                if (((float)this.AmmoCount / (float)MAX_AMMO_COUNT) > ((float)i / (float)bulletImages.childCount))
                    image.gameObject.SetActive(true);
                else
                    image.gameObject.SetActive(false);
            }
        }
    }

    void Start()
    {
        this.textComp = this.TextDisplay.GetComponent<Text>();
    }
}
