using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class MainMenuAnimation : MonoBehaviour
{

    [SerializeField] private GameObject title;
    [SerializeField] private GameObject playButton;

    [SerializeField] private ParticleSystem theParticleSystem;

    [SerializeField] private GameObject leftCloud;
    [SerializeField] private GameObject rightCloud;

    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject difficultySelectionPanel;
    [SerializeField] private List<GameObject> buttonsToScale;

    private void Start()
    {
        MoveLeftCloudToStartPosition();
    }

    private void MoveLeftCloudToStartPosition()
    {
        if (leftCloud != null)
        {
            leftCloud.GetComponent<RectTransform>().LeanMoveX(300f, 0.5f).setDelay(0.1f).setEaseOutBack().setOnStart(MoveRightCloudToStartPosition);
        }
    }
    private void MoveRightCloudToStartPosition()
    {
        if (rightCloud != null)
        {
            rightCloud.GetComponent<RectTransform>().LeanMoveX(400f, 0.5f).setDelay(0.3f).setEaseOutBack().setOnComplete(SetTitleScaleToStartScale);
        }
    }
    private void SetTitleScaleToStartScale()
    {
        if (title != null)
        {
            title.LeanScale(new Vector3(1f, 1f, 1f), 0.3f).setEaseOutQuart().setOnStart(SetPlayButtonScaleToStartScale);
        }
    }
    private void SetPlayButtonScaleToStartScale()
    {
        if (playButton != null)
        {
            playButton.LeanScale(new Vector3(1f, 1f, 1f), 0.3f).setDelay(0.3f).setEaseOutBounce();
        }
    }

    public void StartButton_OnClick()
    {
        MoveMainMenuPanelLeft();
        MoveDifficultySelectionPanelLeft();
    }
    private void MoveMainMenuPanelLeft()
    {
        if (mainMenuPanel != null)
        {
            mainMenuPanel.GetComponent<RectTransform>().LeanMoveX(-900f, 0.2f).setEaseInBack();
        }
    }
    private void MoveDifficultySelectionPanelLeft()
    {
        if (difficultySelectionPanel != null)
        {
            difficultySelectionPanel.GetComponent<RectTransform>().LeanMoveX(0f, 0.2f).setDelay(0.2f).setEaseOutBack().setOnComplete(SetPanelButtonsScaleToStart);
        }
    }
    private void SetPanelButtonsScaleToStart()
    {
        for (int i = 0; i < buttonsToScale.Count; i++)
        {
            buttonsToScale[i].LeanScale(new Vector3(1f, 1f, 1f), 0.3f).setEaseOutBack();
        }
    }

    public void BackButton_OnClick()
    {
        MoveDifficultySelectionPanelRight();
        MoveMainMenuPanelRight();
    }
    private void MoveMainMenuPanelRight()
    {
        if (mainMenuPanel != null)
        {
            mainMenuPanel.GetComponent<RectTransform>().LeanMoveX(0f, 0.2f).setDelay(0.2f).setEaseOutBack();
        }
    }
    private void MoveDifficultySelectionPanelRight()
    {
        if (difficultySelectionPanel != null)
        {
            difficultySelectionPanel.GetComponent<RectTransform>().LeanMoveX(900f, 0.2f).setEaseInBack().setOnStart(SetPanelButtonsScaleToEnd);
        }
    }
    private void SetPanelButtonsScaleToEnd()
    {
        for (int i = 0; i < buttonsToScale.Count; i++)
        {
            buttonsToScale[i].LeanScale(new Vector3(0f, 0f, 0f), 0.3f).setEaseInBack();
        }
    }

    public static UnityEvent isDifficultySelectionPanelDoneAnimating = new UnityEvent();
    public void DifficultyButton_OnClick()
    {
        difficultySelectionPanel.GetComponent<RectTransform>().LeanMoveX(900f, 0.2f).setEaseInBack().setOnComplete(isDifficultySelectionPanelDoneAnimating.Invoke);
    }
}
