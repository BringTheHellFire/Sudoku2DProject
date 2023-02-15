using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RewardManager : MonoBehaviour
{
    [SerializeField] private FieldSpawning fieldSpawner;

    [SerializeField] private PlayerInfo playerInfo;

    [SerializeField] private int rewardAmount = 0;

    [SerializeField] private TextMeshProUGUI rewardMessage;

    private void Awake()
    {
        fieldSpawner.gridIsFilled.AddListener(GiveVictoryReward);
    }

    private void GiveVictoryReward()
    {
        playerInfo.coinAmount += rewardAmount * LevelSettings.difficultySetting;
        int powerUp = UnityEngine.Random.Range(1, 3);
        switch (powerUp)
        {
            case 1:
                playerInfo.fieldPowerUpAmount += 1;
                break;
            case 2:
                playerInfo.rowPowerUpAmount += 1;
                break;
            case 3:
                playerInfo.rowPowerUpAmount += 1;
                break;
        }
        SetDisplayMessage(rewardAmount * LevelSettings.difficultySetting, powerUp);
    }

    private void SetDisplayMessage(int amountOfCoins, int powerUpIndex)
    {
        rewardMessage.text = "You won: " + amountOfCoins + ".";
        string powerUpName = "";
        switch (powerUpIndex)
        {
            case 1:
                powerUpName = "Fill one field";
                break;
            case 2:
                powerUpName = "Fill one row";
                break;
            case 3:
                powerUpName = "Fill one column";
                break;
        }
        rewardMessage.text += "\nAnd a power up: " + powerUpName + ".";
    }

}
