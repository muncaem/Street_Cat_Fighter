using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    Rigidbody2D rbComp; // rigidbody

    SpriteRenderer spriteRend; // sprite renderer

    public bl_Joystick js; // ���̽�ƽ

    public float speed; // ���ǵ�

    public float playerHp = 100f; // ü��
    public Image hpBarSprite; // ü�� ������

    public float exp = 0f; // ����ġ
    public Image expBarSprite; // ����ġ ������

    public int level = 1; // ����
    public Text levelNum; // ���� Text

    public float power = 5; // ���ݷ�

    public int coin = 0; // ����
    public Text coinNum; // ���� ���� Text

    GameObject StoreCV;

    public GameObject cantbuywin, canbuy, nomorewin;

    List<Image> invenbaseImg = new List<Image>();
    int invenCount, invennum;

    public GameObject lef; //������

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
                            touchedObj.GetComponent<Enemy>().enemyHp -= power;
                        else
                        {
                            touchedObj.GetComponent<Enemy>().enemyHp = 0;
                        }

                        touchedObj.GetComponent<Enemy>().hpBarSprite.fillAmount
                            = touchedObj.GetComponent<Enemy>().enemyHp / 20f;

                        Debug.Log(touchedObj.name + "�� ���ݹް� �ֽ��ϴ�.\nHp : " + touchedObj.GetComponent<Enemy>().enemyHp);
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

        if(level >= 10) //10����
        {
            lef.SetActive(true); //������ Ȱ��ȭ
        }
    }

    // Hp ���� �Լ�
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

        if (collision.name.Contains("Coin")) // ���� ȹ�� ��
        {
            coin += 1;
            coinNum.text = coin.ToString();
        }

        if (collision.name.Contains("Fish"))
        {
            speed = 10f; // �̵��ӵ� up
            power = 10f; // ���ݷ� up
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
            //Debug.Log("Ʈ���� ����");
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
        // ���� ��
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
