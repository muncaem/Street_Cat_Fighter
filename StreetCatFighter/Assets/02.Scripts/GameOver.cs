using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    float playerHp;
    GameObject player;

    public GameObject restartBtn;
    public GameObject gameOverText;
    public GameObject blackPanel;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = 1;
        CheckGameOver();
    }

    void CheckGameOver() 
    {
        playerHp = player.GetComponent<Player>().playerHp;

        if (playerHp <= 0)
        {
            Time.timeScale = 0;

            restartBtn.SetActive(true);
            gameOverText.SetActive(true);
            blackPanel.SetActive(true);

            GameObject[] enemyHpBar = GameObject.FindGameObjectsWithTag("EnemyUI");

            for (int i = 0; i < enemyHpBar.Length; i++) 
            {
                enemyHpBar[i].SetActive(false);
            }
        }
    }

    public void OnClickRestart()
    {
        SceneManager.LoadScene("Main");
    }
}
