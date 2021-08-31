using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageScale : MonoBehaviour
{
    public bool check = false;
    public bool onScreen = false;
    public float deltaTime = 0.0f;
    public Vector3 defaultScale;
    public Vector3 defaultPosition;
    public Vector3 targetScale;

    public Vector3 startPosition;
    public Vector3 targetPosition;

    public bool m_Activate = true;
    public float timeLeft;

    public GameObject uiPanel;
    public CanvasGroup canvasGroup;
    public bool ui_Activate = false;

    public UnityEngine.Camera cam;

    void Start()
    {
        defaultScale = transform.localScale;
        startPosition = transform.position;
        defaultPosition.y = 1;
        cam = UnityEngine.Camera.main;

        canvasGroup = uiPanel.GetComponent<CanvasGroup>();
        //uiPanel = GameObject.Find("WindPanel");
        //uiPanel.SetActive(m_Activate);
        //Debug.Log(uiPanel.transform.localScale);
        
    }

    void Update()
    {
        Vector3 viewPos = cam.WorldToViewportPoint(defaultPosition);
        if (viewPos.x >= 0 && viewPos.x <= 1 && viewPos.y >= 0 && viewPos.y <= 1 && viewPos.z > 0)
        {
            if(!onScreen) {
                deltaTime = 0.0f;
            }
            deltaTime += 0.1f;
            
            transform.localScale = Vector3.Lerp(transform.localScale, targetScale, Time.deltaTime*deltaTime);

            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime*deltaTime);
            onScreen = true;
            
        }
        else {
            if(onScreen) {
                deltaTime = 0.0f;
            }
            deltaTime += 1;
            transform.localScale = Vector3.Lerp(transform.localScale, defaultScale, Time.deltaTime*deltaTime);

            transform.position = Vector3.Lerp(transform.position, startPosition, Time.deltaTime*deltaTime);
            onScreen = false;
        }


        

        /*if (!onScreen) {
            timeLeft = 5.0f;
            
            LeanTween.alphaCanvas(canvasGroup, 0, 0);
            uiPanel.gameObject.transform.localScale = Vector3.one/2;
            LeanTween.cancel(uiPanel);
            //uiPanel.SetActive(false);
            ui_Activate = false;

            } else {
            timeLeft -= Time.deltaTime;
            if(timeLeft < 0)
            {*/
                /*if (!uiPanel.gameObject.activeSelf) {
                    uiPanel.SetActive(true);
                }*/
                

                /*if (!ui_Activate) {
                    LeanTween.cancel(uiPanel);
                    uiPanel.gameObject.transform.localScale = Vector3.one/2;

                    LeanTween.alphaCanvas(canvasGroup, 1, 1);
                    LeanTween.scale(uiPanel, Vector3.one, 1).setEaseInOutSine();
                    ui_Activate = true;
                }*/
                


                //CanvasGroup canvasGroup = uiPanel.GetComponent<CanvasGroup>();
                //LeanTween.cancel(uiPanel);

                //LeanTween.alphaCanvas(uiPanel.canvasGroup, 1, 1);
                //LeanTween.scale(uiPanel, Vector3.one, 5).setEaseInOutSine();
            /*}
        }*/
    }

    /*private void OnGUI()
    {
        GUIStyle guiStyle = new GUIStyle();
        guiStyle.fontSize = 80;
        guiStyle.normal.textColor = new Color(1.0f, 0.0f, 0.5f, 1.0f);

        if (GUI.Button (new Rect (100f, 100f, 80f, 15f), "Нажми")) {
                        uiPanel.SetActive(false);
                }*

        if (onScreen){
            
            uiPanel = GameObject.Find("ItemPanel");
            uiPanel.SetActive(m_Activate);
            Debug.Log("CHECK");
            Debug.Log(m_Activate);

        } else {
            uiPanel = GameObject.Find("ItemPanel");
            uiPanel.SetActive(m_Activate);
            Debug.Log(m_Activate);
        }
        
    
        
    }*/

    
}
