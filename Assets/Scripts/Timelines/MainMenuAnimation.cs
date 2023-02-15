using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MainMenuAnimation : MonoBehaviour
{
    [SerializeField] private PlayerInfo playerInfo;

    [SerializeField] private GameObject background;

    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject difficultySelectionPanel;
    [SerializeField] private GameObject shopPanel;
    [SerializeField] private GameObject optionsPanel;

    [SerializeField] private GameObject title;
    [SerializeField] private GameObject playButton;
    [SerializeField] private GameObject shopButton;
    [SerializeField] private GameObject optionsButton;

    [SerializeField] private GameObject leftAttachment;
    [SerializeField] private GameObject rightAttachment;
    
    [SerializeField] private List<GameObject> buttonsToScale;

    [SerializeField] private GameObject optionsBackButton;
    [SerializeField] private GameObject shopBackButton;

    [SerializeField] private GameObject themesHolder;

    private void Awake()
    {
        leftAttachment.GetComponent<RectTransform>().anchoredPosition = new Vector3(-550f, 50f, 0f);
        rightAttachment.GetComponent<RectTransform>().anchoredPosition = new Vector3(1100f, 50f, 0f);

        playButton.gameObject.transform.localScale = new Vector3(0f, 0f, 0f);
        shopButton.gameObject.transform.localScale = new Vector3(0f, 0f, 0f);
        optionsButton.gameObject.transform.localScale = new Vector3(0f, 0f, 0f);

        title.transform.localScale = new Vector3(0f, 0f, 0f);
        
        themesHolder.transform.localScale = new Vector3(0f, 0f, 0f);

        themesHolder.SetActive(false);
    }

    private void Start()
    {
        MoveLeftAttachmentToStartPosition();
        MoveRightAttachmentToStartPosition();
        SetTitleScaleToStartScale();
        SetPlayButtonScaleToStartScale();
        SetShopButtonToStartScale();
        SetOptionsButtonToStartScale();
    }

    private void MoveLeftAttachmentToStartPosition()
    {
        if (leftAttachment != null)
        {
            leftAttachment.GetComponent<RectTransform>().LeanMoveX(300f, 0.5f).setDelay(0.1f).setEaseOutBack();
        }
    }
    private void MoveRightAttachmentToStartPosition()
    {
        if (rightAttachment != null)
        {
            rightAttachment.GetComponent<RectTransform>().LeanMoveX(400f, 0.5f).setDelay(0.3f).setEaseOutBack();
        }
    }
    private void SetTitleScaleToStartScale()
    {
        if (title != null)
        {
            title.LeanScale(new Vector3(1f, 1f, 1f), 0.3f).setDelay(1f).setEaseOutQuart();
        }
    }
    private void SetPlayButtonScaleToStartScale()
    {
        if (playButton != null)
        {
            playButton.LeanScale(new Vector3(1f, 1f, 1f), 0.3f).setDelay(1.2f).setEaseOutBounce();
        }
    }
    private void SetShopButtonToStartScale()
    {
        if (shopButton != null)
        {
            shopButton.LeanScale(new Vector3(1f, 1f, 1f), 0.3f).setDelay(1.3f).setEaseOutBounce();
        }
    }
    private void SetOptionsButtonToStartScale()
    {
        if (optionsButton != null)
        {
            optionsButton.LeanScale(new Vector3(1f, 1f, 1f), 0.3f).setDelay(1.4f).setEaseOutBounce();
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
    private void MoveMainMenuPanelRight()
    {
        if (mainMenuPanel != null)
        {
            mainMenuPanel.GetComponent<RectTransform>().LeanMoveX(900f, 0.2f).setEaseInBack();
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
        MoveMainMenuPanelToStart();
    }
    private void MoveMainMenuPanelToStart()
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

    public void DifficultyButton_OnClick()
    {
        difficultySelectionPanel.GetComponent<RectTransform>().LeanMoveX(900f, 0.2f).setEaseInBack();
    }

    public void ShopButton_OnClick()
    {
        MoveMainMenuPanelRight();
        shopPanel.GetComponent<RectTransform>().LeanMoveX(0f, 0.2f).setDelay(0.2f).setEaseOutBack();
        shopBackButton.LeanScale(new Vector3(1f, 1f, 1f), 0.3f).setEaseOutBack();
    }
    public void BackButtonShopPanel_OnClick()
    {
        shopBackButton.LeanScale(new Vector3(0f, 0f, 0f), 0.3f).setEaseInBack();
        shopPanel.GetComponent<RectTransform>().LeanMoveX(-900f, 0.2f).setEaseInBack();
        MoveMainMenuPanelToStart();
    }
    public void OptionsButton_OnClick()
    {
        MoveMainMenuPanelToDown();
        themesHolder.SetActive(true);
        optionsPanel.GetComponent<RectTransform>().LeanMoveY(0f, 0.2f).setDelay(0.2f).setEaseOutBack();
        themesHolder.LeanScale(new Vector3(1f, 1f, 1f), 0.4f).setDelay(0.2f).setEaseOutQuart();
        optionsBackButton.LeanScale(new Vector3(1f, 1f, 1f), 0.3f).setEaseOutBack();
    }
    private void MoveMainMenuPanelToDown()
    {
        if (mainMenuPanel != null)
        {
            mainMenuPanel.GetComponent<RectTransform>().LeanMoveY(-1900f, 0.2f).setEaseInBack();
        }
    }
    private void MoveMainMenuPanelToUp()
    {
        if (mainMenuPanel != null)
        {
            mainMenuPanel.GetComponent<RectTransform>().LeanMoveY(0f, 0.2f).setDelay(0.2f).setEaseOutBack();
        }
    }
    public void BackButtonOptionsPanel_OnClick()
    {
        optionsBackButton.LeanScale(new Vector3(0f, 0f, 0f), 0.3f).setEaseInBack();
        optionsPanel.GetComponent<RectTransform>().LeanMoveY(1900f, 0.2f).setEaseInBack();
        themesHolder.LeanScale(new Vector3(0f, 0f, 0f), 0.2f).setEaseInQuart();
        themesHolder.SetActive(false);
        MoveMainMenuPanelToUp();
    }
}
