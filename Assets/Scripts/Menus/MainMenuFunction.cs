using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuFunction : MonoBehaviour
{
    public GameObject fadeOut;
    public GameObject loadText;
    public AudioSource buttonClick;
    public string CurrentSurveyURL = string.Empty;

    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    
    public void Button_PlayGame()
    {
        StartCoroutine(NewGameStart());
    }

    public void Button_OpenSurvey()
    {
        if (this.CurrentSurveyURL.Length > 0)
            Application.OpenURL(this.CurrentSurveyURL);
    }

    public void Button_Exit()
    {
        buttonClick.Play();
        Application.Quit();
    }

    IEnumerator NewGameStart()
    {
        fadeOut.SetActive(true);
        buttonClick.Play();
        yield return new WaitForSeconds(4);
        loadText.SetActive(true);
        SceneManager.LoadScene(2);
    }
}
