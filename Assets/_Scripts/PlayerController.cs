using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public GameObject fluFlu;
    public Button button1;
    public Button button2;
    public Button button3;
    public Rigidbody2D rb;

    private ShootingController shootingController;
    private ScrollController scrollController;
    private Animator anim;

    void Start()
    {
        scrollController = GetComponent<ScrollController>();
        anim = GetComponent<Animator>();
        shootingController = GetComponent<ShootingController>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            scrollController.enabled = !scrollController.enabled;
            shootingController.enabled = !shootingController.enabled;
            fluFlu.gameObject.SetActive(!fluFlu.gameObject.activeInHierarchy);

            rb.velocity = new Vector2(0f, 0f);
            anim.SetBool("isWalking", false);

            button1.interactable = !button1.interactable;
            button2.interactable = !button2.interactable;
            button3.interactable = !button3.interactable;
        }

    }



}
