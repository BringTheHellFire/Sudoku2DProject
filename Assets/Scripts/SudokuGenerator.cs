using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SudokuGenerator
{
    public static void CreateSudokuObject(out SudokuObject solutionSudokuObject, out SudokuObject puzzleSudokuObject)
    {
        SudokuObject sudokuObject = new SudokuObject();
        CreateRandomGroups(sudokuObject);
        if (TryToSolve(sudokuObject))
        {
            sudokuObject = _finalSudokuObject;
        }
        solutionSudokuObject = sudokuObject;
        puzzleSudokuObject = RemoveSomeRandomNumbers(solutionSudokuObject);
    }

    public static void CreateRandomGroups(SudokuObject sudokuObject)
    {
        List<int> values = new List<int>() { 0, 1, 2 };
        int index = UnityEngine.Random.Range(0, values.Count);
        InsertRandomGroup(sudokuObject, 1 + values[index]);
        values.RemoveAt(index);

        index = UnityEngine.Random.Range(0, values.Count);
        InsertRandomGroup(sudokuObject, 4 + values[index]);
        values.RemoveAt(index);

        index = UnityEngine.Random.Range(0, values.Count);
        InsertRandomGroup(sudokuObject, 7 + values[index]);
        values.RemoveAt(index);
    }

    private static SudokuObject RemoveSomeRandomNumbers(SudokuObject sudokuObject)
    {
        SudokuObject newSudokuObject = new SudokuObject();
        newSudokuObject.Grid = (int[,]) sudokuObject.Grid.Clone();

        List<Tuple<int,int>> values = GetValues();

        int EndValueIndex = 10;
        if (GameSettings.DifficultySetting == 1) { EndValueIndex = 71; }
        if (GameSettings.DifficultySetting == 2) { EndValueIndex = 61; }

        bool isFinish = false;

        while (!isFinish)
        {
            int index = UnityEngine.Random.Range(0, values.Count);
            var searchedIndex = values[index];

            SudokuObject nextSudokuObject = new SudokuObject();
            nextSudokuObject.Grid = (int[,])newSudokuObject.Grid.Clone();
            nextSudokuObject.Grid[searchedIndex.Item1, searchedIndex.Item2] = 0;
            if(TryToSolve(nextSudokuObject, true))
            {
                newSudokuObject = nextSudokuObject;
            }
            values.RemoveAt(index);
            if (values.Count < EndValueIndex)
            {
                isFinish = true;
            }
            
        }

        return newSudokuObject;
    }

    private static List<Tuple<int, int>> GetValues()
    {
        List<Tuple<int, int>> values = new List<Tuple<int, int>>();
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                values.Add(new Tuple<int, int>(i,j));
            }
        }
        return values;
    }

    private static SudokuObject _finalSudokuObject;

    private static bool TryToSolve(SudokuObject sudokuObject, bool OnlyOne = false)
    {
        if(HasEmptyFieldToFill(sudokuObject, out int row, out int column, OnlyOne))
        {
            List<int> possibleValues = GetPossibleValues(sudokuObject, row, column);
            foreach (var possibility in possibleValues)
            {
                SudokuObject nextSudokuObject = new SudokuObject();
                nextSudokuObject.Grid = (int[,])sudokuObject.Grid.Clone();
                nextSudokuObject.Grid[row, column] = possibility;
                if (TryToSolve(nextSudokuObject, OnlyOne))
                {
                    return true;
                }
            }
        }

        if (HasEmptyFields(sudokuObject))
        {
            return false;
        }
        _finalSudokuObject = sudokuObject;
        return true;
    }

    private static bool HasEmptyFields(SudokuObject sudokuObject)
    {
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                if (sudokuObject.Grid[i, j] == 0)
                {
                    return true;

                }
            }
        }
        return false;
    }

    private static List<int> GetPossibleValues(SudokuObject sudokuObject, int row, int column)
    {
        List<int> possiblevalues = new List<int>();
        for (int i = 1; i < 10; i++)
        {
            if(sudokuObject.IsPossibleNumberInField(i, row, column))
            {
                possiblevalues.Add(i);
            }
        }
        return possiblevalues;
    }

    private static bool HasEmptyFieldToFill(SudokuObject sudokuObject, out int row, out int column, bool OnlyOne = false)
    {
        row = 0;
        column = 0;
        int amountOfPossibleValues = 10;
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                if(sudokuObject.Grid[i,j] == 0)
                {
                    int currentAmount = GetPossibleAmountOfValues(sudokuObject, i, j);
                    if(currentAmount != 0)
                    {
                        if(currentAmount < amountOfPossibleValues)
                        {
                            amountOfPossibleValues = currentAmount;
                            row = i;
                            column = j;
                        }
                    }
                    
                }
            }
        }
        if (OnlyOne)
        {
            if(amountOfPossibleValues == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        if(amountOfPossibleValues == 10)
        {
            return false;
        }
        return true;
    }

    private static int GetPossibleAmountOfValues(SudokuObject sudokuObject, int row,int column)
    {
        int amount = 0;
        for (int value = 1; value < 10; value++)
        {
            if (sudokuObject.IsPossibleNumberInField(value, row, column))
            {
                amount++;
            }
        }
        return amount;
    }

    

    public static void InsertRandomGroup(SudokuObject sudokuObject, int group)
    {
        sudokuObject.GetGroupIndex(group, out int startRow, out int startColumn);
        List<int> values = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        for (int row = startRow; row < startRow+3; row++)
        {
            for (int column = startColumn; column < startColumn+3; column++)
            {
                int index = UnityEngine.Random.Range(0, values.Count);
                sudokuObject.Grid[row, column] = values[index];
                values.RemoveAt(index);
            }
        }
    }

}
