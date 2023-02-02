using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeanTweenTest : MonoBehaviour
{
    [SerializeField] private GameObject levelSelectionPanel;
    [SerializeField] private float buttonMovementTime = 0.5f;

    public void ButtonReact_OnClick()
    {
        transform.LeanScale(new Vector3(1.2f, 1.2f, 0f), buttonMovementTime).setEaseInQuart().setLoopPingPong(1).setOnComplete(TriggerLevelSelection);

    }

    private void TriggerLevelSelection()
    {
        levelSelectionPanel.SetActive(true);
        levelSelectionPanel.LeanScale(new Vector3(1f, 1f, 1f), buttonMovementTime).setEaseInExpo();
    }

}
