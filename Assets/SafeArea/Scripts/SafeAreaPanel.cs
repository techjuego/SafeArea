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
        CheckOrientation();
        SetSafeArea(Screen.orientation);
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
            SetSafeArea(Screen.orientation);
        }
    }

  
    void SetSafeArea(ScreenOrientation orientation)
    {
        float heightDifference = 0;
        switch (orientation)
        {
            case ScreenOrientation.Portrait:
                Debug.Log("1" + orientation);
                rectTransform.sizeDelta = new Vector2(0, -Screen.safeArea.yMin + (Screen.safeArea.height - Screen.safeArea.yMax));
                rectTransform.anchoredPosition = new Vector2(0, 0);
                rectTransform.pivot = new Vector2(0.5f, 0.5f);
                break;
            case ScreenOrientation.PortraitUpsideDown:
                Debug.Log("2" + orientation);
                rectTransform.sizeDelta = new Vector2(0, -Screen.safeArea.y);
                rectTransform.anchoredPosition = new Vector2(0, -Screen.safeArea.y / 2);
                rectTransform.pivot = new Vector2(0.5f, 0.5f);
                break;
            case ScreenOrientation.LandscapeLeft:
                Debug.Log("3" + orientation);
                heightDifference = (Screen.safeArea.height - Screen.safeArea.yMax);
                rectTransform.sizeDelta = new Vector2(-Screen.safeArea.xMin + (Screen.safeArea.width - Screen.safeArea.xMax), heightDifference);
                rectTransform.pivot = new Vector2(0.5f, heightDifference !=0? 1:0.5f);
                rectTransform.anchoredPosition = new Vector2(0, 0);
                break;
            case ScreenOrientation.LandscapeRight:
                Debug.Log("4" + orientation);
                heightDifference = (Screen.safeArea.height - Screen.safeArea.yMax);
                rectTransform.sizeDelta = new Vector2(-Screen.safeArea.xMin + (Screen.safeArea.width - Screen.safeArea.xMax), heightDifference);
                rectTransform.pivot = new Vector2(0.5f, heightDifference != 0 ? 1 : 0.5f);
                rectTransform.anchoredPosition = new Vector2(0, 0);
                break;
        }
    }
}
