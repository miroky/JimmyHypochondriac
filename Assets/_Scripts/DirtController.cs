using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

using UnityEngine;

public class DirtController : MonoBehaviour {

    public GameObject player;
    public Image dirt1;
    public Image dirt2;
    public Image dirt3;
    public SpriteRenderer yellowBackground;

    public Button boton1;
    public Button boton2;
    public Button boton3;

    private float max1;
    private float max2;
    private float max3;
    private float max4;
    private float max5;
    private float max6;

    private float playerHP;

    private Color colNone;
    private Color colFaded;
    private Color colComplete;

	void Start () {
        playerHP = player.GetComponent<YuyuController>()._actualYuyu;

        max1 = 15f;
        max2 = 30f;
        max3 = 45f;
        max4 = 60f;
        max5 = 75f;
        max6 = 88f;

        colNone = dirt1.color;
        colNone.a = 0f;

        colFaded = dirt1.color;
        colFaded.a = 0.5f;

        colComplete = dirt1.color;
        colComplete.a = 1f;
    }
	

	void Update () {
        playerHP = player.GetComponent<YuyuController>()._actualYuyu;

        if(playerHP < max1){
            SetDirtEnable(false, false, false);

            dirt1.color = colNone;
            dirt2.color = colNone;
            dirt3.color = colNone;

            boton1.interactable = false;
            boton2.interactable = false;
            boton3.interactable = false;
        }
        else if (playerHP > max1 && playerHP < max2)
        {
            SetDirtEnable(true, false, false);
            dirt1.color = colFaded;
            dirt2.color = colNone;
            dirt3.color = colNone;
        }
        else if(playerHP > max2 && playerHP < max3)
        {
            SetDirtEnable(true, false, false);
            dirt1.color = colComplete;
            dirt2.color = colNone;
            dirt3.color = colNone;
        }
        else if (playerHP > max3 && playerHP < max4)
        {
            SetDirtEnable(true, true, false);
            dirt1.color = colComplete;
            dirt2.color = colFaded;
            dirt3.color = colNone;
        }
        else if (playerHP > max4 && playerHP < max5)
        {
            SetDirtEnable(true, true, false);
            dirt1.color = colComplete;
            dirt2.color = colComplete;
            dirt3.color = colNone;
        }
        else if (playerHP > max5 && playerHP < max6)
        {
            SetDirtEnable(true, true, true);
            dirt1.color = colComplete;
            dirt2.color = colComplete;
            dirt3.color = colFaded;
        }
        else if (playerHP >= max6){
            SetDirtEnable(true, true, true);
            dirt1.color = colComplete;
            dirt2.color = colComplete;
            dirt3.color = colComplete;
        }
    }

    public void SetDirtEnable(bool dirt1Set, bool dirt2Set, bool dirt3Set)
    {
        dirt1.gameObject.SetActive(dirt1Set);
        dirt2.gameObject.SetActive(dirt2Set);
        dirt3.gameObject.SetActive(dirt3Set);
    }
}
