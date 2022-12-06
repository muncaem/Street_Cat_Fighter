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

    public GameObject damage;//보스hp에서 피해입는함수가져오게
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
            if (GameObject.FindWithTag("Enemy"))
            {
                damage.GetComponent<BossHp>().TakeDamage(10f);
            }
        }
 
    }

    void HpBarMove()//hp가 오브젝트 따라다니도록
    {
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);
        float x = screenPos.x;

        //hpBarSprite.transform.position = new Vector3(x, screenPos.y + 90, 0);
        //hpBarBgSprite.transform.position = new Vector3(x, screenPos.y + 90, 0);
        playerhpbar.transform.position = new Vector3(x, screenPos.y + 90, 0);
    }
}
