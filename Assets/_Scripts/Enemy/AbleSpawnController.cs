using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbleSpawnController : MonoBehaviour {

    private bool activo = true;

    public GameObject enemy;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && activo == true)
        {
            enemy.SetActive(true);
            activo = false;
        }
    }
}
