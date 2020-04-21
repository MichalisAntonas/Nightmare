using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LockedDoor : MonoBehaviour
{
    public float TheDistance;

    [Header("Game Objects")]
    public GameObject Key;
    public GameObject ZombieToActivate;
    public GameObject ActionDisplay;
    public GameObject ActionText; 
    public GameObject ExtraCross;
    public GameObject firstKeyDoor;
    public GameObject TextBox;

    [Header("Audio")]
    public AudioSource Lockdoor;
    public AudioSource OpenDoor;

    void Update()
    {
        TheDistance = PlayerCasting.DistanceFromTarget;
    }

    void OnMouseOver()
    {
        if (TheDistance <= 2)
        {
            ExtraCross.SetActive(true);
            ActionText.GetComponent<Text>().text = "Open Door";
            ActionDisplay.SetActive(true);
            ActionText.SetActive(true);
        }

        if (Input.GetButtonDown("Action"))
        {
            if (TheDistance <= 2)
            {
                this.GetComponent<BoxCollider>().enabled = false;
                ActionDisplay.SetActive(false);
                ActionText.SetActive(false);
                ExtraCross.SetActive(false);
                StartCoroutine(DoorReset());
            }
        }
    }

    void OnMouseExit()
    {
        ExtraCross.SetActive(false);
        ActionDisplay.SetActive(false);
        ActionText.SetActive(false);
    }

    IEnumerator DoorReset()
    {
        if (!GlobalInventory.firstDoorKey)
        {
            Lockdoor.Play();
            yield return new WaitForSeconds(1);

            Key.SetActive(true);
            ZombieToActivate.SetActive(true);

            this.GetComponent<BoxCollider>().enabled = true;
            TextBox.GetComponent<Text>().text = "I need to find the key to open this door.";

            yield return new WaitForSeconds(7);
            TextBox.GetComponent<Text>().text = "";
        }

        else
        {
            OpenDoor.Play();
            firstKeyDoor.GetComponent<Animator>().Play("FinalDoor");
            yield return new WaitForSeconds(1.1f);
            this.GetComponent<BoxCollider>().enabled = false;
        }
    }
}
