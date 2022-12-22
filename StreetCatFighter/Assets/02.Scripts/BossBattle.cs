using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BossBattle : MonoBehaviour
{
    public float bossHp = 100;
    public float catHp = 100;

    public float attackPw = 5;

    public Image bossHpBar;
    public Image bossHpBarBg;
    public Image catHpBar;
    public Image catHpBarBg;

    public GameObject BaseUIBG;
    public GameObject ClearMent;
    public GameObject FailMent;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("BeAttacked", 0.1f, 0.3f);
        if(catHp == 0)
        {
            CancelInvoke();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AttackBtn_Boss()
    {
        if(catHp > 0)
        {
            if (bossHp > 0)
            {
                bossHp -= attackPw;
            }
            else
            {
                bossHp = 0;
                BaseUIBG.SetActive(true);
                ClearMent.SetActive(true);
            }
            bossHpBar.fillAmount = bossHp / 100f;

            //공격 효과 ->
            //
            //...
        }
    }

    public void BeAttacked()
    {
        if (catHp > 0)
        {
            catHp -= attackPw;
        }
        else
        {
            catHp = 0;
            BaseUIBG.SetActive(true);
            FailMent.SetActive(true);
        }
        catHpBar.fillAmount = catHp / 100f;
    }

    public void backToMain()
    {
        SceneManager.LoadScene("Main");
    }
}
