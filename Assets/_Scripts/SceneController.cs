using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {	

    public void LoadEnding()
    {
        SceneManager.LoadScene("Ending");
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main_menu");
    }
    public void LoadOpening()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Opening");
    }
    public void LoadStreet()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Street");
    }
    public void LoadCredits()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Credits");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
