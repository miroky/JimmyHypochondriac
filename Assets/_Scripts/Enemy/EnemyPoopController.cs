using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPoopController : MonoBehaviour {

    public GameObject bullet;
    public GameObject spawnPoint;

    private Quaternion myRotation;
    private Vector3 direction;
    private AudioSource shootSound;

    private float time;

    public float shootInterval;

    // Use this for initialization
    void Start()
    {
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {

        time++;

        if (time == shootInterval)
        {

            Debug.Log("POOP");

            //SE INSTANCIA EL SONIDO DEL DISPARO Y SE GUARDA LA ROTACION DEL TRANSFORM
            //shootSound.Play();
            GameObject bulletClone;
            myRotation = transform.rotation;

            //SE INSTANCIA LA BALA
            bulletClone = (GameObject)Instantiate(bullet, spawnPoint.transform.position, myRotation);

            time = 0;
        }

    }

    //Control de colisiones para el suelo
    void OnCollisionEnter2D(Collision2D col)
    {
        // BORRAR CACA CUANDO TOQUE EL SUELO Y PLAYER
        if(col.gameObject.tag == "Player" || col.gameObject.name == "Floor")
        {
            DestroyObject(this);
        }
    }
}
