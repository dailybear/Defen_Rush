using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// ���� HP ����
public class Castle : MonoBehaviour
{
    [SerializeField] int maxCastleHP = 500;
    [SerializeField] Slider slider;
    int curruntCastleHP = 0; 

    private void OnEnable()
    {
        curruntCastleHP = maxCastleHP;
        slider.value = 100;
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
    private void Update()
    {
        HandleHP();
    }
    void HandleHP()
    {
        slider.value = curruntCastleHP;
    }
}
