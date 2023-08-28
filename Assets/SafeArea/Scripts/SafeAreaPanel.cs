using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(RectTransform))]
public class SafeAreaPanel : MonoBehaviour
{
    [SerializeField]
    private ScreenOrientation lastScreenOrientation = ScreenOrientation.Portrait;
    private RectTransform rectTransform;
    private void OnEnable()
    {
        rectTransform = GetComponent<RectTransform>();
        SetProtrait(Screen.orientation);
    }
    public string screenOrientation;
    private void Update()
    {
        screenOrientation = Screen.orientation.ToString();
        if (rectTransform != null)
        {
            if (Screen.width > Screen.height)
            {
                if (lastScreenOrientation != Screen.orientation)
                {
                    lastScreenOrientation = Screen.orientation;
                    SeLandscape(Screen.orientation);
                }
            }
            else
            {

                if (lastScreenOrientation != Screen.orientation)
                {
                    lastScreenOrientation = Screen.orientation;
                    SetProtrait(Screen.orientation);
                }
            }
        }
    }
    void SetProtrait(ScreenOrientation orientation)
    {
        if(screenOrientation == "PortraitUpsideDown")
        {
            rectTransform.sizeDelta = new Vector2(0, -Screen.safeArea.yMin + (Screen.safeArea.height - Screen.safeArea.yMax));
            rectTransform.anchoredPosition = new Vector2(0, 0);
            rectTransform.pivot = new Vector2(0.5f, 0.5f);
        }
        if (screenOrientation == "Portrait")
        {
            rectTransform.sizeDelta = new Vector2(0, -Screen.safeArea.y);
            rectTransform.anchoredPosition = new Vector2(0, -Screen.safeArea.y / 2);
            rectTransform.pivot = new Vector2(0.5f, 0.5f);
        }
    }


    void SeLandscape(ScreenOrientation orientation)
    {
        float heightDifference = 0;
        if (screenOrientation == "LandscapeLeft")
        {
            heightDifference = (Screen.safeArea.height - Screen.safeArea.yMax);
            rectTransform.sizeDelta = new Vector2(-Screen.safeArea.xMin + (Screen.safeArea.width - Screen.safeArea.xMax), heightDifference);
            rectTransform.pivot = new Vector2(0.5f, heightDifference != 0 ? 1 : 0.5f);
            rectTransform.anchoredPosition = new Vector2(0, 0);
        }
        if (screenOrientation == "LandscapeRight")
        {
            heightDifference = (Screen.safeArea.height - Screen.safeArea.yMax);
            rectTransform.sizeDelta = new Vector2(-Screen.safeArea.xMin + (Screen.safeArea.width - Screen.safeArea.xMax), heightDifference);
            rectTransform.pivot = new Vector2(0.5f, heightDifference != 0 ? 1 : 0.5f);
            rectTransform.anchoredPosition = new Vector2(0, 0);
        }
    }
}
