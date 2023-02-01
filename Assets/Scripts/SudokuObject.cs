using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SudokuObject
{
    public int[,] Grid = new int[9, 9];

    public void GetGroupIndex(int group, out int startRow, out int startColumn)
    {
        startRow = 0;
        startColumn = 0;

        switch (group)
        {
            case 1:
                startRow = 0;
                startColumn = 0;
                break;
            case 2:
                startRow = 0;
                startColumn = 3;
                break;
            case 3:
                startRow = 0;
                startColumn = 6;
                break;
            case 4:
                startRow = 3;
                startColumn = 0;
                break;
            case 5:
                startRow = 3;
                startColumn = 3;
                break;
            case 6:
                startRow = 3;
                startColumn = 6;
                break;
            case 7:
                startRow = 6;
                startColumn = 0;
                break;
            case 8:
                startRow = 6;
                startColumn = 3;
                break;
            case 9:
                startRow = 6;
                startColumn = 6;
                break;
        }
    }

    public bool IsPossibleNumberInField(int number, int row, int column)
    {
        if(IsPossibleNumberInRow(number, row) && IsPossibleNumberInColumn(number, column))
        {
            if (IsPossibleNumberInGroup(number, GetGroup(row, column)))
            {
                return true;
            }
        }
        return false;
    }

    private int GetGroup(int row, int column)
    {
        if(row < 3)
        {
            if(column < 3) { return 1; }
            else if (column < 6) { return 2; }
            else { return 3; }
        }
        else if(row < 6)
        {
            if (column < 3) { return 4; }
            else if (column < 6) { return 5; }
            else { return 6; }
        }
        else
        {
            if (column < 3) { return 7; }
            else if (column < 6) { return 8; }
            else { return 9; }
        }
    }

    private bool IsPossibleNumberInRow(int number, int row)
    {
        for (int i = 0; i < 9; i++)
        {
            if(Grid[row, i] == number)
            {
                return false;
            }
        }
        return true;
    }

    private bool IsPossibleNumberInColumn(int number, int column)
    {
        for (int i = 0; i < 9; i++)
        {
            if (Grid[i, column] == number)
            {
                return false;
            }
        }
        return true;
    }

    private bool IsPossibleNumberInGroup(int number, int group)
    {
        GetGroupIndex(group, out int startRow, out int startColumn);
        for (int row = startRow; row < startRow+3; row++)
        {
            for (int column = startColumn; column < startColumn+3; column++)
            {
                if(Grid[row, column] == number)
                {
                    return false;
                }
            }
        }
        return true;
    }

}
