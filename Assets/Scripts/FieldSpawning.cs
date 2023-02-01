using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FieldSpawning : MonoBehaviour
{

    [SerializeField] private GameObject MainPanel;
    [SerializeField] private GameObject SudokuFieldPanel;
    [SerializeField] private GameObject FieldPrefab;

    [SerializeField] private GameObject NumberFieldPanel;
    [SerializeField] private GameObject NumberFieldPrefab;

    [SerializeField] private Button InformationButton;

    // Start is called before the first frame update
    void Start()
    {
        CreateFields();
        CreateNumberFields();
        CreateSudokuObject();
    }

    private SudokuObject _gameSudokuObject;
    private SudokuObject _finalSudokuObject;
    private void CreateSudokuObject()
    {
        SudokuGenerator.CreateSudokuObject(out SudokuObject finalSudokuObject, out SudokuObject gameSudokuObject);
        _gameSudokuObject = gameSudokuObject;
        _finalSudokuObject = finalSudokuObject;
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                var currentValue = _gameSudokuObject.Grid[i, j];
                if (currentValue != 0)
                {
                    SudokuField fieldObject = FieldDictionary[new Tuple<int, int>(i, j)];
                    fieldObject.SetNumber(currentValue);
                    fieldObject.IsChangable = false;
                }
            }
        }
    }

    private Dictionary<Tuple<int, int>, SudokuField> FieldDictionary = new Dictionary<Tuple<int, int>, SudokuField>();
    private void CreateFields()
    {
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                GameObject instance = Instantiate(FieldPrefab, SudokuFieldPanel.transform);

                SudokuField sudokuField = new SudokuField(instance, i, j);
                FieldDictionary.Add(new Tuple<int, int>(i, j), sudokuField);

                instance.GetComponent<Button>().onClick.AddListener(() => FieldOnCLick(sudokuField));

            }
        }
    }

    private void CreateNumberFields()
    {
        for (int i = 0; i < 9; i++)
        {
            GameObject instance = Instantiate(NumberFieldPrefab, NumberFieldPanel.transform);
            instance.GetComponentInChildren<TMP_Text>().text = (i + 1).ToString();
            NumberField numberField = new NumberField();
            numberField.number = i + 1;

            instance.GetComponent<Button>().onClick.AddListener(() => NumberFieldOnCLick(numberField));
        }
    }

    private void NumberFieldOnCLick(NumberField numberField)
    {
        Debug.Log("Number to place: " + numberField.number);
        if(currentSelectedField != null)
        {
            currentSelectedField.SetNumber(numberField.number);
            /*
            if (currentSudokuObject.IsPossibleNumberInField(numberField.number, currentSelectedField.Row, currentSelectedField.Column))
            {
                currentSelectedField.SetNumber(numberField.number);
            }*/
        }
    }

    private SudokuField currentSelectedField;
    private void FieldOnCLick(SudokuField selectedField) {

        Debug.Log("Selected field: " + selectedField.Row + ", " + selectedField.Column);
        if (selectedField.IsChangable)
        {
            if (currentSelectedField != null)
            {
                currentSelectedField.UnsetHoverMode();
            }
            currentSelectedField = selectedField;
            selectedField.SetHoverMode();
        }
    }

    private bool IsInformationButtonActive = false;
    public void InformationButtonOnClick()
    {
        if (IsInformationButtonActive)
        {
            IsInformationButtonActive = false;
            InformationButton.GetComponent<Image>().color = new Color(1f, 1f, 1f);
        }
        else
        {
            IsInformationButtonActive = true;
            InformationButton.GetComponent<Image>().color = new Color(0.70f, 0.99f, 0.99f);
        }
    }

    public void BackButton_ClickOn()
    {
        SceneManager.LoadScene("LevelSelection");
    }

    public void CheckButon_ClickOn()
    {
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                SudokuField sudokuField = FieldDictionary[new Tuple<int, int>(i, j)];

                if (sudokuField.IsChangable)
                {
                    Debug.Log("Sudoku Field " + "[" + i + ", " + j + "]" + ": " + sudokuField.GetNumber());
                    if(_finalSudokuObject.Grid[i,j] == sudokuField.GetNumber())
                    {
                        sudokuField.SetColorToGreen();
                    }
                    else
                    {
                        sudokuField.SetColorToRed();
                    }
                }

            }
        }
    }

}
