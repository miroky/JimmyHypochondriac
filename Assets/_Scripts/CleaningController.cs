﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CleaningController : MonoBehaviour {

    public Image dirt1;
    public Image dirt2;
    public Image dirt3;


    public Camera mainCamera;
    public GameObject player;


    private Color colFaded;
    private DirtController dirtController;

    void Start () {
        colFaded = new Color(1f, 1f, 0.5f);
    }

    void Update()
    {
        gameObject.transform.position =  new Vector3(mainCamera.ScreenToWorldPoint(Input.mousePosition).x, mainCamera.ScreenToWorldPoint(Input.mousePosition).y, 0f);
    }

    public void LimpiarDirt()
    {
        player.GetComponent<YuyuController>()._actualYuyu -= 15;
    }

}
