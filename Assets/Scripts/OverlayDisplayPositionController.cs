using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OverlayDisplayPositionController : MonoBehaviour {

    public float sensivity = 4f;

    public float targetX = 0;

    public float controllerRotation = 0f;
    public float lastRotation = 999999f;

    public float leftSideRotation;

    public float backgroundWidth;
    public float cameraMoveLimit;
    public float screenWidth;

    public float scaleObjects;

    public UnityEvent onMoveStart;
    public UnityEvent onMoveStop;

    void Start()
    {
        for (int i = 0; i < Display.displays.Length; i++) Display.displays[i].Activate();
        cameraMoveLimit = backgroundWidth / 2f - screenWidth / 2;

        StartCoroutine(UpdateStatus());
    }


    float prevPosition;
    public bool isMoving = false;

    private IEnumerator UpdateStatus()
    {
        while (true) {
            yield return new WaitForSeconds(1f);

            if (prevPosition != controllerRotation && !isMoving)
            {
                //Debug.Log("STARTS MOVING");
                onMoveStart.Invoke();
                isMoving = true;
            }
            else if (prevPosition == controllerRotation && isMoving)
            {
                //Debug.Log("STOPS MOVING");
                onMoveStop.Invoke();
                isMoving = false;
            }

            prevPosition = controllerRotation;
        }
    }

    public void SetRotation(string rotation) {
        try {
            controllerRotation = int.Parse(rotation);
        } catch (Exception e) {}
    }

    void Update ()
    {
        controllerRotation += Input.mouseScrollDelta.y * 10;

        if (lastRotation == 999999)
            lastRotation = controllerRotation;
        
        float deltaRotation = lastRotation - controllerRotation;

        targetX += deltaRotation * sensivity;

        if (targetX < -cameraMoveLimit) targetX = -cameraMoveLimit;
        if (targetX >  cameraMoveLimit) targetX = cameraMoveLimit;

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            targetX = -cameraMoveLimit;
            leftSideRotation = controllerRotation;
        }

        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            targetX = cameraMoveLimit;
            sensivity = -1f * Mathf.Abs( backgroundWidth / (controllerRotation - leftSideRotation) );
        }

        Vector3 targetPosition = new Vector3(targetX, transform.position.y, transform.position.z);

        transform.position = targetPosition;
//        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * 150f);

        lastRotation = controllerRotation;
    }

    /*private void OnGUI()
    {
        GUIStyle guiStyle = new GUIStyle();
        guiStyle.fontSize = 80;

        guiStyle.normal.textColor = new Color(1.0f, 0.0f, 0.5f, 1.0f);
        
        sensivity = float.Parse(GUILayout.TextField(sensivity.ToString(), guiStyle));

        GUILayout.Label(transform.position.ToString(), guiStyle);
    }*/
}
