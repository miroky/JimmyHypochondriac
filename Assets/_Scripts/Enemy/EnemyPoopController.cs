using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPoopController : MonoBehaviour
{

    public GameObject bullet;
    public GameObject spawnPoint;
    public GameObject birdPlatform;

    private Quaternion myRotation;
    private Vector3 direction;
    private AudioSource shootSound;

    private bool canPass = false;

    private float time;
    public float shootInterval;

    // Use this for initialization
    void Start()
    {
        time = 0;
        if (birdPlatform != null)
        {
            canPass = true;
        }
        else
        {
            birdPlatform = null;
        }
    }

    // Update is called once per frame
    void Update()
    {

        time++;

        if (time == shootInterval)
        {
            myRotation = transform.rotation;

            //SE INSTANCIA LA BALA
            GameObject bulletClone;
            bulletClone = (GameObject)Instantiate(bullet, spawnPoint.transform.position, myRotation);

            if (canPass == true)
                Physics2D.IgnoreCollision(bulletClone.GetComponent<Collider2D>(), birdPlatform.GetComponent<Collider2D>());

            time = 0;
        }

    }

    //Control de colisiones para el suelo
    void OnCollisionEnter2D(Collision2D col)
    {
        // BORRAR CACA CUANDO TOQUE EL SUELO Y PLAYER
        if (col.gameObject.tag == "Player" || col.gameObject.name == "Floor")
        {
            DestroyObject(this);
        }
    }
}