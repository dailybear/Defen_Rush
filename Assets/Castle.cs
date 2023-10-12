using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// ���� HP ����
public class Castle : MonoBehaviour
{
    [SerializeField] int maxCastleHP = 500;
    int curruntCastleHP = 0; 

    private void OnEnable()
    {
        curruntCastleHP = maxCastleHP;
        Debug.Log("���۽� �� HP : " + curruntCastleHP);
    }
    void Start()
    {
        
    }
    public void CastleHP(int damage)
    {
        curruntCastleHP -= damage;
        Debug.Log("���� HP : " + curruntCastleHP);
        if (curruntCastleHP <= 0) // ���� HP�� 0���� �� ���� ����
        {
            // ���� ���� �� �ε�
            Debug.Log("Game Over!");
            SceneManager.LoadScene("JHyeon_Lose");
        }
    }
}
