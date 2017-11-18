using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {	

    public void LoadHouse()
    {
        SceneManager.LoadScene("House");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Main_menu");
    }
    public void LoadPharmacy()
    {
        SceneManager.LoadScene("Pharmacy");
    }
    public void LoadStreet()
    {
        SceneManager.LoadScene("Street");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
