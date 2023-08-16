using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeAreaScript : MonoBehaviour
{
    ScreenOrientation lastScreenOrientation = ScreenOrientation.AutoRotation;
    RectTransform rectTransform;
    private void OnEnable()
    {
        rectTransform = GetComponent<RectTransform>();
        CheckOrientation();
        SetUI();
    }
    private void Update()
    {
        if (rectTransform != null)
        {
            CheckOrientation();
        }
    }

    void CheckOrientation()
    {
        if (lastScreenOrientation != Screen.orientation)
        {
            lastScreenOrientation = Screen.orientation;
            SetUI();
        }
    }

    void SetUI()
    {
        switch (Screen.orientation)
        {
            case ScreenOrientation.Portrait:
                    var difference = (Screen.safeArea.height - Screen.safeArea.yMax);
                    rectTransform.sizeDelta = new Vector2(0, -Screen.safeArea.yMin + difference);
                    rectTransform.anchoredPosition = new Vector2(0, 0);
                rectTransform.pivot = new Vector2(0.5f, 0.5f);
                break;
            case ScreenOrientation.PortraitUpsideDown:
                    rectTransform.sizeDelta = new Vector2(0, -Screen.safeArea.y);
                    rectTransform.anchoredPosition = new Vector2(0, -Screen.safeArea.y / 2);
                rectTransform.pivot = new Vector2(0.5f, 0.5f);
                break;

            case ScreenOrientation.LandscapeLeft:
                var difference1 = (Screen.safeArea.width - Screen.safeArea.xMax);
                var heightDifference = (Screen.safeArea.height - Screen.safeArea.yMax);
                rectTransform.sizeDelta = new Vector2(-Screen.safeArea.xMin + difference1, heightDifference);
                if (heightDifference != 0)
                {
                    rectTransform.pivot = new Vector2(0.5f, 1);
                }
                else
                {
                    rectTransform.pivot = new Vector2(0.5f, 0.5f);
                }
                break;
            case ScreenOrientation.LandscapeRight:
                var difference2 = (Screen.safeArea.width - Screen.safeArea.xMax);
                var heightDifference1 = (Screen.safeArea.height - Screen.safeArea.yMax);
                rectTransform.sizeDelta = new Vector2(-Screen.safeArea.xMin + difference2, heightDifference1);
                if (heightDifference1 != 0)
                {
                    rectTransform.pivot = new Vector2(0.5f, 1);
                }
                else
                {
                    rectTransform.pivot = new Vector2(0.5f, 0.5f);
                }
                break;
        }
    }
}
