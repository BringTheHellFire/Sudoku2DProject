using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DifficultySelector : MonoBehaviour
{
    [SerializeField] private Button EasyButton;
    [SerializeField] private Button MediumButton;
    [SerializeField] private Button HardButton;

    public void EasyMode_ClickOn()
    {
        SceneManager.LoadScene("SudokuLevel");
        GameSettings.DifficultySetting = 1;
    }

    public void MediumMode_ClickOn()
    {
        SceneManager.LoadScene("SudokuLevel");
        GameSettings.DifficultySetting = 2;
    }

    public void HardMode_ClickOn()
    {
        SceneManager.LoadScene("SudokuLevel");
        GameSettings.DifficultySetting = 3;
    }
}
