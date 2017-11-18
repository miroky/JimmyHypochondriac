using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoopBehaviour : MonoBehaviour {

    //Control de colisiones para el suelo o Player
    void OnCollisionEnter2D(Collision2D col)
    {

        // BORRAR CACA CUANDO TOQUE EL SUELO Y PLAYER
        if (col.gameObject.tag == "Player")
        {
            if(col.gameObject.GetComponent<YuyuController>()._actualYuyu < 100)
            {
                col.gameObject.GetComponent<YuyuController>()._actualYuyu += 10;
            }
            Destroy(gameObject);
        }

        Destroy(gameObject, 1f);
    }
}
