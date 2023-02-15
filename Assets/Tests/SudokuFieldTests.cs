using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;
using TMPro;

public class SudokuFieldTests
{
    private SudokuField sudokuField;
    private GameObject fieldObject;
    private Image fieldImage;
    private TMP_Text fieldText;

    [SetUp]
    public void Setup()
    {
        fieldObject = new GameObject();
        fieldImage = fieldObject.AddComponent<Image>();
        sudokuField = new SudokuField(fieldObject, 0, 0);
    }

    [Test]
    public void SetHoverMode_ChangesFieldColorToGray()
    {
        // Arrange
        // Act
        sudokuField.SetHoverMode();
        // Assert
        Assert.AreEqual(new Color(0.4f, 0.4f, 0.4f), fieldImage.color);
        Debug.Log("Succesfully set to hover mode.");
    }

    [Test]
    public void UnsetHoverMode_ChangesFieldColorToBlack()
    {
        sudokuField.UnsetHoverMode();
        Assert.AreEqual(new Color(0f, 0f, 0f), fieldImage.color);
    }

    [UnityTest]
    public IEnumerator SetNumber_ChangesFieldTextToNumber()
    {
        // Arrange
        fieldText = fieldObject.AddComponent<TextMeshProUGUI>();
        int number = 5;
        // Act
        sudokuField.SetNumber(number);
        yield return null;
        // Assert
        Assert.AreEqual(number.ToString(), fieldText.text, "The number of the field isn't set properly!");
    }
}
