using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryRewardManager : MonoBehaviour
{
    [SerializeField] private FieldSpawning fieldSpawner;

    [SerializeField] private PlayerInfo playerInfo;

    [SerializeField] private int rewardAmount = 0;

    private void Awake()
    {
        fieldSpawner.gridIsFilled.AddListener(GiveVictoryReward);
    }

    private void GiveVictoryReward()
    {
        playerInfo.coinAmount += rewardAmount * LevelSettings.difficultySetting;
    }

}
