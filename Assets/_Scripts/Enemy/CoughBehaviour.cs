﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoughBehaviour : MonoBehaviour {

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
        Destroy(gameObject, 1f);
    }


    //DESTRUCCION DE LA BALA EN CASO DE CHOQUE
    void OnCollisionEnter2D(Collision2D collisioner)
    {
        //GESTION DE LA COLISION DE LA BALA CON UN ENEMIGO
        if (collisioner != null)
        {
            if (collisioner.gameObject.CompareTag("Player"))
            {
                collisioner.gameObject.GetComponent<YuyuController>()._actualYuyu += 5;
                Destroy(gameObject);
            }
        }
    }
}
