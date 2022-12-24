using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    Transform playerPos;

    public float speed = 2f;

    public float enemyHp = 100f; // ü��

    public float enemyPower = 5f;

    public bool attackAvailable_p = false; // Enemy�� ���� Player�� ���� ���� ����
    public bool attackAvailable_e = false; // Player�� ���� Enemy�� ���� ���� ����

    public Image hpBarSprite; // ü�� ������ Sprite
    public Image hpBarBgSprite; // ü�� ������ ��� Sprite

    // Coroutine st;

    public GameObject bronzeCoin;
    public GameObject silverCoin;
    public GameObject goldCoin;
    public GameObject[] rewards;

    public Animator anim;

    void Start()
    {
        playerPos = GameObject.FindWithTag("Player").transform;

        rewards = new GameObject[] { null, bronzeCoin, silverCoin, goldCoin };

        anim = GetComponent<Animator>();

        GameObject.Find("EnemySpawnManager").GetComponent<EnemySpawnManager>().enemyNum++;
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

        if (distance <= 4.0f && distance >= 1.0f)
        {
            transform.Translate(dir * speed * Time.deltaTime);
            speed = 2f;
            anim.SetBool("Walk", true);
        }
        else
        {
            speed = 0f;
            anim.SetBool("Walk", false);
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
            anim.SetBool("Walk", true);
            Invoke("RealAttack", 2f);
        }
        else 
        {
            anim.SetBool("isAttack", false);
        }
    }

    void RealAttack()
    {
        if (attackAvailable_e == true)
        {
            GameObject player = GameObject.FindWithTag("Player");
            player.GetComponent<Player>().playerHp -= enemyPower;

            Debug.Log("Player�� ���ݴ��ϰ� �ֽ��ϴ� : -" + enemyPower);

            // �ִϸ����� ����
            player.GetComponent<Player>().anim.SetBool("isAttacked", true);
            anim.SetBool("isAttack", true);

            CancelInvoke("RealAttack");
        }
        // ���� �ִϸ��̼�
    }

    void Die()
    {
        if (enemyHp <= 0)
        {
            GameObject player = GameObject.FindWithTag("Player");
            int playerLevel = player.GetComponent<Player>().level;

            switch (playerLevel) 
            {
                case 1:
                    player.GetComponent<Player>().exp += 40f;
                    break;
                case 2:
                    player.GetComponent<Player>().exp += 30f;
                    break;
                case 3:
                    player.GetComponent<Player>().exp += 20f;
                    break;
                case 4:
                    player.GetComponent<Player>().exp += 15f;
                    break;
                case 5:
                    player.GetComponent<Player>().exp += 10f;
                    break;
                case 6:
                    player.GetComponent<Player>().exp += 8f;
                    break;
                case 7:
                    player.GetComponent<Player>().exp += 6f;
                    break;
                case 8:
                    player.GetComponent<Player>().exp += 4f;
                    break;
                case 9:
                    player.GetComponent<Player>().exp += 3f;
                    break;
                case 10:
                    player.GetComponent<Player>().exp += 2f;
                    break;
            }

            GameObject.Find("EnemySpawnManager").GetComponent<EnemySpawnManager>().enemyNum--;
            Debug.Log("��ѱ� ��" + GameObject.Find("EnemySpawnManager").GetComponent<EnemySpawnManager>().enemyNum);
            CreateReward();
            Destroy(this.gameObject);
        }
    }

    void CreateReward()
    {
        GameObject coin = rewards[Random.Range(0, 4)];
        if (coin != null)
            Instantiate(coin, this.transform.position, transform.rotation);
        else
            return;
    }
}