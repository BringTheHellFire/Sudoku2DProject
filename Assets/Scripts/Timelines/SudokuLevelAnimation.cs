using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;


public class SudokuLevelAnimation : MonoBehaviour
{
    [SerializeField] private GameObject sudokuGridBackgroundPanel;
    [SerializeField] private GameObject numberSelectionPanel;

    [SerializeField] private GameObject backButton;

    [SerializeField] private FieldSpawning fieldSpawner;


    private void Awake()
    {
        backButton.transform.localScale = new Vector3(0f, 0f, 0f);
        fieldSpawner.gridIsFilled.AddListener(BackButton_OnClick);
    }

    void Start()
    {
        SetGridPanelPositionToStart();
        SetNumberSelectionPanelPositionToStart();
        SetBackButtonToStart();
    }

    private void SetGridPanelPositionToStart()
    {
        if(sudokuGridBackgroundPanel != null)
        {
            sudokuGridBackgroundPanel.GetComponent<RectTransform>().LeanMoveX(0f, 0.5f).setEaseOutBack().setOnComplete(SetSudokuFieldsToStart);
        }
    }
    private void SetSudokuFieldsToStart()
    {
        fieldSpawner.CreateFields();
    }
    private void SetNumberSelectionPanelPositionToStart()
    {
        if(numberSelectionPanel != null)
        {
            numberSelectionPanel.GetComponent<RectTransform>().LeanMoveX(0f, 0.5f).setEaseOutBack().setOnComplete(SetNumberFieldsToStart);
        }
    }
    private void SetNumberFieldsToStart()
    {
        fieldSpawner.CreateNumberOptionFields();
    }
    private void SetBackButtonToStart()
    {
        backButton.LeanScale(new Vector3(1f, 1f, 1f), 0.5f).setDelay(0.3f).setEaseOutBack();
    }

    public void BackButton_OnClick()
    {
        SetBackgroundPanelScaleToEnd();
        SetNumberSelectionPanelToEnd();
        backButton.LeanScale(new Vector3(0f, 0f, 0f), 0.5f).setEaseInBack().setOnComplete(LoadMainMenuScene);
    }
    private void LoadMainMenuScene()
    {
        SceneManager.LoadScene("MainMenuScene");
    }

    private void SetBackgroundPanelScaleToEnd()
    {
        if (sudokuGridBackgroundPanel != null)
        {
            sudokuGridBackgroundPanel.GetComponent<RectTransform>().LeanMoveX(900f, 0.5f).setEaseInBack();
        }
    }
    private void SetNumberSelectionPanelToEnd()
    {
        if (numberSelectionPanel != null)
        {
            numberSelectionPanel.GetComponent<RectTransform>().LeanMoveX(-900f, 0.5f).setEaseInBack();
        }
    }
    

}
