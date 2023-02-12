using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

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
            rightCloud.GetComponent<RectTransform>().LeanMoveX(-200f, 0.5f).setDelay(0.3f).setEaseOutBack().setOnComplete(SetTitleScaleToStartScale);
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
            buttonsToScale[i].LeanScale(new Vector3(1f, 1f, 1f), 0.3f).setDelay(0.2f).setEaseOutBack();
        }
    }

    public void SetStarPosition()
    {
        Debug.Log("Start!");
        var particles = new ParticleSystem.Particle[theParticleSystem.main.maxParticles];
        var currentAmount = theParticleSystem.GetParticles(particles);

        // Change only the particles that are alive
        for (int i = 0; i < currentAmount; i++)
        {
            particles[i].position = new Vector3(i, i, 0);
            Debug.Log("Particle: " + i + " " + particles[i].position);
        }

        // Apply the particle changes to the Particle System
        theParticleSystem.SetParticles(particles, currentAmount);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
