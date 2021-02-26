using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.UI;

public class AOpening : MonoBehaviour
{
    public GameObject ThePlayer;
    public GameObject FadeScreenIn;
    public GameObject TextBox;
    public GameObject Controls;
    void Start()
    {
        //ThePlayer.GetComponent<FirstPersonController>().enabled = false;
        StartCoroutine(ScenePlayer());
    }
   
    IEnumerator ScenePlayer()
    {
        yield return new WaitForSeconds(3);
        FadeScreenIn.SetActive(false);
       
        TextBox.GetComponent<Text>().text = "Where am I?";
        Controls.GetComponent<Text>().text = "Movement - W,A,S,D\nJump - Space\nRun - Shift\nPick Up Itmes - E\nFire - Left Click";
        yield return new WaitForSeconds(7);
        TextBox.GetComponent<Text>().text = "";
        Controls.GetComponent<Text>().text = "";


        yield return new WaitForSeconds(7);
        
        // ThePlayer.GetComponent<FirstPersonController>().enabled = true;
    }
}
