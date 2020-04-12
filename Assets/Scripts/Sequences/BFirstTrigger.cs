using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.UI;
public class BFirstTrigger : MonoBehaviour
{
    public GameObject ThePlayer;
    public GameObject TextBox;
    public GameObject TheMarker;
    

    void OnTriggerEnter()
    {
        this.GetComponent<BoxCollider>().enabled = false;
        
        StartCoroutine(ScenePlayer());
    }
    IEnumerator ScenePlayer()
    {
        TheMarker.SetActive(true);
     
        TextBox.GetComponent<Text>().text = "Looks like there is a weapon on that box.";
        yield return new WaitForSeconds(8);
        TextBox.GetComponent<Text>().text = "";
       
      
    }
}
