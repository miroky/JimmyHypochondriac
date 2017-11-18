using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCoughController : MonoBehaviour {

    public GameObject bullet;
    public GameObject spawnPoint;

    private Quaternion myRotation;
    private Vector3 direction;
    private AudioSource shootSound;

    private float time;

    public float shootInterval;
    public float localCoughSpeed;

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

            GameObject flusBulletClone;
            myRotation = transform.rotation;

            //SE INSTANCIA LA BALA
            flusBulletClone = (GameObject)Instantiate(bullet, spawnPoint.transform.position, Quaternion.identity);
            flusBulletClone.GetComponent<Rigidbody2D>().velocity = new Vector2(-10, localCoughSpeed);

            time = 0;

        }
    }
}
