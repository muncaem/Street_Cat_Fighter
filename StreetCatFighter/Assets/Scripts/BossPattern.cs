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

    /*private IEnumerator MoveToAppearPoint()
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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


    }
}
