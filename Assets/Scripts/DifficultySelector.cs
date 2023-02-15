using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DifficultySelector : MonoBehaviour
{
    [SerializeField] private string sceneName;
    [SerializeField] private int difficulty;

    [SerializeField] private GameObject difficultySelectionPanel;

    public void DifficultyButton_OnClick()
    {
        difficultySelectionPanel.GetComponent<RectTransform>().LeanMoveX(900f, 0.2f).setEaseInBack().setOnComplete(SelectDifficulty);
    }

    public void SelectDifficulty()
    {

        LevelSettings.difficultySetting = difficulty;
        SceneManager.LoadScene(sceneName);
    }
}
