using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiSelect : MonoBehaviour
{
    public GameObject OpennedUI;
    CanvasGroup canvasGroup;
    RectTransform panelRectTransform;
    
    GameObject movingDisplay;
    OverlayDisplayPositionController overlayDisplayPositionController;

    public GameObject Canvas;
    Transform MainUI;
    RectTransform panelRectTransformMain;

    public GameObject CanvasUi;
    CanvasGroup CanvasUiGroup;
    //1
    // Start is called before the first frame update
    void Start()
    {
        canvasGroup = OpennedUI.gameObject.GetComponent<CanvasGroup>();
        panelRectTransform = OpennedUI.GetComponent<RectTransform>();

        //MainUI = GameObject.Find("Microscope");
        MainUI = Canvas.transform.Find("MainUI");
        panelRectTransformMain = Canvas.GetComponent<RectTransform>();

        movingDisplay = GameObject.Find("OverlayDisplayPlaceholder");
        overlayDisplayPositionController = movingDisplay.GetComponent<OverlayDisplayPositionController>();
        OpennedUI.SetActive(false);

        CanvasUi = GameObject.Find("Canvas");
        CanvasUiGroup = CanvasUi.gameObject.GetComponent<CanvasGroup>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(overlayDisplayPositionController.isMoving);

        if (CanvasUiGroup.alpha == 0)
        {
            RestartUi();
        }
    }

    public void ReturnUi()
    {
        LeanTween.cancel(gameObject);
        LeanTween.alphaCanvas(canvasGroup, 0, 0).setEaseInOutSine();
        panelRectTransform.SetAsFirstSibling();
    }

    public void OpenUi()
    {
        //LeanTween.cancel(gameObject);
        LeanTween.alphaCanvas(canvasGroup, 1, 1).setEaseInOutSine();
        panelRectTransform.SetAsLastSibling();
    }

    public void RestartUi()
    {
        //if (overlayDisplayPositionController.isMoving)
        //{
            LeanTween.cancel(gameObject);
            CanvasGroup canvasGroupMain = MainUI.gameObject.GetComponent<CanvasGroup>();


            MainUI.gameObject.SetActive(true);
            panelRectTransformMain.SetAsLastSibling();
            LeanTween.alphaCanvas(canvasGroupMain, 1, 0).setEaseInOutSine();


            LeanTween.alphaCanvas(canvasGroup, 0, 0).setEaseInOutSine();
            OpennedUI.SetActive(false);
            panelRectTransform.SetAsFirstSibling();
        //}
    }
}
