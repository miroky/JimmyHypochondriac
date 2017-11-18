using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITextFiller : MonoBehaviour {

    
    private Text text;
    private float actualFill;

    void Start()
    {
         text = GetComponent<Text>();         
         float actualFill = GameObject.FindGameObjectWithTag("Player").GetComponent<ShootingController>().clinesAmmo;     
       
         text.text = actualFill.ToString();
    }
    
    void Update()
    {

        float actualFill = GameObject.FindGameObjectWithTag("Player").GetComponent<ShootingController>().clinesAmmo;
        text.text = actualFill.ToString();
    }
}
