using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoboxTrigger : MonoBehaviour
{
    public GameObject ThePlayer;

    public GameObject AmmoBoxObj;

    void OnTriggerEnter()
    {
        this.GetComponent<BoxCollider>().enabled = false;
        AmmoBoxObj.SetActive(true);
     
    }
   
}
