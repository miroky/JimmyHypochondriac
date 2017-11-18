using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public GameObject fluFlu;
    public Button button1;
    public Button button2;
    public Button button3;

    private ScrollController scrollController;

    void Start()
    {
        scrollController = GetComponent<ScrollController>();   
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            scrollController.enabled = !scrollController.enabled;
            fluFlu.gameObject.SetActive(!fluFlu.gameObject.activeInHierarchy);

            button1.interactable = !button1.interactable;
            button2.interactable = !button2.interactable;
            button3.interactable = !button3.interactable;
        }

    }



}
