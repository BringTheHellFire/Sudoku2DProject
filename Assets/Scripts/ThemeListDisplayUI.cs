using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ThemeListDisplayUI : MonoBehaviour
{
    [SerializeField] private List<Theme> themes;

    [SerializeField] private GameObject themesHolder;
    [SerializeField] private GameObject themeHolder;

    [SerializeField] private PlayerInfo playerInfo;

    private List<GameObject> instancedThemes = new List<GameObject>();

    private void OnEnable()
    {
        SetThemeButtonColors();
    }

    private void Start()
    {
        SpawnThemeHolders();
    }

    private void SpawnThemeHolders()
    {
        for (int i = 0; i < themes.Count; i++)
        {
            GameObject themeInstance = Instantiate(themeHolder, themesHolder.transform);
            themeInstance.GetComponentInChildren<TextMeshProUGUI>().text = themes[i].themeName;
            themeInstance.GetComponentInChildren<TextMeshProUGUI>().color = themes[i].textColor;
            var buttonColors = themeInstance.GetComponent<Button>().colors;
            buttonColors.normalColor = themes[i].buttonColor;
            buttonColors.highlightedColor = themes[i].buttonHighlightedColor;
            buttonColors.pressedColor = themes[i].buttonPressedColor;
            buttonColors.selectedColor = themes[i].buttonSelectedColor;
            themeInstance.GetComponent<Button>().colors = buttonColors;
            int themeIndex = i;
            themeInstance.GetComponent<Button>().onClick.AddListener(() => ChangeTheme(themeIndex));
            instancedThemes.Add(themeInstance);
        }
    }
    private void SetThemeButtonColors()
    {
        for (int i = 0; i < instancedThemes.Count; i++)
        {
            instancedThemes[i].GetComponentInChildren<TextMeshProUGUI>().color = themes[i].textColor;
            var buttonColors = instancedThemes[i].GetComponent<Button>().colors;
            buttonColors.normalColor = themes[i].buttonColor;
            buttonColors.highlightedColor = themes[i].buttonHighlightedColor;
            buttonColors.pressedColor = themes[i].buttonPressedColor;
            buttonColors.selectedColor = themes[i].buttonSelectedColor;
            instancedThemes[i].GetComponent<Button>().colors = buttonColors;
        }
    }

    public static UnityEvent themeChanged = new UnityEvent();
    private void ChangeTheme(int themeIndex)
    {
        playerInfo.selectedTheme = themes[themeIndex];
        themeChanged.Invoke();
        SetThemeButtonColors();
    }

}
