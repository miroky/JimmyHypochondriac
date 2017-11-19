using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCoughController : MonoBehaviour {

    public GameObject bullet;
    public GameObject spawnPoint;

    private Vector3 direction;
    private AudioSource shootSound;
    private Rigidbody2D rb;

    private float time;

    public float shootInterval;
    public float localCoughSpeed;

    // Use this for initialization
    void Start()
    {
        time = 0;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        time++;

        if (time == shootInterval)
        {
            GameObject flusBulletClone;

            //SE INSTANCIA LA BALA
            flusBulletClone = (GameObject)Instantiate(bullet, spawnPoint.transform.position, Quaternion.identity);
            flusBulletClone.GetComponent<Rigidbody2D>().velocity = new Vector2(10 * Mathf.Sign(rb.velocity.x), localCoughSpeed);

            if(Mathf.Sign(rb.velocity.x) > 0)
            {
                flusBulletClone.GetComponent<SpriteRenderer>().flipX = true;
            }

            time = 0;
        }

    }
}
