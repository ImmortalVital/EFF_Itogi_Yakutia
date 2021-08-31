using UnityEngine;
using System.Collections;

public class FPSDisplay : MonoBehaviour
{
    float deltaTime = 0.0f;

    float minFPS = Mathf.Infinity;

    private void Start()
    {
        for (int i = 0; i < Display.displays.Length; i++) Display.displays[i].Activate();
    }

    void Update()
    {
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
    }

    void OnGUI()
    {
        int w = Screen.width, h = Screen.height;

        GUIStyle style = new GUIStyle();

        Rect rect = new Rect(0, 0, w, h * 2 / 100);

        style.alignment = TextAnchor.UpperRight;
        style.fontSize = 80;
        style.normal.textColor = new Color(1.0f, 0.0f, 0.5f, 1.0f);

        float msec = deltaTime * 1000.0f;
        float fps = 1.0f / deltaTime;

        if (Time.time > 10f)
            minFPS = Mathf.Min(minFPS, fps);

        string text = string.Format("{0:0.0} ms ({1:0.} fps, {2:0.} min)", msec, fps, minFPS);

        GUI.Label(rect, text, style);
    }
}