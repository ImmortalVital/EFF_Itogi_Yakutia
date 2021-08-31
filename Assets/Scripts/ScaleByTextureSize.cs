using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScaleByTextureSize : MonoBehaviour
{
    public GameObject Lang;
    LanguageController LanguageController;
    void Start()
    {
        Lang = GameObject.Find("Controller");
        LanguageController = Lang.GetComponent<LanguageController>();

        GetComponent<RectTransform>().sizeDelta = GetComponent<Image>().sprite.bounds.size * 60f;
    }
    void Update()
    {
        GetComponent<RectTransform>().sizeDelta = GetComponent<Image>().sprite.bounds.size * 60f;
        //Debug.Log(LanguageController.Toggled);
        /*if (LanguageController.Toggled)
        {
            GetComponent<RectTransform>().sizeDelta = GetComponent<Image>().sprite.bounds.size * 60f;
            LanguageController.SetToggle();
            Debug.Log("Scaled");
        }*/
    }
}
