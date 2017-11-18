using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlusBehaviour : MonoBehaviour {

    [HideInInspector] public Vector3 direction;
    public float speed;

    //SE ACTUALIZA LA POSICION DE LA BALA USANDO LA VELOCIDAD Y LA DIRECCION (DADA DESDE EL SCRIPT SHOOT)
    void Start()
    {
        //GetComponent<Rigidbody2D>().velocity = new Vector2(direction.x * speed, direction.y * speed);
    }

    //SE DESTRUYE LA BALA EN 0.5 SEGUNDOS SI NO CONTACTA CON NADA
    void Update()
    {
        Destroy(gameObject, 0.07f);
    }

    //DESTRUCCION DE LA BALA EN CASO DE CHOQUE
    void OnTriggerEnter2D(Collider2D collisioner)
    {
        //GESTION DE LA COLISION DE LA BALA CON UN ENEMIGO
        if (collisioner != null)
        {
            if (collisioner.gameObject.CompareTag("Enemy"))
            {
                collisioner.GetComponent<EnemyController>().hpPoints--;
            }
        }
        Destroy(gameObject);
    }
}
