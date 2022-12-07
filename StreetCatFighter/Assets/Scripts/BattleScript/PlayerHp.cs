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
    public float currentHP => currentHp;//외부에서도 접근할 수 있도록 만들기

    public Image hpBarSprite; // 플레이어 체력 게이지

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
        spriteRenderer.color = Color.red;//공격당하면 플레이어 빨간색변화
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = Color.white;//원래 색상돌아옴
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
