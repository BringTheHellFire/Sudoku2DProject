using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Theme", menuName = "ScriptableObjects/Theme", order = 1)]
public class Theme : ScriptableObject
{
    public string themeName;

    public Color backgroundColor;
    public Color panelBackgroundColor;

    public Color textColor;
    public Color panelTextColor;

    public Color buttonColor;
    public Color buttonHighlightedColor;
    public Color buttonPressedColor;
    public Color buttonSelectedColor;
}
