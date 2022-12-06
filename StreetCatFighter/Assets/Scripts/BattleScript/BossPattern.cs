using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BossState { MoveToAppearPoint = 0, Phase01, }
public class BossPattern : MonoBehaviour//���� ��������
{
    [SerializeField]
    //private float bossAppearPoint = 2.5f;
    private BossState bossState = BossState.MoveToAppearPoint;
    //private BossState bossState = BossState.Phase01;
    private Movement2d movement2D;
    private BossWeapon bossweapon;

    Vector3 pos; //������ġ
    float delta = 1.0f; // ��(��)�� �̵������� (x)�ִ밪
    float speed = 2.0f; // �̵��ӵ�

    private void Awake()
    {
        movement2D = GameObject.Find("Boss").GetComponent<Movement2d>();
        bossweapon = GameObject.Find("Boss").GetComponent<BossWeapon>();

    }

    public void ChangeState(BossState newState)
    {
        StopCoroutine(bossState.ToString());
        bossState = newState;
        StartCoroutine(bossState.ToString());
    }

    /*private IEnumerator MoveToAppearPoint()//���ð��ӿ��� ������ �Ʒ��� ������ �� ���� ��
    {
        //movement2D.MoveTo(Vector3.down);
        while (true)
        {
            
        //if (transform.position.y <= bossAppearPoint)
        //{
        //movement2D.MoveTo(Vector3.zero);
            ChangeState(BossState.Phase01);
        //}


        yield return null;
        }
    }*/

    private IEnumerator Phase01()
    {
        bossweapon.StartFiring(AttackType.CircleFire);
        while (true)
        {
            yield return null;
        }
    }

    public void OnDie()
    {
        // ���� �ı� ��ƼŬ ����
        //GameObject clone = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        // ��ƼŬ ��� �Ϸ� �� �� ��ȯ�� ���� ����
        //clone.GetComponent<BossExplosion>().Setup(playerController, nextSceneName);
        // ���� ������Ʈ ����
        Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;
    }

    // Update is called once per frame
    void Update()//�¿��̵� �ݺ�
    {
        Vector3 v = pos;
        v.x += delta * Mathf.Sin(Time.time * speed);
        // �¿� �̵��� �ִ�ġ �� ���� ó��
        v.y += delta * Mathf.Cos(Time.time * speed);
        transform.position = v;

    }
}
