using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerInfoUI : MonoBehaviour
{
    [SerializeField] private PlayerInfo playerInfo;

    [SerializeField] private TextMeshProUGUI coinAmountTextField;

    private void Start()
    {
        coinAmountTextField.text = playerInfo.coinAmount.ToString();
    }

}
