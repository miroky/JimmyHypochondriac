using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YuyuController : MonoBehaviour {

    // Controlador del yuyu del personaje
    // Dos modos de aumentar:
    // 1) Cuando un enemigo esté entre en el collider del player aumentará una cantidad fija 
    //    por cada 5 segundos mientras esté vivo el enemigo
    // 2) Zona especial, el vertedero: en está zona aumentará la barra de yuyu por segundo


    public float _enemyYuyuIncrease = 5f;
    public float _garbageYuyuIncrease = 1f;

    public float _secondsDelayEnemy = 1f;
    public float _secondsDelayGarbage = 1f;

    public float _initialYuyu = 100f;
    public float _actualYuyu;

    private bool _inYuyuArea = false;
    private bool _inYuyuEnemy = false;

    private void Start()
    {
        _actualYuyu = _initialYuyu;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            _inYuyuEnemy = true;
            StartCoroutine(YuyuIncreaseTroughTimeEnemies(_secondsDelayEnemy, _enemyYuyuIncrease));
        }
        if (other.tag == "Garbage")
        {
            _inYuyuArea = true;
             StartCoroutine(YuyuIncreaseTroughTime(_secondsDelayGarbage, _garbageYuyuIncrease));
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Garbage")
            _inYuyuArea=false;

        if (other.tag == "Enemy")
            _inYuyuEnemy=false;
    }

    private IEnumerator YuyuIncreaseTroughTime(float secondsWait, float yuyuIncrease)
    {
        while (_inYuyuArea)
        {
            yield return new WaitForSeconds(secondsWait);
            _actualYuyu += yuyuIncrease;
        }
    }
    
    private IEnumerator YuyuIncreaseTroughTimeEnemies(float secondsWait, float yuyuIncrease)
    {
        Debug.Log(_inYuyuArea);
        while (_inYuyuEnemy)
        {
            yield return new WaitForSeconds(secondsWait);
            _actualYuyu += yuyuIncrease;
        }
    }
}
