using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DifficultySelector : MonoBehaviour
{
    [SerializeField] private string sceneName;
    [SerializeField] private int difficulty;

    public void SelectDifficulty_OnClick()
    {
        GameSettings.DifficultySetting = difficulty;
        SceneManager.LoadScene(sceneName);
    }
}
