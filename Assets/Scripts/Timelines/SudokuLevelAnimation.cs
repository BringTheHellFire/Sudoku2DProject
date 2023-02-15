using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;


public class SudokuLevelAnimation : MonoBehaviour
{
    

    [SerializeField] private GameObject sudokuGridBackgroundPanel;
    [SerializeField] private GameObject numberSelectionPanel;
    [SerializeField] private GameObject powerUpPanel;

    [SerializeField] private GameObject victoryScreenPanel;
    [SerializeField] private GameObject exitScreenPanel;

    [SerializeField] private GameObject backButton;
    [SerializeField] private GameObject coinAmountDisplay;

    [SerializeField] private FieldSpawning fieldSpawner;


    private void Awake()
    {
        sudokuGridBackgroundPanel.GetComponent<RectTransform>().localPosition = new Vector3(900f, 150f, 0f);
        numberSelectionPanel.GetComponent<RectTransform>().localPosition = new Vector3(-900f, -350f, 0f);
        backButton.transform.localScale = new Vector3(0f, 0f, 0f);
        coinAmountDisplay.transform.localScale = new Vector3(0f, 0f, 0f);
        powerUpPanel.transform.localScale = new Vector3(0f, 0f, 0f);
        fieldSpawner.gridIsFilled.AddListener(VictoryPanelAnimationStart);
    }

    void Start()
    {
        SetGridPanelPositionToStart();
        SetNumberSelectionPanelPositionToStart();
        SetBackButtonToStart();
        SetCoinAmountDisplayToStart();
        SetPowerUpDisplayToStart();
    }

    private void SetGridPanelPositionToStart()
    {
        if (sudokuGridBackgroundPanel != null)
        {
            sudokuGridBackgroundPanel.GetComponent<RectTransform>().LeanMoveX(0f, 0.7f).setDelay(0.2f).setEaseOutBack().setOnComplete(SetSudokuFieldsToStart);
        }
    }
    private void SetSudokuFieldsToStart()
    {
        fieldSpawner.CreateFields();
    }
    private void SetNumberSelectionPanelPositionToStart()
    {
        if (numberSelectionPanel != null)
        {
            numberSelectionPanel.GetComponent<RectTransform>().LeanMoveX(0f, 0.7f).setDelay(0.2f).setEaseOutBack().setOnComplete(SetNumberFieldsToStart);
        }
    }
    private void SetNumberFieldsToStart()
    {
        fieldSpawner.CreateNumberOptionFields();
    }
    private void SetBackButtonToStart()
    {
        backButton.LeanScale(new Vector3(1f, 1f, 1f), 0.5f).setDelay(1f).setEaseOutBack();
    }
    private void SetCoinAmountDisplayToStart()
    {
        coinAmountDisplay.LeanScale(new Vector3(1f, 1f, 1f), 0.5f).setDelay(1.2f).setEaseOutBack();
    }
    private void SetPowerUpDisplayToStart()
    {
        powerUpPanel.LeanScale(new Vector3(1f, 1f, 1f), 0.5f).setDelay(1.2f).setEaseOutBack();
    }

    public void BackButton_OnClick()
    {
        SetBackgroundPanelScaleToEnd();
        SetNumberSelectionPanelToEnd();
        ExitPanelAnimationStart();
        backButton.LeanScale(new Vector3(0f, 0f, 0f), 0.5f).setEaseInBack();
        coinAmountDisplay.LeanScale(new Vector3(0f, 0f, 0f), 0.5f).setEaseInBack();
        powerUpPanel.LeanScale(new Vector3(0f, 0f, 0f), 0.5f).setEaseInBack();
    }
    private void LoadMainMenuScene()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
    private void LoadLevelScene()
    {
        SceneManager.LoadScene("SudokuLevel");
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

    private void VictoryPanelAnimationStart()
    {
        SetBackgroundPanelScaleToEnd();
        SetNumberSelectionPanelToEnd();
        backButton.LeanScale(new Vector3(0f, 0f, 0f), 0.5f).setEaseInBack();
        victoryScreenPanel.GetComponent<RectTransform>().LeanMoveX(0f, 0.5f).setDelay(0.5f).setEaseOutQuart();
    }
    private void VictoryPanelAnimationEnd()
    {
        victoryScreenPanel.GetComponent<RectTransform>().LeanMoveX(900f, 0.5f).setEaseInQuart();
    }

    private void ExitPanelAnimationStart()
    {
        exitScreenPanel.GetComponent<RectTransform>().LeanMoveX(0f, 0.5f).setDelay(0.5f).setEaseOutQuart();
    }
    private void ExitPanelAnimationEnd()
    {
        exitScreenPanel.GetComponent<RectTransform>().LeanMoveX(-900f, 0.5f).setEaseInQuart();
    }
    
    public void ResumeButton_OnClick()
    {
        ExitPanelAnimationEnd();
        sudokuGridBackgroundPanel.GetComponent<RectTransform>().LeanMoveX(0f, 0.5f).setDelay(0.5f).setEaseOutBack();
        numberSelectionPanel.GetComponent<RectTransform>().LeanMoveX(0f, 0.5f).setDelay(0.5f).setEaseOutBack();
        SetBackButtonToStart();
        SetCoinAmountDisplayToStart();
        SetPowerUpDisplayToStart();
    }

    public void ExitButton_OnClick()
    {
        exitScreenPanel.GetComponent<RectTransform>().LeanMoveX(-900f, 0.5f).setEaseInQuart().setOnComplete(LoadMainMenuScene);
    }

    public void PlayAgainButton_OnClick()
    {
        victoryScreenPanel.GetComponent<RectTransform>().LeanMoveX(900f, 0.5f).setEaseInQuart().setOnComplete(LoadLevelScene);
    }

    public void MainMenuButton_OnClick()
    {
        victoryScreenPanel.GetComponent<RectTransform>().LeanMoveX(-900f, 0.5f).setEaseInQuart().setOnComplete(LoadMainMenuScene);
    }

}
