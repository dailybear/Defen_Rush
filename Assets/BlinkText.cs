using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BlinkText : MonoBehaviour
{
    public Text bText;

    void Start()
    {
        StartCoroutine(BlinkTXT());
    }

    public IEnumerator BlinkTXT()
    {
        while (true)
        {
            bText.text = "";
            yield return new WaitForSeconds(.5f);
            bText.text = "Press Enter To Start";
            yield return new WaitForSeconds(.5f);
        }
    }
}