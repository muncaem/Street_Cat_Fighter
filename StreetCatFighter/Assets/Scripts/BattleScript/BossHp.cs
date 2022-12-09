using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHp : MonoBehaviour
{

    [SerializeField]
    private float maxHP = 1000;      // �ִ� ü��
    private float currentHP;         // ���� ü��
    private SpriteRenderer spriteRenderer;
    private BossPattern boss;

    public float MaxHP => maxHP;
    public float CurrentHP => currentHP;

    public GameObject BaseUIBG;//���� �װų� �÷��̾� ������ �˾�
    public GameObject ClearMent;//���� ��Ʈ

    public Slider bosshpbar;
    public Transform Boss;

    private void Awake()
    {
        currentHP = maxHP;               // ���� ü���� �ִ� ü�°� ���� ����
        spriteRenderer = GetComponent<SpriteRenderer>();
        boss = GetComponent<BossPattern>();
    }

    public void TakeDamage(float damage)
    {
        // ���� ü���� damage��ŭ ����
        currentHP -= damage;

        StopCoroutine("HitColorAnimation");
        StartCoroutine("HitColorAnimation");

        // ü���� 0���� = ���� ���
        if (currentHP <= 0)
        {
            // ü���� 0�̸� OnDie() �Լ��� ȣ���ؼ� �׾��� �� ó���� �Ѵ�
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
        // �÷��̾��� ������ ����������
        spriteRenderer.color = Color.red;
        // 0.05�� ���� ���
        yield return new WaitForSeconds(0.05f);
        // �÷��̾��� ������ ���� ������ �Ͼ������
        // (���� ������ �Ͼ���� �ƴ� ��� ���� ���� ���� ����)
        spriteRenderer.color = Color.white;
    }

    private void Update()
    {
        transform.position = Boss.position + new Vector3(0, 0, 0);
    }
}
