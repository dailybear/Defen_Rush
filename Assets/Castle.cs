using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// 성의 HP 관리
public class Castle : MonoBehaviour
{
    int maxCaslteHP = 500;
    int curruntCastleHP = 0; 

    private void OnEnable()
    {
        curruntCastleHP = maxCaslteHP;
    }
    void Start()
    {
        
    }
    public void CaslteHP(int damage)
    {
        curruntCastleHP -= damage;
        if (curruntCastleHP <= 0) // 성의 HP가 0이하 시 게임 오버
        {
            // 게임 오버 씬 로드
            Debug.Log("Game Over!");
        }
    }
}
