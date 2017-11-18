using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	public float hpPoints;
	
	// Update is called once per frame
	void Update () {
		//Si su vida es mayor a 0, ejecutamos lo que necesitemos
		if (IsAlive())
		{

		}
        else
        {
            Destroy(gameObject);
        }

	}


	// Comprueba que el enemigo siga vivo
	private bool IsAlive()
	{
		if (hpPoints <= 0)
		{
			return false;
		}
		else
		{
			return true;
		}
	}
}
