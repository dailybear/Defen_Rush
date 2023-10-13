using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public bool isplaying;
    public string nextSceneName;
    public string pastSceneName;
    public bool gameWin;
    public bool gameLose;
    [SerializeField] int getClear = 10;

    GameObject levelup;


    void Start()
    {
        levelup = GameObject.Find("LevelUp");
        
    }

    void Update()
    {
        

        if (isplaying)
        {
            if (levelup != null)
            {
                levelup.SetActive(false);
                GameClear();
            }
            LevelChange();
        }   
        else
        {
            if (Input.GetButtonDown("Submit"))
                SceneManager.LoadScene("Stage1");
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            Title();
        }
    }

    void Title()
    {
            SceneManager.LoadScene("Title");
    }
    void GameClear()
    {
        if (GameManager.instance.kill >= getClear)
        {
            levelup.SetActive(true);

            if (Input.GetButtonDown("Submit"))
                SceneManager.LoadScene(nextSceneName);
        }
       
    }

    void LevelChange()
    {
        if (nextSceneName != null)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
                SceneManager.LoadScene(nextSceneName);
        }
    
        if (pastSceneName != null)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            SceneManager.LoadScene(pastSceneName);
        }
    }

}
