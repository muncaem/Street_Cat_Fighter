using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Playerbattle : MonoBehaviour//player 조이스틱
{
    Rigidbody2D rbComp; // rigidbody

    SpriteRenderer spriteRend; // sprite renderer

    public bl_Joystick js; // 조이스틱

    public float speed; // 스피드

    public float power = 5; // 공격력

    //public Image hpBarSprite; // 체력 게이지 Sprite
    //public Image hpBarBgSprite; // 체력 게이지 배경 Sprite

    public Slider playerhpbar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Attack();
        HpBarMove();
    }

   

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
            }
        }
    }

    void HpBarMove()
    {
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);
        float x = screenPos.x;

        //hpBarSprite.transform.position = new Vector3(x, screenPos.y + 90, 0);
        //hpBarBgSprite.transform.position = new Vector3(x, screenPos.y + 90, 0);
        playerhpbar.transform.position = new Vector3(x, screenPos.y + 90, 0);
    }
}
