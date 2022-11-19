using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BtnType : MonoBehaviour
{
    public BTNType currentType;
    public void OnBtnClick()
    {
        switch (currentType)
        {
            case BTNType.Start:
                SceneManager.LoadScene("SampleScene");
                break;

            case BTNType.Closet:
                SceneManager.LoadScene("Closet");
                break;

            case BTNType.Quit:
                Application.Quit();
                break;
        }
    }
}
