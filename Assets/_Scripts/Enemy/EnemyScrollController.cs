using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScrollController : MonoBehaviour {

    public YuyuController yuyuController;

    public enum EnemyTypes
    {
        Gato, Mendigo, Mujer_Ninyo, Paloma, Excursionistas
    }

    public enum Directions
    {
        Izq, Dcha
    }

    // Private variables
    private Rigidbody2D rb;
	private bool isJumping;

    private float direction;

    private float time;
    private float jumpForce;
    private float jumpInterval;

    // Public variables
    public EnemyTypes enemyType;
    public Directions movDirection;
    public float speed;

    void Start () {
		rb = GetComponent<Rigidbody2D>();
		isJumping = false;
        jumpInterval = -1;
        time = 0;

        if(movDirection.ToString() == "Izq")
        {
            direction = -1;
        }
        else
        {
            direction = 1;
        }
		
        if(enemyType.ToString() == "Gato")
        {
            jumpForce = 300;
            jumpInterval = 25;
        }
        else if (enemyType.ToString() == "Paloma")
        {
            jumpForce = 250;
            jumpInterval = 1;
        }
        else if (enemyType.ToString() == "Mendigo")
        {
            speed = 0;
        }
    }
	

	void Update () {
		if (jumpInterval != -1 && !isJumping)
		{
            time++;

            if(time == jumpInterval)
            {
                if (enemyType.ToString() == "Gato")
                {
                    isJumping = true;
                }

                Jump();

                time = 0;
            }
		}
        
	}

	void FixedUpdate()
	{
        if (enemyType.ToString() != "Mendigo")
        {
            rb.velocity = new Vector2(speed * Time.deltaTime * direction, rb.velocity.y);
        }
	}

	// Controlls the Jump
	private void Jump()
	{

		if (isJumping)
		{
			
		}

		rb.velocity = new Vector3(rb.velocity.x, 0f);
		rb.AddForce(new Vector2(0f, jumpForce));

        isJumping = true;

    }

    //Control de colisiones para el suelo
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Platform" || col.gameObject.tag == "PidgeonPlatform")
        {
            isJumping = false;
        }
        else if (col.gameObject.tag.Equals("Flus") && !gameObject.tag.Equals("Garbage"))
        {
            Destroy(gameObject);
        }
        else if (col.gameObject.tag.Equals("Player"))
        {
            yuyuController._actualYuyu += 10;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "EnemyTrigger")
        {

            if (direction == 1)
            {
                ChangeDirection(-1);
            }
            else
            {
                ChangeDirection(1);
            }
        }
    }

    void ChangeDirection(float dir)
    {
        direction = dir;
        transform.Rotate(0, 180, 0, Space.Self);
    }

}
