using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public bl_Joystick js; // ���̽�ƽ

    public float speed = 3f; // ���ǵ�

    public float playerHp = 100f; // ü��
    public Image hpBarSprite; // ü�� ������

    public float exp = 0f; // ����ġ
    public Image expBarSprite; // ����ġ ������

    public int level = 1; // ����
    public Text levelNum; // ���� Text

    public float power; // ���ݷ�

    public int coin = 0; // ����
    public Text coinNum; // ���� ���� Text

    public GameObject cantbuywin, canbuy, nomorewin;

    List<Image> invenbaseImg = new List<Image>();
    public int invenCount, invennum;
    bool pause = false;
    public GameObject lef; //������

    public GameObject boxSprite; // �� ���� �ڽ� ��������Ʈ

    public SpriteRenderer renderer;
    public Sprite[] playerSprite;

    public Animator anim;
    //bool isWalk;
    //bool isRun;

    void Start() 
    {
        invenCount = 0;
        invennum = 0;

        //renderer = GetComponent<SpriteRenderer>();
        //renderer.sprite = playerSprite[0];

        for (int i = 1; i < 4; i++)
        {
            invenbaseImg.Add(GameObject.Find("Slot" + i).transform.GetChild(0).gameObject.GetComponent<Image>());
        }

        anim = GetComponent<Animator>();
        // anim.SetFloat("Speed", 0);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Attack();
        LevelUp();
        PowerUp();
        UIBar();
        CheckAnimState();
        if(pause == true)
        {
            Time.timeScale = 0;
        }
        if(pause == false)
        {
            Time.timeScale = 1;
        }
    }

    // �̵� �Լ�
    void Move()
    {
        Vector3 dir = new Vector3(js.Horizontal, js.Vertical, 0); // ��ƽ�� ���� ���� ����
        dir.Normalize();
        transform.position += dir * speed * Time.deltaTime;
    }

    void Attack()
    {
        // Ŭ��(��ġ) ��
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(touchPos, Camera.main.transform.forward);

            if (hit.collider != null)
            {
                GameObject touchedObj = hit.transform.gameObject;
                Debug.Log("touchedObj = " + touchedObj.name);

                // �� Ŭ�� ��
                if (touchedObj.tag == "Enemy")
                {
                    // ���� ���� ���� �Ǵ�
                    Vector3 dir = (touchedObj.transform.position - this.transform.position).normalized;
                    float distance = Vector3.Distance(this.transform.position, touchedObj.transform.position);

                    if (distance <= 1.2f)
                    {
                        touchedObj.GetComponent<Enemy>().attackAvailable_p = true;
                    }
                    else
                    {
                        touchedObj.GetComponent<Enemy>().attackAvailable_p = false;
                    }

                    // ���� ���� ���� �ȿ� ���
                    if (touchedObj.GetComponent<Enemy>().attackAvailable_p == true) 
                    {
                        float enemyHp = touchedObj.GetComponent<Enemy>().enemyHp;

                        if (enemyHp > 0)
                        {
                            touchedObj.GetComponent<Enemy>().enemyHp -= power;
                            touchedObj.GetComponent<Enemy>().anim.SetTrigger("isAttacked");
                        }
                        else
                        {
                            touchedObj.GetComponent<Enemy>().enemyHp = 0;
                        }

                        touchedObj.GetComponent<Enemy>().hpBarSprite.fillAmount
                            = touchedObj.GetComponent<Enemy>().enemyHp / 100f;

                       

                        Debug.Log(touchedObj.name + "�� ���ݹް� �ֽ��ϴ�.\nHp : " + touchedObj.GetComponent<Enemy>().enemyHp);
                        Debug.Log("Player Power : " + power);
                    }
                }

                if(touchedObj.name == "machine")
                {
                    GameObject machinobj = GameObject.Find("---���Ǳ�---").transform.GetChild(0).gameObject;
                    machinobj.SetActive(true);

                    if(machinobj.activeSelf == true)
                    {
                        pause = true;
                    }
                    //pause = true;
                    //if (pause == true)
                    //{
                    //    Time.timeScale = 0;
                    //}
                    //Time.timeScale = 0;
                }

                if(touchedObj.name == "StoreTile")
                {
                    GameObject storeobj = GameObject.Find("---Store---").transform.GetChild(0).gameObject;
                    storeobj.SetActive(true);

                    if(storeobj.activeSelf == true)
                    {
                        pause = true;
                    }
                    //StoreOpen randomcreate = GameObject.Find("Store1").GetComponent<StoreOpen>();
                    //randomcreate.RandomItemStore();
                    //pause = true;
                    //if (pause == true)
                    //{
                    //    Time.timeScale = 0;
                    //}
                }

                if(touchedObj.name == "Traveler")
                {
                    GameObject travelerobj = GameObject.Find("---���׳׻���---").transform.GetChild(0).gameObject;
                    travelerobj.SetActive(true);

                    if(travelerobj.activeSelf == true)
                    {
                        pause = true;
                    }
                    //pause = true;
                    //if(pause == true)
                    //{
                    //    Time.timeScale = 0;
                    //}
                }

                if(touchedObj.name == "leaflet")
                {
                    SceneManager.LoadScene("BossBattle");
                }

                else
                    return;
            }
        }
    }

    void PowerUp() 
    {
        switch (level)
        {
            case 1:
                power = 15f;
                break;
            case 2:
                power = 20f;
                break;
            case 3:
                power = 23f;
                break;
            case 4:
                power = 26f;
                break;
            case 5:
                power = 30f;
                break;
            case 6:
                power = 33f;
                break;
            case 7:
                power = 36f;
                break;
            case 8:
                power = 40f;
                break;
            case 9:
                power = 43f;
                break;
            case 10:
                power = 50f;
                break;
        }
    }

    public void normalTime()
    {
        pause = false;
    }

    void LevelUp() 
    {
        if (exp >= 100f) 
        {
            level++;
            exp = 0f;
            levelNum.text = level.ToString();
        }

        if(level >= 10) //10����
        {
            lef.SetActive(true); //������ Ȱ��ȭ
        }
    }

    void CheckAnimState() 
    {
        anim.SetBool("isAttacked", false);

        /*GameObject[] enemy = GameObject.FindGameObjectsWithTag("Enemy");
        for (int i = 0; i < enemy.Length; i++) 
        {
            if (enemy[i].GetComponent<Enemy>().RealAttack() == true) 
            {
                anim.SetBool("isAttacked", true);
            }
            else
                anim.SetBool("isAttacked", false);
        }*/

        if (speed == 3f)
        {
            anim.SetBool("Walk", true);
            anim.SetBool("Run", false);
        }

        else if (speed > 3f) 
        {
            anim.SetBool("Walk", false);
            anim.SetBool("Run", true);
        }


        /*if (isWalk == true)
        {
            anim.SetBool("Walk", true);
            anim.SetBool("Run", false);
        }
        else if (isRun == true) 
        {
            anim.SetBool("Walk", false);
            anim.SetBool("Run", true);
        }*/
    }

    void HpIncrease()
    {
        // ����
    }

    void UIBar() 
    {
        hpBarSprite.fillAmount = playerHp / 100f;
        expBarSprite.fillAmount = exp / 100f;
    }

    // �浹 ó�� �Լ�
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name.Contains("Pigeon")) // ��ѱ�� �浹 ��
        {
            playerHp -= 10;
        }

        if (collision.name.Contains("BronzeCoin")) // ��ȭ ȹ�� ��
        {
            coin += 1;
            coinNum.text = coin.ToString();
        }
        if (collision.name.Contains("SilverCoin")) // ��ȭ ȹ�� ��
        {
            coin += 5;
            coinNum.text = coin.ToString();
        }
        if (collision.name.Contains("GoldCoin")) // ��ȭ ȹ�� ��
        {
            coin += 10;
            coinNum.text = coin.ToString();
        }

        if (collision.name.Contains("Fish"))
        {
            speed = 10f; // �̵��ӵ� up
            power *= 2f; // ���ݷ� up
            Invoke("EndBuff_fish", 10f);
        }

        if (collision.name.Contains("Box")) 
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            for (int i = 0; i < enemies.Length; i++) 
            {
                enemies[i].GetComponent<Enemy>().enemyPower /= 2f;
            }
            Invoke("EndBuff_box", 10f);

            boxSprite.SetActive(true);

            Debug.Log("�ڽ��� ȹ���߽��ϴ�. ���� up");
        }
        //if (collision.name.Contains("leaflet"))
        //{
        //    SceneManager.LoadScene("BossBattle");
        //}
    }

    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    if (collision.tag == "Store")
    //    {
    //        //Debug.Log("Ʈ���� ����");
    //        StoreCV = GameObject.Find("---Store---").transform.GetChild(0).gameObject;
    //        StoreCV.SetActive(true);
    //    }
    //}
    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.tag == "Store")
    //    {
    //        StoreCV.SetActive(false);
    //    }
    //}

    void EndBuff_fish()
    {
        // ���� ��
        speed = 3f;
        power = 5f;

        anim.SetFloat("Speed", speed);
    }

    void EndBuff_box()
    {
        // ���� ��
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].GetComponent<Enemy>().enemyPower = 10f;
        }

        boxSprite.SetActive(false);
    }

    // Store Calc
    public void StCalc()
    {
        StoreOpen bringing = GameObject.Find("Store1").GetComponent<StoreOpen>();
        
        int item_cost = 0;
        int.TryParse(bringing.costbring, out item_cost);

        int calcresult = coin - item_cost;
        //print(calcresult);

        if (calcresult < 0)
        {
            cantbuywin.SetActive(true);
        }
        else
        {
            if (invennum > 2)
            {
                //"you can't buy item anymore" UI add
                nomorewin.SetActive(true);
            }
            else
            {
                canbuy.SetActive(true);
                coin = calcresult;
                //print(coin);
                coinNum.text = coin.ToString();

                invennum += 1;

                invenbaseImg[invenCount].sprite = bringing.itemsprite.GetComponent<SpriteRenderer>().sprite;
                invenbaseImg[invenCount].gameObject.SetActive(true);
                invenCount++;
            }
        }
    }
}
