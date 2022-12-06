using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BossState { MoveToAppearPoint = 0, Phase01, }
public class BossPattern : MonoBehaviour//보스 공격패턴
{
    [SerializeField]
    //private float bossAppearPoint = 2.5f;
    private BossState bossState = BossState.MoveToAppearPoint;
    //private BossState bossState = BossState.Phase01;
    private Movement2d movement2D;
    private BossWeapon bossweapon;

    Vector3 pos; //현재위치
    float delta = 1.0f; // 좌(우)로 이동가능한 (x)최대값
    float speed = 2.0f; // 이동속도

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

    /*private IEnumerator MoveToAppearPoint()//슈팅게임에서 위에서 아래로 등장할 때 쓰는 거
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
        // 보스 파괴 파티클 생성
        //GameObject clone = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        // 파티클 재생 완료 후 씬 전환을 위한 설정
        //clone.GetComponent<BossExplosion>().Setup(playerController, nextSceneName);
        // 보스 오브젝트 삭제
        Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;
    }

    // Update is called once per frame
    void Update()//좌우이동 반복
    {
        Vector3 v = pos;
        v.x += delta * Mathf.Sin(Time.time * speed);
        // 좌우 이동의 최대치 및 반전 처리
        v.y += delta * Mathf.Cos(Time.time * speed);
        transform.position = v;

    }
}
