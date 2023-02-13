using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SudokuField
{
    private int row;
    private int column;

    private int _number;

    private GameObject instance;

    public bool IsChangable = true;

    public GameObject GetInstance()
    {
        return instance;
    }

    public SudokuField(GameObject _instance, int _row, int _column)
    {
        instance = _instance;
        Row = _row;
        Column = _column;
    }

    public int Row { get => row; set => row = value; }
    public int Column { get => column; set => column = value; }

    public void SetHoverMode()
    {
        instance.GetComponent<Image>().color = new Color(0.4f, 0.4f, 0.4f);
    }

    public void UnsetHoverMode()
    {
        instance.GetComponent<Image>().color = new Color(0f, 0f, 0f);
    }

    public int GetNumber()
    {
        return _number;
    }

    public void SetNumber(int number)
    {
        instance.GetComponentInChildren<TMP_Text>().text = number.ToString();
        _number = number;
    }

    public void SetColorToGreen()
    {
        instance.GetComponent<Image>().color = Color.green;
    }
    public void SetColorToRed()
    {
        instance.GetComponent<Image>().color = Color.red;
    }
}
