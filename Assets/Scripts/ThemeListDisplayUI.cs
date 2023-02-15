using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ThemeListDisplayUI : MonoBehaviour
{
    [SerializeField] private List<Theme> themes;

    [SerializeField] private GameObject themesHolder;
    [SerializeField] private GameObject themeHolder;

    private void Start()
    {
        foreach (var theme in themes)
        {
            GameObject themeInstance = Instantiate(themeHolder, themesHolder.transform);
            themeInstance.GetComponentInChildren<TextMeshProUGUI>().text = theme.themeName;
            themeInstance.GetComponentInChildren<TextMeshProUGUI>().color = theme.textColor;
            themeInstance.LeanScale(new Vector3(1f, 1f, 1f), 0.4f).setDelay(0.3f).setEaseOutQuart();
        }
    }
}
