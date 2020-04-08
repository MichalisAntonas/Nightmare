using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {
        AnalyticsEvent.GameOver();

        //StartCoroutine(TakeToFinish());
        SceneManager.LoadScene(4);
        Cursor.visible = true;
    }

    /*IEnumerator TakeToFinish()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(4);
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(2);

    }*/
}
