using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// ���� HP ����
public class Castle : MonoBehaviour
{
    int maxCaslteHP = 100;
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
        Debug.Log("���� HP : " + curruntCastleHP);
        if (curruntCastleHP <= 0) // ���� HP�� 0���� �� ���� ����
        {
            // ���� ���� �� �ε�
            Debug.Log("Game Over!");
        }
    }
}
