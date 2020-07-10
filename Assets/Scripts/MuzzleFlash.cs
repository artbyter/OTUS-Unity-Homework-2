using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuzzleFlash : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] ParticleSystem muzzleFlash;
    public void PlayShootEffect()
    {
        muzzleFlash.Play();
    }
}
