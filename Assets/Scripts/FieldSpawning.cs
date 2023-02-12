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

    [SerializeField] private List<Button> fieldButtons;
    private Dictionary<Tuple<int, int>, SudokuField> FieldDictionary = new Dictionary<Tuple<int, int>, SudokuField>();
    private SudokuObject _puzzleSudokuGrid;
    private SudokuObject _solutionSudokuGrid;

    void Start()
    {
        CreateFields();
        CreateNumberOptionFields();

        CreateSudokuObject();
    }

    private void CreateFields()
    {
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                SudokuField sudokuField = new SudokuField(fieldButtons[i * 9 + j].gameObject, i, j);
                FieldDictionary.Add(new Tuple<int, int>(i, j), sudokuField);

                fieldButtons[i*9+j].GetComponent<Button>().onClick.AddListener(() => FieldOnCLick(sudokuField));


            }
        }
    }
    private void CreateNumberOptionFields()
    {
        for (int i = 1; i < 10; i++)
        {
            GameObject instance = Instantiate(NumberFieldPrefab, NumberFieldPanel.transform);
            instance.GetComponentInChildren<TMP_Text>().text = (i).ToString();
            int numberOption = i;
            instance.GetComponent<Button>().onClick.AddListener(() => NumberFieldOnClick(numberOption));
        }
    }


    private void CreateSudokuObject()
    {
        SudokuGenerator.CreateSudokuObject(out SudokuObject finalSudokuObject, out SudokuObject gameSudokuObject);
        _puzzleSudokuGrid = gameSudokuObject;
        _solutionSudokuGrid = finalSudokuObject;
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                var currentValue = _puzzleSudokuGrid.Grid[i, j];
                if (currentValue != 0)
                {
                    SudokuField fieldObject = FieldDictionary[new Tuple<int, int>(i, j)];
                    fieldObject.SetNumber(currentValue);
                    fieldObject.IsChangable = false;
                }
            }
        }
    }

    
    

    

    private void NumberFieldOnClick(int number)
    {
        Debug.Log("Number to place: " + number);
        if(currentSelectedField != null)
        {
            currentSelectedField.SetNumber(number);
            /*
            if (currentSudokuObject.IsPossibleNumberInField(numberField.number, currentSelectedField.Row, currentSelectedField.Column))
            {
                currentSelectedField.SetNumber(numberField.number);
            }*/
        }
    }

    private SudokuField currentSelectedField;
    private void FieldOnCLick(SudokuField selectedField) 
    {
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
        SceneManager.LoadScene("MainMenuScene");
    }

    public void CheckButon_ClickOn()
    {
        if (HasWrongOrEmptyField())
        {
            Debug.Log("The board has empty or wrong fields!");
        }
        else
        {
            Debug.Log("Level completed!");
        }
        
    }

    private bool HasWrongOrEmptyField()
    {
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                SudokuField sudokuField = FieldDictionary[new Tuple<int, int>(i, j)];

                if (sudokuField.IsChangable)
                {
                    if (_solutionSudokuGrid.Grid[i, j] != sudokuField.GetNumber())
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }
}
