using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public GameObject gameOver;

    public float _secondsDelayGO;

    private YuyuController _yuyuController;

    private void Start()
    {
        _yuyuController = GameObject.FindGameObjectWithTag("Player").GetComponent<YuyuController>();
    }
    private void Update()
    {
        CheckGameOver();
    }

    private void CheckGameOver()
    {
        // Comprobar si el Yuyu ha llegado a 100
        if (_yuyuController._actualYuyu == 100)
        {
            //Mostrar escena de game over
            gameOver.SetActive(true);
            StartCoroutine(GameOver());
        }
    }

    private IEnumerator GameOver()
    {
        yield return new WaitForSeconds(_secondsDelayGO);
        SceneManager.LoadScene("Street");
    }
}
