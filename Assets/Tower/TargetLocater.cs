using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocater : MonoBehaviour
{
    [SerializeField] Transform weapon;
    [SerializeField] ParticleSystem projectileParticle;
    [SerializeField] Transform target;
    [SerializeField] float range = 15f;
    Animator anim;

    private void Awake()
    {
     anim = GetComponent<Animator>();   
    }

    private void Update()
    {
        FindClosestTarget();
        AimWeapon();
    }
    void AimWeapon()
    {
        float targetDistance = Vector3.Distance(transform.position, target.position);
        weapon.LookAt(target);

        if(targetDistance < range)
        {
            Attack(true);
        }
        else
        {
            Attack(false);
        }
    }
    void FindClosestTarget()
    {
        B_Enemy[] enemies = FindObjectsOfType<B_Enemy>();
        Transform closestTarget = null;
        float maxDistance = Mathf.Infinity;

        foreach(B_Enemy enemy in enemies)
        {
            float targetDistance = Vector3.Distance(transform.position, enemy.transform.position);

            if(targetDistance < maxDistance)
            {
                closestTarget = enemy.transform;
                maxDistance = targetDistance;
            }
        }
        target = closestTarget;
    }
    void Attack(bool isActivce)
    {
        anim.SetBool("isInRange", isActivce);
        var emmisionModule = projectileParticle.emission;
          emmisionModule.enabled = isActivce;
    }
}
