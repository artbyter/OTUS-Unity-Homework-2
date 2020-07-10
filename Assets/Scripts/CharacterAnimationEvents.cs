using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationEvents : MonoBehaviour
{
    Character character;
    MuzzleFlash muzzleFlash;

    // Start is called before the first frame update
    void Start()
    {
        character = GetComponentInParent<Character>();
        muzzleFlash = character.GetComponentInChildren<MuzzleFlash>();
        Debug.Log(muzzleFlash);
    }

    void DoDamage()
    {
        
        Character targetCharacter = character.target.GetComponent<Character>();
        if (character.weapon == Character.Weapon.Pistol)
            muzzleFlash.PlayShootEffect();
        targetCharacter.DoDamage();
        
    }

    void AttackEnd()
    {
        
        character.AnimationEnded();
    }

    void PunchEnd()
    {
        character.AnimationEnded();
    }

    void ShootEnd()
    {
        
        character.AnimationEnded();
    }
}
