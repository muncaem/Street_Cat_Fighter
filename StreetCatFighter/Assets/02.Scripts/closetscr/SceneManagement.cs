using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManagement : MonoBehaviour
{

    public void SceneTransition()
    {
        SceneManager.LoadScene("Main");
        //start ��ư ������ �޴����� �������� �̵�}
    }

    public void backToMain()
    {
        SceneManager.LoadScene("Main");
    }
}
