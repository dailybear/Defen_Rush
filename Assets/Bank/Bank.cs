using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Bank : MonoBehaviour
{
    [SerializeField] int startingBalance = 150;
    [SerializeField] int currentBalance;
    [SerializeField] TextMeshProUGUI displayBalance;

    // ������Ƽ
    public int CurrentBalance { get { return currentBalance; } }

    void Awake()
    {
        currentBalance = startingBalance;
    }
    public void Deposit(int amount)
    {
        currentBalance += Mathf.Abs(amount); // abs : amount�� ���� ��ȯ => ���� ����
        UpdateDisplay();
    }

    public void Withdraw(int amount) // ��ȭ����
    {
        currentBalance -= Mathf.Abs(amount); // abs : amount�� ���� ��ȯ => ���� ����
        UpdateDisplay();
        if (currentBalance < 0)
        {
            // Lose the game;
            ReloadScene();
        }
    }

    void UpdateDisplay()
    {
        displayBalance.text = "Gold : " + currentBalance;
    }

    void ReloadScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }
}
