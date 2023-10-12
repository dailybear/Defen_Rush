using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonAttack : MonoBehaviour
{
    [SerializeField] Transform weapon;
    [SerializeField] Transform swordPivot; // 검 배치 기준점
    [SerializeField] Transform shieldPivot; // 방패 배치 기준점
    [SerializeField] Transform leftHand; // 왼손(방패)
    [SerializeField] Transform rightHand; // 오른손(검)

    Animator anim; // 스켈레톤 애니메이터
    EnemyHP enemyHP;
    [SerializeField] Castle castle;

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        enemyHP = GetComponent<EnemyHP>();
    }

    private void OnEnable()
    {
        weapon.gameObject.SetActive(true);
    }

    private void OnDisable()
    {
        weapon.gameObject.SetActive(false);
    }

    private void OnAnimatorIK(int layerIndex)
    {
        swordPivot.position = anim.GetIKHintPosition(AvatarIKHint.RightElbow);

        anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1.0f);
        anim.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1.0f);

        anim.SetIKPosition(AvatarIKGoal.LeftHand, leftHand.position);
        anim.SetIKRotation(AvatarIKGoal.LeftHand, leftHand.rotation);

        anim.SetIKPositionWeight(AvatarIKGoal.RightHand, 1.0f);
        anim.SetIKRotationWeight(AvatarIKGoal.RightHand, 1.0f);

        anim.SetIKPosition(AvatarIKGoal.RightHand, rightHand.position);
        anim.SetIKRotation(AvatarIKGoal.RightHand, rightHand.rotation);
    }

    private void OnTriggerEnter(Collider other)
    {
        
        
        if (other.tag == "Castle")
        {
            Attack();
        }
        
    }

    public void Attack()
    {
        anim.SetBool("IsAttack",true);
        enemyHP.ProcessHit();   // 공격할 때마다 hp--;
        Debug.Log("Attack!");
        castle.CaslteHP(10);
    }

}
