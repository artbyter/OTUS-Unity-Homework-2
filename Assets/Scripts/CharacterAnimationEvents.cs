using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationEvents : MonoBehaviour
{
    Character character;

    // Start is called before the first frame update
    void Start()
    {
        character = GetComponentInParent<Character>();
    }

    void DoDamage()
    {
        Character targetCharacter = character.target.GetComponent<Character>();
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
