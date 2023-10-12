using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// 성의 HP 관리
public class Castle : MonoBehaviour
{
    [SerializeField] int maxCastleHP = 500;
    [SerializeField] Slider slider;
    int curruntCastleHP = 0; 

    private void OnEnable()
    {
        curruntCastleHP = maxCastleHP;
        slider.value = 100;
        Debug.Log("시작시 성 HP : " + curruntCastleHP);
    }
    void Start()
    {
        
    }
    public void CastleHP(int damage)
    {
        curruntCastleHP -= damage;
        Debug.Log("성의 HP : " + curruntCastleHP);
        if (curruntCastleHP <= 0) // 성의 HP가 0이하 시 게임 오버
        {
            // 게임 오버 씬 로드
            Debug.Log("Game Over!");
            SceneManager.LoadScene("JHyeon_Lose");
        }
    }
    private void Update()
    {
        HandleHP();
    }
    void HandleHP()
    {
        slider.value = curruntCastleHP;
    }
}
