using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AttackType {  CircleFire = 0, }
public class BossWeapon : MonoBehaviour
{
    [SerializeField]
    private GameObject enemybulletprefab;//�������� �߻�ü ������

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
        float attackRate = 0.8f;//�����ֱ�
        int count = 7;//�߻�ü ���� ����
        float intervalAngle = 360 / count;//�߻�ü ������ ����
        float weightAngle = 0;//���ߵǴ� ����

        while (true)//�� ���·� ����ϴ� �߻�ü
        {
            for(int i = 0; i <count; ++i)
            {
                GameObject clone = Instantiate(enemybulletprefab, transform.position, Quaternion.identity);
                float angle = weightAngle + intervalAngle * i;//�߻�ü �̵� ���� -����
                float x = Mathf.Cos(angle * Mathf.PI / 180.0f);//�߻�ü �̵� ���� - ����
                float y = Mathf.Sin(angle * Mathf.PI / 180.0f);
                clone.GetComponent<Movement2d>().MoveTo(new Vector2(x, y));//�߻�ü �̵�����
            }

            weightAngle += 1;//�߻�ü ���� ���� ����

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
