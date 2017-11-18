using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicController : MonoBehaviour {

    private string levelName;
    private static MusicController instance = null;

    public static MusicController Instance
    {
        get { return instance; }
    }

    //Attachar un clip de sonido al instanciarlo en la escena (música de fondo)
    void Awake()
    {
        if (instance != null && instance != this)
        {
            if (instance.GetComponent<AudioSource>().clip != GetComponent<AudioSource>().clip)
            {
                instance.GetComponent<AudioSource>().clip = GetComponent<AudioSource>().clip;
                instance.GetComponent<AudioSource>().volume = GetComponent<AudioSource>().volume;
                instance.GetComponent<AudioSource>().Play();
            }
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        GetComponent<AudioSource>().Play();
        DontDestroyOnLoad(this.gameObject);
    }


    void Update()
    {
        //El controller compartirá el singleton con el Main_menu y Options
        levelName = SceneManager.GetActiveScene().name;
        if (!levelName.Equals("Main_menu") && !levelName.Equals("Options"))
        {
            Destroy(this.gameObject);
        }

    }
}
