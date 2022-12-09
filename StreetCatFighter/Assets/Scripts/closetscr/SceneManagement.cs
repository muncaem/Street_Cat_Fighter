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
        //start 버튼 누르면 메뉴에서 게임으로 이동}
    }

    public void backToMain()
    {
        SceneManager.LoadScene("Main");
    }
}
