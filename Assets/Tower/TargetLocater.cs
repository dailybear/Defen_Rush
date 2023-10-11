using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocater : MonoBehaviour
{
    [SerializeField] Transform weapon;
    [SerializeField] Transform target;

    private void Start()
    {
        target = FindAnyObjectByType<B_EnemyMove>().transform;
    }
    private void Update()
    {
        AimWeapon();
    }
    void AimWeapon()
    {
        weapon.LookAt(target);
    }
}
