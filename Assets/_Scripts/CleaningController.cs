using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CleaningController : MonoBehaviour {

    public Image dirt1;
    public Image dirt2;
    public Image dirt3;

    public Camera mainCamera;
    public GameObject player;
    public AudioSource flusSound;

    private DirtController dirtController;

    void Update()
    {
        gameObject.transform.position =  new Vector3(mainCamera.ScreenToWorldPoint(Input.mousePosition).x, mainCamera.ScreenToWorldPoint(Input.mousePosition).y, 0f);
    }

    public void LimpiarDirt()
    {
        flusSound.Play();
        player.GetComponent<YuyuController>()._actualYuyu -= 15;
    }

}
