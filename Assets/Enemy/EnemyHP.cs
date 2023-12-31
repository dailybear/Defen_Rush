using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Enemy))]
public class EnemyHP : MonoBehaviour
{
    [SerializeField] int maxHP = 3;
    [SerializeField] int difficultyRamp = 1;
    int curruntHP = 0;
    Enemy enemy;
    Animator anim;

    private void OnEnable()
    {
        curruntHP = maxHP; // 시작시 최대 HP가 현재 HP
    }
    void Start()
    {
        enemy = GetComponent<Enemy>();
        anim = GetComponentInChildren<Animator>();
    }

    void OnParticleCollision(GameObject other) // 파티클과 충돌했을 때 호출
    {
        ProcessHit();
    }

    public void ProcessHit()
    {
        curruntHP--; // 현재 hp - 1
        Debug.Log("적 현재 HP : " + curruntHP);
        // 현재HP가 0이하일 시 게임오브젝트 비활성화 및 보상 골드 획득
        if (curruntHP <= 0)
        {
            anim.SetBool("IsWalk", false);
            anim.SetBool("IsAttack", false);
            anim.SetBool("IsDie", true);
            GameManager.instance.AddKill();
            gameObject.SetActive(false); 
            enemy.RewardGold();
        }
    }
}
