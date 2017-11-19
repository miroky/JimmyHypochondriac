using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;


public class Opening_cinematic : MonoBehaviour {

    public VideoPlayer movie;
    private float seconds = 0f;

	void LateUpdate () {
        seconds += Time.deltaTime;
        if (!movie.isPlaying && seconds>2)
        {
            Debug.Log(movie.isPlaying);
            SceneManager.LoadScene("Street");
        }

    }
}
