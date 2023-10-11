using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public string nextSceneName;

    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetButtonDown("Submit"))
            SceneManager.LoadScene(nextSceneName);
    }
}
