using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    Transform playerPos;

    float speed = 2f;

    public float enemyHp = 20f; // 체력

    public bool attackAvailable_p = false; // Enemy에 대한 Player의 공격 가능 여부
    public bool attackAvailable_e = false; // Player에 대한 Enemy의 공격 가능 여부

    public Image hpBarSprite; // 체력 게이지 Sprite
    public Image hpBarBgSprite; // 체력 게이지 배경 Sprite

    Coroutine st;

    void Start()
    {
        //GameObject.FindWithTag("Player").GetComponent<Player>().isEnemyExist = true;
        playerPos = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        HpBarMove();
        Move();
        Attack();
        Die();
    }

    void Move()
    {
        Vector3 dir = (playerPos.position - this.transform.position).normalized;
        float distance = Vector3.Distance(this.transform.position, playerPos.position);

        if (distance <= 3.0f && distance >= 1.0f)
        {
            transform.Translate(dir * speed * Time.deltaTime);
            speed = 2f;
        }
        else
        {
            speed = 0f;
        }
    }

    void HpBarMove()
    {
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);
        float x = screenPos.x;

        hpBarSprite.transform.position = new Vector3(x, screenPos.y + 90, 0);
        hpBarBgSprite.transform.position = new Vector3(x, screenPos.y + 90, 0);
    }

    void Attack() 
    {
        // 공격 가능 범위 판단
        GameObject player = GameObject.FindWithTag("Player");

        Vector3 dir = (this.transform.position - player.transform.position).normalized;
        float distance = Vector3.Distance(this.transform.position, player.transform.position);

        if (distance <= 1.2f)
        {
            attackAvailable_e = true;
        }
        else
        {
            attackAvailable_e = false;
        }

        if (attackAvailable_e == true)
        {

            Invoke("RealAttack", 2f);
            //st = StartCoroutine(RealAttack(2));
        }
        //else
            //CancelInvoke("RealAttack");
            //StopCoroutine(st);
    }

    void RealAttack()
    {
        if (attackAvailable_e == true)
        {
            GameObject player = GameObject.FindWithTag("Player");
            player.GetComponent<Player>().playerHp -= 10f;

            Debug.Log("Player가 공격당하고 있습니다");

            CancelInvoke("RealAttack");
        }
        // 공격 애니메이션
    }

    void Die()
    {
        if (enemyHp <= 0)
        {
            Destroy(this.gameObject);

            GameObject player = GameObject.FindWithTag("Player");

            player.GetComponent<Player>().exp += 40f;

            Debug.Log("적을 처치했습니다.");
            // 사망 애니메이션
        }
    }
}