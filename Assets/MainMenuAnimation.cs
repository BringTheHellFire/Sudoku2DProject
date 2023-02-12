using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuAnimation : MonoBehaviour
{

    [SerializeField] private GameObject title;
    [SerializeField] private GameObject playButton;

    [SerializeField] private ParticleSystem theParticleSystem;

    // Start is called before the first frame update
    void Start()
    {
        
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
