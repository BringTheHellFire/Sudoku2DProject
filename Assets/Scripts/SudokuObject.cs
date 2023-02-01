using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SudokuObject
{
    public int[,] Grid = new int[9, 9];

    public void GroupToCoords(int group, out int startRow, out int startColumn)
    {
        startRow = ((group-1)/3)*3;
        startColumn = ((group - 1) % 3)*3;
    }
    private int CoordsToGroup(int row, int column)
    {
        return (row / 3)*3 + (int)Mathf.Ceil((column+1) / 3f);
    }

    public bool IsPossibleNumberInField(int number, int row, int column)
    {
        if(IsPossibleNumberInRow(number, row) && IsPossibleNumberInColumn(number, column))
        {
            if (IsPossibleNumberInGroup(number, CoordsToGroup(row, column)))
            {
                return true;
            }
        }
        return false;
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
        GroupToCoords(group, out int startRow, out int startColumn);
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
