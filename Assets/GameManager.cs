using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int kill;
    public static GameManager instance;
    public Text killText;

    private void Awake()
    {
        instance = this;
    }

    public void AddKill()
    {
        kill++;
        killText.text = "Kill : "+ kill;
    }
}
