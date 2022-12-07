using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHp : MonoBehaviour
{
    [SerializeField]
    private float maxHp = 10;
    public float currentHp;
    private SpriteRenderer spriteRenderer;

    public float MaxHP => maxHp;
    public float currentHP => currentHp;//�ܺο����� ������ �� �ֵ��� �����

    public Image hpBarSprite; // �÷��̾� ü�� ������

    private void Awake()
    {
        currentHp = maxHp;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void UIBar()
    {
        hpBarSprite.fillAmount = currentHp/10f;
    }

    public void TakeDamage(float damage)
    {
        hpBarSprite.fillAmount = currentHp/10f;
        currentHp -= damage;
        StopCoroutine("HitColorAnimation");
        StartCoroutine("HitColorAnimation");

        if(currentHp <= 0)
        {
            Debug.Log("player Hp: die");
        }
    }

   


    private IEnumerator HitColorAnimation()
    {
        spriteRenderer.color = Color.red;//���ݴ��ϸ� �÷��̾� ��������ȭ
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = Color.white;//���� ���󵹾ƿ�
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
