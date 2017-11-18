using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiableSpawnController : MonoBehaviour {

    private bool activo = true;

    public GameObject enemy;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && activo == true)
        {
            enemy.SetActive(false);
            activo = false;
        }
    }
}