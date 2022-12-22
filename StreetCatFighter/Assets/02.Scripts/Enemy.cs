using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    Transform playerPos;

    public float speed = 2f;

    public float enemyHp = 100f; // 체력

    public float enemyPower = 5f;

    public bool attackAvailable_p = false; // Enemy에 대한 Player의 공격 가능 여부
    public bool attackAvailable_e = false; // Player에 대한 Enemy의 공격 가능 여부

    public Image hpBarSprite; // 체력 게이지 Sprite
    public Image hpBarBgSprite; // 체력 게이지 배경 Sprite

    // Coroutine st;

    public GameObject bronzeCoin;
    public GameObject silverCoin;
    public GameObject goldCoin;
    public GameObject[] rewards;

    public Animator anim;

    void Start()
    {
        //GameObject.FindWithTag("Player").GetComponent<Player>().isEnemyExist = true;
        playerPos = GameObject.FindWithTag("Player").transform;

        rewards = new GameObject[] { null, bronzeCoin, silverCoin, goldCoin };

        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //anim.SetBool("isAttack", false);
        //anim.SetBool("isAttacked", false);

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
            player.GetComponent<Player>().playerHp -= enemyPower;

            Debug.Log("Player가 공격당하고 있습니다 : -" + enemyPower);

            // 애니메이터 제어
            player.GetComponent<Player>().anim.SetBool("isAttacked", true);
            anim.SetBool("isAttack", true);

            CancelInvoke("RealAttack");
            //player.GetComponent<Player>().renderer.sprite = player.GetComponent<Player>().playerSprite[1];
        }
        // 공격 애니메이션
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
            

            Debug.Log("적을 처치했습니다.");

            CreateReward();

            Destroy(this.gameObject);
            // 사망 애니메이션
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