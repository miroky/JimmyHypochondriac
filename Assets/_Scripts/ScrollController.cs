using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollController : MonoBehaviour {

    //Private variables
    private Rigidbody2D rb;
    private bool isJumping;
    private Animator anim;

    //Public variables
    public float speed;
    public float jumpForce;
    public bool facingRight;
    public AudioSource walkSound;
    public AudioSource mocoSound;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isJumping = false;
        facingRight = true;
        anim = GetComponent<Animator>();
    }


    private void Update()
    {
        if (Input.GetButtonDown("Jump") && (!isJumping))
        {
            Jump();
        }
    }


    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(speed * Time.deltaTime, rb.velocity.y);
            if (!facingRight)
                Flip();
            anim.SetBool("isWalking", true);
            walkSound.loop = true;

            if (!walkSound.isPlaying)
            {
                walkSound.loop = true;
                walkSound.Play();
            }
        }
        else if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(speed * Time.deltaTime * -1, rb.velocity.y);
            if (facingRight)
                Flip();
            anim.SetBool("isWalking", true);
            walkSound.loop = true;

            if (!walkSound.isPlaying)
            {
                walkSound.loop = true;
                walkSound.Play();
            }
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            anim.SetBool("isWalking", false);
            walkSound.loop = false;
            walkSound.Stop();
        }
        
    }


    //Control de colisiones para el suelo
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Platform")
        {
            isJumping = false;
        }
        else if(col.gameObject.tag.Equals("Enemy") || col.gameObject.tag.Equals("Garbaje"))
        {
            mocoSound.Play();
        }
    }


    //Salto y doble salto (si permitido, mediante parámetro canDoubleJump) del personaje
    private void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0f);
        rb.AddForce(new Vector2(0f, jumpForce));
        isJumping = true;
        anim.SetTrigger("jump");
    }

    //METODO QUE INVIERTE EL SPRITE AL GIRAR EL PLAYER
    public void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0, Space.Self);
    } //end Flip

}
