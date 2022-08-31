using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerParticle : MonoBehaviour
{
    public bool enable;

    public ParticleSystem particles;

    public void startParticles()
    {
        particles.Play();
    }
}
