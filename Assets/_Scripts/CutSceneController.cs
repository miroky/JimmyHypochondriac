using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutSceneController : MonoBehaviour {

    public GameObject canvasEnd;
    public AudioSource endAudio;

    private AudioSource[] allAudioSources;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            allAudioSources = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
            foreach (AudioSource audioS in allAudioSources)
            {
                if (audioS.isPlaying)
                    audioS.Stop();
            }
            endAudio.Play();
            canvasEnd.SetActive(true);
            Time.timeScale = 0f;
        }
    }

}
