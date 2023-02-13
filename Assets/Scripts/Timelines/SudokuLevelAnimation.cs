using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SudokuLevelAnimation : MonoBehaviour
{
    [SerializeField] private GameObject sudokuGridBackgroundPanel;
    [SerializeField] private GameObject numberSelectionPanel;

    [SerializeField] private FieldSpawning fieldSpawner;


    private void Awake()
    {
        numberSelectionPanel.transform.localScale = new Vector3(0f, 0f, 0f);
        sudokuGridBackgroundPanel.transform.localScale = new Vector3(0f, 0f, 0f);
    }

    void Start()
    {
        SetGridPanelScaleToStart();
        SetNumberSelectionPanelScaleToStart();
    }

    private void SetGridPanelScaleToStart()
    {
        if(sudokuGridBackgroundPanel != null)
        {
            sudokuGridBackgroundPanel.LeanScale(new Vector3(1f, 1f, 1f), 0.5f).setEaseOutBack().setOnComplete(SetSudokuFieldsToStart);
        }
    }
    private void SetSudokuFieldsToStart()
    {
        fieldSpawner.CreateFields();
    }
    private void SetNumberSelectionPanelScaleToStart()
    {
        if(numberSelectionPanel != null)
        {
            numberSelectionPanel.LeanScale(new Vector3(1f, 1f, 1f), 0.5f).setEaseOutBack().setOnComplete(SetNumberFieldsToStart);
        }
    }
    private void SetNumberFieldsToStart()
    {
        fieldSpawner.CreateNumberOptionFields();
    }


    private void SetBackgroundPanelScaleToEnd()
    {
        if (sudokuGridBackgroundPanel != null)
        {
            sudokuGridBackgroundPanel.LeanScale(new Vector3(0f, 0f, 0f), 0.3f).setEaseInBack();
        }
    }
    

}