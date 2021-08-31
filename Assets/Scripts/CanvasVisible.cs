using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasVisible : MonoBehaviour
{
    // Start is called before the first frame update
    CanvasGroup canvasGroup;
    public GameObject transparentVideo;

    public float alpha = 0;
    float speed = 0;

    void Start()
    {
        canvasGroup = this.gameObject.GetComponent<CanvasGroup>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setVisibility(bool state) {
        //Debug.Log(state);
        LeanTween.cancel(gameObject);
        switch (state)
        {
            case true:
                alpha = 1;
                speed = 1f;
                transparentVideo.gameObject.transform.position = new Vector3(transparentVideo.gameObject.transform.position.x, transparentVideo.gameObject.transform.position.y, 1);
                break;
            case false:
                alpha = 0;
                speed = 0;
                transparentVideo.gameObject.transform.position = new Vector3(transparentVideo.gameObject.transform.position.x, transparentVideo.gameObject.transform.position.y, -2);
                break;
            default:
                alpha = 0;
                speed = 0;
                break;
        }

        //Debug.Log(alpha);
        LeanTween.alphaCanvas(canvasGroup, alpha, 1f).setEaseInOutSine();

        LeanTween.moveY(gameObject, transform.position.y + 200f * (state ? 1f : -1f), 1f);

        //transparentVideo.SetActive(!state);
        //Vector3 position = transparentVideo.gameObject.transform.position;

    }
}
