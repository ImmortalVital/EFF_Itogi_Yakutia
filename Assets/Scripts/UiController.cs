using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiController : MonoBehaviour
{
    // Start is called before the first frame update
    public float tweenTime;
    CanvasGroup CanvasGroup;

    public GameObject MainUI;
    public RectTransform panelRectTransform;



    void Start()
    {
        CanvasGroup = MainUI.gameObject.GetComponent<CanvasGroup>();
        panelRectTransform = MainUI.gameObject.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeUi()
    {
        LeanTween.cancel(this.gameObject);
        LeanTween.alphaCanvas(CanvasGroup, 0, 0).setEaseInOutSine();
        panelRectTransform.SetAsFirstSibling();
        //Debug.Log("UI Changed");
    }

    public void BackToMainUi()
    {
        //LeanTween.cancel(gameObject);
        LeanTween.alphaCanvas(CanvasGroup, 1, 1).setEaseInOutSine();
        panelRectTransform.SetAsLastSibling();
        //Debug.Log("UI Backed");
    }
}
