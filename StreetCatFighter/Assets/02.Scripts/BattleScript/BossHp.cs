using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHp : MonoBehaviour
{

    [SerializeField]
    private float maxHP = 1000;      // 최대 체력
    private float currentHP;         // 현재 체력
    private SpriteRenderer spriteRenderer;
    private BossPattern boss;

    public float MaxHP => maxHP;
    public float CurrentHP => currentHP;

    public GameObject BaseUIBG;//보스 죽거나 플레이어 죽으면 팝업
    public GameObject ClearMent;//성공 멘트

    public Slider bosshpbar;
    public Transform Boss;

    private void Awake()
    {
        currentHP = maxHP;               // 현재 체력을 최대 체력과 같게 설정
        spriteRenderer = GetComponent<SpriteRenderer>();
        boss = GetComponent<BossPattern>();
    }

    public void TakeDamage(float damage)
    {
        // 현재 체력을 damage만큼 감소
        currentHP -= damage;

        StopCoroutine("HitColorAnimation");
        StartCoroutine("HitColorAnimation");

        // 체력이 0이하 = 보스 사망
        if (currentHP <= 0)
        {
            // 체력이 0이면 OnDie() 함수를 호출해서 죽었을 때 처리를 한다
            boss.OnDie();
            BaseUIBG.SetActive(true);
            ClearMent.SetActive(true);
        }
    }

    /*void HpBarMove()
    {
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);
        float x = screenPos.x;
        float y = screenPos.y;
        //bosshpbar.transform.position = new Vector3(x, screenPos.y + 90, 0);
        bosshpbar.transform.position = Camera.main.WorldToScreenPoint(transform.position+ new Vector3(x, screenPos.y + 90, 0));
    }*/

    private IEnumerator HitColorAnimation()
    {
        // 플레이어의 색상을 빨간색으로
        spriteRenderer.color = Color.red;
        // 0.05초 동안 대기
        yield return new WaitForSeconds(0.05f);
        // 플레이어의 색상을 원래 색상인 하얀색으로
        // (원래 색상이 하얀색이 아닐 경우 원래 색상 변수 선언)
        spriteRenderer.color = Color.white;
    }

    private void Update()
    {
        transform.position = Boss.position + new Vector3(0, 0, 0);
    }
}
