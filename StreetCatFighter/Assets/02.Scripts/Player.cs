using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public bl_Joystick js; // 조이스틱

    public float speed = 3f; // 스피드

    public float playerHp = 100f; // 체력
    public Image hpBarSprite; // 체력 게이지

    public float exp = 0f; // 경험치
    public Image expBarSprite; // 경험치 게이지

    public int level = 1; // 레벨
    public Text levelNum; // 레벨 Text

    public float power; // 공격력

    public int coin = 0; // 코인
    public Text coinNum; // 코인 개수 Text

    public GameObject cantbuywin, canbuy, nomorewin;

    List<Image> invenbaseImg = new List<Image>();
    public int invenCount, invennum;
    bool pause = false;
    public GameObject lef; //전단지

    public GameObject boxSprite; // 눈 구멍 박스 스프라이트

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

    // 이동 함수
    void Move()
    {
        Vector3 dir = new Vector3(js.Horizontal, js.Vertical, 0); // 스틱이 향한 방향 저장
        dir.Normalize();
        transform.position += dir * speed * Time.deltaTime;
    }

    void Attack()
    {
        // 클릭(터치) 시
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(touchPos, Camera.main.transform.forward);

            if (hit.collider != null)
            {
                GameObject touchedObj = hit.transform.gameObject;
                Debug.Log("touchedObj = " + touchedObj.name);

                // 적 클릭 시
                if (touchedObj.tag == "Enemy")
                {
                    // 공격 가능 범위 판단
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

                    // 공격 가능 범위 안에 들면
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

                       

                        Debug.Log(touchedObj.name + "가 공격받고 있습니다.\nHp : " + touchedObj.GetComponent<Enemy>().enemyHp);
                        Debug.Log("Player Power : " + power);
                    }
                }

                if(touchedObj.name == "machine")
                {
                    GameObject machinobj = GameObject.Find("---자판기---").transform.GetChild(0).gameObject;
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
                    GameObject travelerobj = GameObject.Find("---나그네상점---").transform.GetChild(0).gameObject;
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

        if(level >= 10) //10레벨
        {
            lef.SetActive(true); //전단지 활성화
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
        // 포션
    }

    void UIBar() 
    {
        hpBarSprite.fillAmount = playerHp / 100f;
        expBarSprite.fillAmount = exp / 100f;
    }

    // 충돌 처리 함수
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name.Contains("Pigeon")) // 비둘기와 충돌 시
        {
            playerHp -= 10;
        }

        if (collision.name.Contains("BronzeCoin")) // 동화 획득 시
        {
            coin += 1;
            coinNum.text = coin.ToString();
        }
        if (collision.name.Contains("SilverCoin")) // 은화 획득 시
        {
            coin += 5;
            coinNum.text = coin.ToString();
        }
        if (collision.name.Contains("GoldCoin")) // 금화 획득 시
        {
            coin += 10;
            coinNum.text = coin.ToString();
        }

        if (collision.name.Contains("Fish"))
        {
            speed = 10f; // 이동속도 up
            power *= 2f; // 공격력 up
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

            Debug.Log("박스를 획득했습니다. 방어력 up");
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
    //        //Debug.Log("트리거 성공");
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
        // 원래 값
        speed = 3f;
        power = 5f;

        anim.SetFloat("Speed", speed);
    }

    void EndBuff_box()
    {
        // 원래 값
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
