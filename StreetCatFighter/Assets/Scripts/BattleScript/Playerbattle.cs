using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Playerbattle : MonoBehaviour//player ���̽�ƽ
{
    Rigidbody2D rbComp; // rigidbody

    SpriteRenderer spriteRend; // sprite renderer

    public bl_Joystick js; // ���̽�ƽ

    public float speed; // ���ǵ�

    public float power = 5; // ���ݷ�

    //public Image hpBarSprite; // ü�� ������ Sprite
    //public Image hpBarBgSprite; // ü�� ������ ��� Sprite

    public Slider playerhpbar;

    public GameObject damage;//����hp���� �����Դ��Լ���������
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
        Vector3 dir = new Vector3(js.Horizontal, js.Vertical, 0); // ��ƽ�� ���� ���� ����
        dir.Normalize();
        transform.position += dir * speed * Time.deltaTime;
    }

    void Attack()
    {
        // Ŭ��(��ġ) ��
        if (Input.GetMouseButtonDown(0))
        {
            if (GameObject.FindWithTag("Enemy"))
            {
                damage.GetComponent<BossHp>().TakeDamage(10f);
            }
        }
 
    }

    void HpBarMove()//hp�� ������Ʈ ����ٴϵ���
    {
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);
        float x = screenPos.x;

        //hpBarSprite.transform.position = new Vector3(x, screenPos.y + 90, 0);
        //hpBarBgSprite.transform.position = new Vector3(x, screenPos.y + 90, 0);
        playerhpbar.transform.position = new Vector3(x, screenPos.y + 90, 0);
    }
}
