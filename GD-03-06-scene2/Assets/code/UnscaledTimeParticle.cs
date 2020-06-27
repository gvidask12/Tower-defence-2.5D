using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnscaledTimeParticle : MonoBehaviour
{
    public ParticleSystem particleSystem;
    void Update()
    {
        if (Time.timeScale < 0.01f)
        {

            particleSystem.Simulate(Time.unscaledDeltaTime, true, false);
        }
        else
            particleSystem.Simulate(Time.unscaledDeltaTime, false, false);

    }
}
