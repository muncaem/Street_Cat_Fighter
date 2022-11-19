using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    Rigidbody2D rbComp; // rigidbody

    SpriteRenderer spriteRend; // sprite renderer

    public bl_Joystick js; // 조이스틱

    public float speed; // 스피드

    public float playerHp = 100f; // 체력
    public Image hpBarSprite; // 체력 게이지

    public float exp = 0f; // 경험치
    public Image expBarSprite; // 경험치 게이지

    public int level = 1; // 레벨
    public Text levelNum; // 레벨 Text

    public float power = 5; // 공격력

    public int coin = 0; // 코인
    public Text coinNum; // 코인 개수 Text

    GameObject StoreCV;

    public GameObject cantbuywin, canbuy, nomorewin;

    List<Image> invenbaseImg = new List<Image>();
    int invenCount, invennum;

    public GameObject lef; //전단지

    void Start() 
    {
        invenCount = 0;
        invennum = 0;

        for (int i = 1; i < 4; i++)
        {
            invenbaseImg.Add(GameObject.Find("Slot" + i).transform.GetChild(0).gameObject.GetComponent<Image>());
        }
        //invenbaseImg = GameObject.Find("Slot1").transform.GetChild(0).gameObject.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Attack();
        LevelUp();
        UIBar();
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
                            touchedObj.GetComponent<Enemy>().enemyHp -= power;
                        else
                        {
                            touchedObj.GetComponent<Enemy>().enemyHp = 0;
                        }

                        touchedObj.GetComponent<Enemy>().hpBarSprite.fillAmount
                            = touchedObj.GetComponent<Enemy>().enemyHp / 20f;

                        Debug.Log(touchedObj.name + "가 공격받고 있습니다.\nHp : " + touchedObj.GetComponent<Enemy>().enemyHp);
                    }
                }

                else
                    return;
            }
        }
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

    // Hp 증가 함수
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

        if (collision.name.Contains("Coin")) // 코인 획득 시
        {
            coin += 1;
            coinNum.text = coin.ToString();
        }

        if (collision.name.Contains("Fish"))
        {
            speed = 10f; // 이동속도 up
            power = 10f; // 공격력 up
            Invoke("EndBuff", 10f);
        }

        if (collision.name.Contains("leaflet"))
        {
            SceneManager.LoadScene("BossBattle");
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Store")
        {
            //Debug.Log("트리거 성공");
            StoreCV = GameObject.Find("---Store---").transform.GetChild(0).gameObject;
            StoreCV.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Store")
        {
            StoreCV.SetActive(false);
        }
    }

    void EndBuff()
    {
        // 원래 값
        speed = 3f;
        power = 5f;
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
