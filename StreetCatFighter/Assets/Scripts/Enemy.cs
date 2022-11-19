using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    Transform playerPos;

    float speed = 2f;

    public float enemyHp = 20f; // ü��

    public bool attackAvailable_p = false; // Enemy�� ���� Player�� ���� ���� ����
    public bool attackAvailable_e = false; // Player�� ���� Enemy�� ���� ���� ����

    public Image hpBarSprite; // ü�� ������ Sprite
    public Image hpBarBgSprite; // ü�� ������ ��� Sprite

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
        // ���� ���� ���� �Ǵ�
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

            Debug.Log("Player�� ���ݴ��ϰ� �ֽ��ϴ�");

            CancelInvoke("RealAttack");
        }
        // ���� �ִϸ��̼�
    }

    void Die()
    {
        if (enemyHp <= 0)
        {
            Destroy(this.gameObject);

            GameObject player = GameObject.FindWithTag("Player");

            player.GetComponent<Player>().exp += 40f;

            Debug.Log("���� óġ�߽��ϴ�.");
            // ��� �ִϸ��̼�
        }
    }
}