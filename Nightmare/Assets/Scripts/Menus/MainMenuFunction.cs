using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuFunction : MonoBehaviour
{

    public GameObject fadeOut;
    public GameObject loadText;
    public AudioSource buttonClick;

    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    
    public void PlayGameButton()
    {
        StartCoroutine(NewGameStart());
    }
    public void Exit()
    {
        
        StartCoroutine(ExitButton());
    }
    IEnumerator NewGameStart()
    {
        fadeOut.SetActive(true);
        buttonClick.Play();
        yield return new WaitForSeconds(4);
        loadText.SetActive(true);
        SceneManager.LoadScene(2);
    }
    IEnumerator ExitButton()
    {
       
        buttonClick.Play();
        Application.Quit();
        yield return new WaitForSeconds(1);
        
    }
}
