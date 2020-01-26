using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GlobalAmmo : MonoBehaviour
{
    public static int ammoCount;
    public GameObject ammoDisplay;
    public int internalAmmo;
    void Update()
    {
        internalAmmo = ammoCount;
        ammoDisplay.GetComponent<Text>().text = "" + ammoCount;
    }
}
