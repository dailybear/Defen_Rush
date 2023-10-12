using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Enemy))]
public class EnemyHP : MonoBehaviour
{
    [SerializeField] int maxHP = 5;
    [SerializeField] int difficultyRamp = 1;
    int curruntHP = 0;
    Enemy enemy;
    Animator anim;

    private void OnEnable()
    {
        curruntHP = maxHP; // ���۽� �ִ� HP�� ���� HP
    }
    void Start()
    {
        enemy = GetComponent<Enemy>();
        anim = GetComponentInChildren<Animator>();
    }

    void OnParticleCollision(GameObject other) // ��ƼŬ�� �浹���� �� ȣ��
    {
        ProcessHit();
    }

    public void ProcessHit()
    {
        curruntHP--; // ���� hp - 1
        Debug.Log("�� ���� HP : " + curruntHP);
        // ����HP�� 0������ �� ���ӿ�����Ʈ ��Ȱ��ȭ �� ���� ��� ȹ��
        if (curruntHP <= 0)
        {
            anim.SetBool("IsDie", true);
            gameObject.SetActive(false); 
            enemy.RewardGold();
        }
    }
}
