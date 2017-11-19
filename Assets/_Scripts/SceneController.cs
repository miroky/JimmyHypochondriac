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
        SceneManager.LoadScene("Main_menu");
    }
    public void LoadOpening()
    {
        SceneManager.LoadScene("Opening");
    }
    public void LoadStreet()
    {
        SceneManager.LoadScene("Street");
    }
    public void LoadCredits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
