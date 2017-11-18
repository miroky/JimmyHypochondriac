using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingController : MonoBehaviour
{

    public GameObject bullet;
    public GameObject flusBullet;
    public GameObject spawnPoint;
    public AudioSource flusSound;
    public AudioSource clinesSound;
    public AudioSource reloadSound;

    public float bulletSpeed;
    public float flusSpeed;
    public float localBulletSpeed;
    public float localFlusSpeed;

    public int clinesAmmo;
    public int flusAmmo;
    public int maxFlusAmmo;

    private Quaternion myRotation;
    private bool isFacingRight;
    private Rigidbody2D rb;
    private YuyuController _yuyuController;

    void Start()
    {
        isFacingRight = GetComponent<ScrollController>().facingRight;
        localBulletSpeed = bulletSpeed;
        localFlusSpeed = flusSpeed;
        rb = GetComponent<Rigidbody2D>();
        maxFlusAmmo = 100;
        _yuyuController = GameObject.FindGameObjectWithTag("Player").GetComponent<YuyuController>();
    }


    void Update()
    {
        if (_yuyuController.GetYuyuLevel() < 3)
        {
            if (Input.GetKeyDown(KeyCode.Return) && clinesAmmo > 0)
            {
                isFacingRight = GetComponent<ScrollController>().facingRight;
                CheckSpeed();

                GameObject bulletClone;
                myRotation = transform.rotation;

                //SE INSTANCIA LA BALA
                bulletClone = (GameObject)Instantiate(bullet, spawnPoint.transform.position, myRotation);
                bulletClone.GetComponent<Rigidbody2D>().velocity = new Vector2(localBulletSpeed, bulletClone.GetComponent<Rigidbody2D>().velocity.y);
                clinesAmmo--;

                StartCoroutine("playAudio", clinesSound);
            }

            if (Input.GetKeyDown(KeyCode.E) && flusAmmo > 0)
            {
                isFacingRight = GetComponent<ScrollController>().facingRight;
                CheckSpeed();

                GameObject flusBulletClone;
                myRotation = transform.rotation;

                //SE INSTANCIA LA BALA
                flusBulletClone = (GameObject)Instantiate(flusBullet, spawnPoint.transform.position, myRotation);
                flusBulletClone.GetComponent<Rigidbody2D>().velocity = new Vector2(localFlusSpeed, flusBulletClone.GetComponent<Rigidbody2D>().velocity.y);
                flusAmmo -= 10;

                StartCoroutine("playAudio", flusSound);
            }

            if (rb.velocity.x == 0f && rb.velocity.y == 0)
            {
                if (Input.GetKeyDown(KeyCode.R) && flusAmmo < maxFlusAmmo)
                {
                    StartCoroutine("playAudio", reloadSound);
                    flusAmmo += 10;
                }
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.R) && clinesAmmo > 0)
            {
                isFacingRight = GetComponent<ScrollController>().facingRight;
                CheckSpeed();

                GameObject bulletClone;
                myRotation = transform.rotation;

                //SE INSTANCIA LA BALA
                bulletClone = (GameObject)Instantiate(bullet, spawnPoint.transform.position, myRotation);
                bulletClone.GetComponent<Rigidbody2D>().velocity = new Vector2(localBulletSpeed, bulletClone.GetComponent<Rigidbody2D>().velocity.y);
                clinesAmmo--;

                StartCoroutine("playAudio", clinesSound);
            }

            if (Input.GetKeyDown(KeyCode.Return) && flusAmmo > 0)
            {
                isFacingRight = GetComponent<ScrollController>().facingRight;
                CheckSpeed();

                GameObject flusBulletClone;
                myRotation = transform.rotation;

                //SE INSTANCIA LA BALA
                flusBulletClone = (GameObject)Instantiate(flusBullet, spawnPoint.transform.position, myRotation);
                flusBulletClone.GetComponent<Rigidbody2D>().velocity = new Vector2(localFlusSpeed, flusBulletClone.GetComponent<Rigidbody2D>().velocity.y);
                flusAmmo -= 10;

                StartCoroutine("playAudio", flusSound);
            }

            if (rb.velocity.x == 0f && rb.velocity.y == 0)
            {
                if (Input.GetKeyDown(KeyCode.E) && flusAmmo < maxFlusAmmo)
                {
                    StartCoroutine("playAudio", reloadSound);
                    flusAmmo += 10;
                }
            }
        }
    }

    public void CheckSpeed()
    {
        if (isFacingRight)
        {
            localBulletSpeed = bulletSpeed;
            localFlusSpeed = flusSpeed;
        }

        else
        {
            localBulletSpeed = -bulletSpeed;
            localFlusSpeed = -flusSpeed;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("ClinesAmmo"))
        {
            clinesAmmo += 10;
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag.Equals("FlusAmmo"))
        {
            flusAmmo += 5;
            if (flusAmmo > 100)
                flusAmmo = 100;
            Destroy(collision.gameObject);
        }
    }


    IEnumerator playAudio(AudioSource source)
    {
        AudioSource.PlayClipAtPoint(source.clip, transform.position);
        yield break;
    }
}