using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIImageFiller : MonoBehaviour {

    public enum UITypes { YUYU,FLUSFLUS,CLINES};
    public UITypes uiType;
    public float totalFill=100f;
    
    private Image image;
    private float actualFill;

    void Start()
    {
        image = GetComponent<Image>();
        if (uiType.ToString() == "YUYU")
        {            
            float actualFill = GameObject.FindGameObjectWithTag("Player").GetComponent<YuyuController>()._actualYuyu;

        }
        if (uiType.ToString() == "FLUSFLUS")
        {            
            float actualFill = GameObject.FindGameObjectWithTag("Player").GetComponent<ShootingController>().flusAmmo;
        }
       
        float portion = Mathf.InverseLerp(0, totalFill, actualFill);
        image.fillAmount = portion;
    }
    
    void Update()
    {
        if (uiType.ToString() == "YUYU")
        {
            actualFill = GameObject.FindGameObjectWithTag("Player").GetComponent<YuyuController>()._actualYuyu;
        }
        if (uiType.ToString() == "FLUSFLUS")
        {
            actualFill = GameObject.FindGameObjectWithTag("Player").GetComponent<ShootingController>().flusAmmo;
        }
        float portion = Mathf.InverseLerp(0, totalFill, actualFill);
        image.fillAmount = portion;
    }
}
