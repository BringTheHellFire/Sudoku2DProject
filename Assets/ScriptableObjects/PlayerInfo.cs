using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerInfo", menuName = "ScriptableObjects/PlayerInfo", order = 1)]
public class PlayerInfo : ScriptableObject
{
    public int coinAmount = 0;

    public Theme selectedTheme;

    public int fieldPowerUpAmount = 0;
    public int rowPowerUpAmount = 0;
    public int columnPowerUpAmount = 0;
}
