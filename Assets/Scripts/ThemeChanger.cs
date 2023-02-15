using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ThemeChanger : MonoBehaviour
{
    [SerializeField] private PlayerInfo playerInfo;

    [SerializeField] private SpriteRenderer background;

    [SerializeField] private List<TextMeshProUGUI> textFieldsToChange = new List<TextMeshProUGUI>();

    [SerializeField] private List<Image> panelsToChange = new List<Image>();

    [SerializeField] private List<TextMeshProUGUI> panelTextFieldsToChange = new List<TextMeshProUGUI>();

    private void Awake()
    {
        ThemeListDisplayUI.themeChanged.AddListener(ChangeCurrentColorsToThemeColors);
        FieldSpawning.fieldsSpawned.AddListener(ChangeCurrentColorsToThemeColors);
    }

    private void Start()
    {
        ChangeCurrentColorsToThemeColors();
    }

    public void ChangeCurrentColorsToThemeColors()
    {
        SetAllButtonsToTheme();
        SetBackgroundColorToTheme();
        SetAllTextFieldColorsToTheme();
        SetAllPanelColorsToTheme();
        SetAllPanelTextFieldColorsToTheme();
    }
    private void SetAllButtonsToTheme()
    {
        var buttons = FindObjectsOfType<Button>();

        foreach (var button in buttons)
        {
            var buttonColors = button.colors;
            buttonColors.normalColor = playerInfo.selectedTheme.buttonColor;
            buttonColors.highlightedColor = playerInfo.selectedTheme.buttonHighlightedColor;
            buttonColors.pressedColor = playerInfo.selectedTheme.buttonPressedColor;
            buttonColors.selectedColor = playerInfo.selectedTheme.buttonSelectedColor;
            button.colors = buttonColors;
            button.gameObject.GetComponentInChildren<TextMeshProUGUI>().color = playerInfo.selectedTheme.textColor;
        }
    }
    private void SetBackgroundColorToTheme()
    {
        background.color = playerInfo.selectedTheme.backgroundColor;
    }
    private void SetAllTextFieldColorsToTheme()
    {
        foreach (var textFields in textFieldsToChange)
        {
            textFields.color = playerInfo.selectedTheme.textColor;
        }
    }
    private void SetAllPanelColorsToTheme()
    {
        foreach (var panel in panelsToChange)
        {
            panel.color = playerInfo.selectedTheme.panelBackgroundColor;
        }
    }
    private void SetAllPanelTextFieldColorsToTheme()
    {
        foreach (var textFields in panelTextFieldsToChange)
        {
            textFields.color = playerInfo.selectedTheme.panelTextColor;
        }
    }
}
