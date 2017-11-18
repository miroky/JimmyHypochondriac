using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuController : MonoBehaviour {

    public GameObject pauseMenu;

    private bool isPaused;
    private float realTimeScale;

	void Start () {
        isPaused = false;
    }
	
	void Update () {
        if (Input.GetButtonDown("Pause") && !isPaused)
        {
            realTimeScale = Time.timeScale;
            Time.timeScale = 0f;
            ShowPauseMenu();
        }
        else if (Input.GetButtonDown("Pause") && isPaused)
        {
            realTimeScale = Time.timeScale;
            Time.timeScale = realTimeScale;
            HidePauseMenu();
        }
    }


    public void ShowPauseMenu()
    {
        isPaused = true;
        pauseMenu.SetActive(true);
    }

    public void HidePauseMenu()
    {
        isPaused = false;
        pauseMenu.SetActive(false);
    }
}
