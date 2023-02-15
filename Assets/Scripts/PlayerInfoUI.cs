using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerInfoUI : MonoBehaviour
{
    [SerializeField] private PlayerInfo playerInfo;

    [SerializeField] private TextMeshProUGUI coinAmountTextField;

    [SerializeField] private TextMeshProUGUI fieldPowerUpTextField;
    [SerializeField] private TextMeshProUGUI rowPowerUpTextField;
    [SerializeField] private TextMeshProUGUI columnPowerUpTextField;

    private void Awake()
    {
        FieldSpawning.powerUpUsed.AddListener(SetPowerUpText);
        FieldSpawning.moneyUsed.AddListener(SetCoinAmountText);
    }

    private void Start()
    {
        SetCoinAmountText();
        SetFieldPowerUpText();
        SetRowPowerUpText();
        SetColumnPowerUpText();
    }

    public void SetCoinAmountText()
    {
        coinAmountTextField.text = playerInfo.coinAmount.ToString();
    }

    public void SetPowerUpText()
    {
        SetFieldPowerUpText();
        SetRowPowerUpText();
        SetColumnPowerUpText();
    }

    public void SetFieldPowerUpText()
    {
        fieldPowerUpTextField.text = playerInfo.fieldPowerUpAmount.ToString();
    }
    public void SetRowPowerUpText()
    {
        rowPowerUpTextField.text = playerInfo.rowPowerUpAmount.ToString();
    }
    public void SetColumnPowerUpText()
    {
        columnPowerUpTextField.text = playerInfo.columnPowerUpAmount.ToString();
    }

}
