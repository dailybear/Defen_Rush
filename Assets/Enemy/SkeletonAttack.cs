using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonAttack : MonoBehaviour
{
    [SerializeField] Transform weapon;
    [SerializeField] Transform swordPivot; // �� ��ġ ������
    [SerializeField] Transform shieldPivot; // ���� ��ġ ������
    [SerializeField] Transform leftHand; // �޼�(����)
    [SerializeField] Transform rightHand; // ������(��)

    Animator anim; // ���̷��� �ִϸ�����
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
        enemyHP.ProcessHit();   // ������ ������ hp--;
        Debug.Log("Attack!");
        castle.CaslteHP(10);
    }

}
