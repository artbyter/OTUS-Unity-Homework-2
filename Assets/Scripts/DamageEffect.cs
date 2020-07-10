using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEffect : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] ParticleSystem damageParticleSystem;

    public void PlayDamageEffect()
    {
        damageParticleSystem.Play();
    }
}
