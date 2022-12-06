using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AttackType {  CircleFire = 0, }
public class BossWeapon : MonoBehaviour
{
    [SerializeField]
    private GameObject enemybulletprefab;//공격힐때 발사체 프리팹

    public void StartFiring(AttackType attackType)
    {
        StartCoroutine(attackType.ToString());
    }

    public void StopFiring(AttackType attackType)
    {
        StopCoroutine(attackType.ToString());
    }

    private IEnumerator CircleFire()
    {
        float attackRate = 0.8f;//공격주기
        int count = 7;//발사체 생성 개수
        float intervalAngle = 360 / count;//발사체 사이의 각도
        float weightAngle = 0;//가중되는 각도

        while (true)//원 형태로 방사하는 발사체
        {
            for(int i = 0; i <count; ++i)
            {
                GameObject clone = Instantiate(enemybulletprefab, transform.position, Quaternion.identity);
                float angle = weightAngle + intervalAngle * i;//발사체 이동 방향 -각도
                float x = Mathf.Cos(angle * Mathf.PI / 180.0f);//발사체 이동 방향 - 벡터
                float y = Mathf.Sin(angle * Mathf.PI / 180.0f);
                clone.GetComponent<Movement2d>().MoveTo(new Vector2(x, y));//발사체 이동방향
            }

            weightAngle += 1;//발사체 생성 시작 각도

            yield return new WaitForSeconds(attackRate);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        StartFiring(AttackType.CircleFire);
    }

    // Update is called once per frame
    void Update()
    {
        //StartFiring(AttackType.CircleFire);
    }
}
