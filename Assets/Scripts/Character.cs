using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public enum Weapon
    {
        Pistol,
        Bat,
        Fist,
    }

    public Weapon weapon;
    public float runSpeed;
    public float distanceFromEnemy;
    public Transform target;
    public TargetIndicator targetIndicator;
    DamageEffect damageEffect;
    
    Animator animator;
    Vector3 originalPosition;
    Quaternion originalRotation;
    Health health;
    bool idle;
    bool shouldAttack;
    bool animationEnded;
    bool dead;
    float characterRotationSpeed = 25f;
    // Start is called before the first frame update
    void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        originalPosition = transform.position;
        originalRotation = transform.rotation;
        health = GetComponent<Health>();
        targetIndicator = GetComponentInChildren<TargetIndicator>();
        damageEffect = GetComponent<DamageEffect>();
        StartCoroutine(Logic());
        
    }

    public bool IsIdle()
    {
        return idle && !shouldAttack;
    }

    public bool IsDead()
    {
        return dead;
    }

    public void DoDamage()
    {
        if (IsDead())
            return;

        damageEffect.PlayDamageEffect();   
        health.ApplyDamage(1.0f); // FIXME захардкожено
        if (health.current <= 0.0f)
        {
            dead = true;
        }
            
    }

    public void AttackEnemy()
    {
        shouldAttack = true;
    }

    public void AnimationEnded()
    {
        animationEnded = true;
    }

    bool RunTowards(Vector3 targetPosition, float distanceFromTarget)
    {
        Vector3 distance = targetPosition - transform.position;
        if (distance.magnitude < 0.00001f) {
            transform.position = targetPosition;
            return true;
        }

        Vector3 direction = distance.normalized;
        transform.rotation = Quaternion.LookRotation(direction);

        targetPosition -= direction * distanceFromTarget;
        distance = (targetPosition - transform.position);

        Vector3 step = direction * runSpeed;
        if (step.magnitude < distance.magnitude) {
            transform.position += step;
            return false;
        }

        transform.position = targetPosition;
        return true;
    }


    


    IEnumerator Logic()
    {
        for (;;) {
            // Idle
            idle = true;
            animator.SetFloat("Speed", 0.0f);
            transform.rotation = originalRotation;
            do {
                if (dead) {
                    // BeginDying / Dead
                    animator.SetTrigger("Death");
                    yield break;
                }
                yield return null;
            } while (!shouldAttack);

            idle = false;
            shouldAttack = false;

           

            // RunningToEnemy
            if (weapon == Weapon.Bat || weapon == Weapon.Fist) {
                animator.SetFloat("Speed", runSpeed);
                while (!RunTowards(target.position, distanceFromEnemy))
                {
                    if (dead)
                    {
                        animator.SetTrigger("Death");
                        yield break;
                    }
                    yield return new WaitForFixedUpdate();
                }
                    
            }


            //Rotate to enemy
            if (weapon == Weapon.Pistol)
            {
                Vector3 distance = target.position - transform.position;
                Vector3 direction = distance.normalized;
                Quaternion dir = Quaternion.LookRotation(direction);
                while(Quaternion.Angle(dir,transform.rotation)>0.001)
                {
                    transform.rotation = Quaternion.Lerp(transform.rotation, dir, characterRotationSpeed * Time.deltaTime);
                    yield return null;
                }
                originalRotation = dir;
                
            }
                

            // BeginAttack / BeginPunch / BeginShoot
            animationEnded = false;
            switch (weapon) {
                case Weapon.Bat:
                    animator.SetTrigger("MeleeAttack");
                    break;

                case Weapon.Fist:
                    animator.SetTrigger("Punch");
                    break;

                case Weapon.Pistol:
                    Debug.Log("Shooting");
                    
                    
                    animator.SetTrigger("Shoot");
                   
                    break;
            }

            // Attack / Punch / Shoot
            while (!animationEnded)
                yield return null;
            
            animationEnded = false;

            // RunningFromEnemy
            if (weapon == Weapon.Bat || weapon == Weapon.Fist) {
                animator.SetFloat("Speed", runSpeed);
                while (!RunTowards(originalPosition, 0.0f))
                {
                    if (dead)
                    {
                        animator.SetTrigger("Death");
                        yield break;
                    }
                    yield return new WaitForFixedUpdate();
                }
                    
            }
        }
    }
}
