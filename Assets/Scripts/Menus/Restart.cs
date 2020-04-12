using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Restart : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(TakeToGame());

    }

    IEnumerator TakeToGame()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(2);

    }
}
