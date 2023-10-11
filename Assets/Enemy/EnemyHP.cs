using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Enemy))]
public class EnemyHP : MonoBehaviour
{
    [SerializeField] int maxHP = 10;
    [SerializeField] int difficultyRamp = 1;
    int curruntHP = 0;
    Enemy enemy;

    private void OnEnable()
    {
        curruntHP = maxHP; // ���۽� �ִ� HP�� ���� HP
    }
    void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    void OnParticleCollision(GameObject other) // ��ƼŬ�� �浹���� �� ȣ��
    {
        ProcessHit();
    }

    void ProcessHit()
    {
        curruntHP--; // ���� hp - 1

        // ����HP�� 0������ �� ���ӿ�����Ʈ ��Ȱ��ȭ �� ���� ��� ȹ��
        if (curruntHP <= 0)
        {
            gameObject.SetActive(false); 
            enemy.RewardGold();
        }
    }
}
