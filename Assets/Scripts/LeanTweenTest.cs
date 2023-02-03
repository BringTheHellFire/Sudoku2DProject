using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeanTweenTest : MonoBehaviour
{
    [SerializeField] private GameObject levelSelectionPanel;
    [SerializeField] private float buttonMovementTime = 0.5f;

    [SerializeField] private GameObject decorations;

    [SerializeField] private GameObject backButton;
    [SerializeField] private GameObject playButton;

    public void ButtonReact_OnClick()
    {
        playButton.LeanScale(new Vector3(0f, 0f, 0f), buttonMovementTime).setEaseOutQuart().setOnStart(MoveDownDecoration);
        //transform.LeanScale(new Vector3(1.2f, 1.2f, 0f), buttonMovementTime).setEaseInQuart().setLoopPingPong(1).setOnComplete(TriggerLevelSelection);
    }

    public void BackButton_OnClick()
    {
        playButton.LeanScale(new Vector3(1f, 1f, 1f), buttonMovementTime).setEaseOutQuart().setOnStart(MoveUpDecoration);
    }

    private void MoveDownDecoration()
    {
        decorations.transform.LeanMoveLocal(new Vector2(0f, -701f), buttonMovementTime).setEaseOutQuart().setOnComplete(EnableBackButton);
    }
    private void MoveUpDecoration()
    {
        decorations.transform.LeanMoveLocal(new Vector2(0f, 800f), buttonMovementTime).setEaseOutQuart().setOnStart(DisableBackButton);
    }

    private void EnableBackButton()
    {
        backButton.LeanScale(new Vector3(1f, 1f, 1f), buttonMovementTime).setEaseOutQuart();
    }
    private void DisableBackButton()
    {
        backButton.LeanScale(new Vector3(0f, 0f, 0f), buttonMovementTime).setEaseOutQuart();
    }

    private void TriggerLevelSelection()
    {
        levelSelectionPanel.SetActive(true);
        levelSelectionPanel.LeanScale(new Vector3(1f, 1f, 1f), buttonMovementTime).setEaseInExpo();
    }

}
