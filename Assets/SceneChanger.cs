using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public bool isplaying;
    public string nextSceneName;
    public bool gameWin;
    public bool gameLose;


    [SerializeField] int getClear = 10;

   

    void Update()
    {
        if (isplaying)
        {
            GameClear();
        }
        else
        {
            if (Input.GetButtonDown("Submit"))
                SceneManager.LoadScene("Jimin_Forest");
        }

        Title();

        
    }

    void Title()
    {
        if (Input.GetKeyDown(KeyCode.R))
            SceneManager.LoadScene("Jhyeon_NL");
    }
    void GameClear()
    {
        if (GameManager.instance.kill >= getClear)
            SceneManager.LoadScene(nextSceneName);
    }
}
