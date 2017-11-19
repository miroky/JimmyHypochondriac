using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public GameObject gameOver;
    public Text secondsDisplay;

    public float _secondsDelayGO;

    private YuyuController _yuyuController;
    private AudioSource[] allAudioSources;
    private bool isGameOver = false;

    private void Start()
    {
        _yuyuController = GameObject.FindGameObjectWithTag("Player").GetComponent<YuyuController>();
    }
    private void Update()
    {
        if (isGameOver)
        {
            _secondsDelayGO -= Time.deltaTime;
            int second = (int)_secondsDelayGO;
            secondsDisplay.text = second.ToString();
        }

        if (!isGameOver)
            CheckGameOver();
    }

    private void CheckGameOver()
    {
        // Comprobar si el Yuyu ha llegado a 100
        if (_yuyuController._actualYuyu == 100)
        {
            isGameOver = true;
            allAudioSources = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
            foreach (AudioSource audioS in allAudioSources)
            {
                if (audioS.isPlaying)
                    audioS.Stop();
            }
            //Mostrar escena de game over
            gameOver.GetComponent<AudioSource>().Play();
            gameOver.SetActive(true);
            StartCoroutine(GameOver());
        }
    }

    private IEnumerator GameOver()
    {
        // Desactivar el control del player
        GameObject.FindGameObjectWithTag("Player").GetComponent<ScrollController>().enabled = false;
        GameObject.FindGameObjectWithTag("Player").GetComponent<ShootingController>().enabled = false;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().enabled = false;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);

        yield return new WaitForSeconds(_secondsDelayGO);
        SceneManager.LoadScene("Street");
    }
}
