using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 충돌 처리 함수
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") // 플레이어와 충돌했을 때
        {
            Destroy(this.gameObject); // 객체 삭제
        }
        if (collision.tag == "magnet")
        {
            Destroy(this.gameObject);
            Player pl = GameObject.Find("Player").GetComponent<Player>();

            pl.coin += 1;
            pl.coinNum.text = pl.coin.ToString();
        }
    }

    //public void travelers_coin()
    //{
    //    Player bring_coin = GameObject.Find("Player").GetComponent<Player>();

    //    choose = EventSystem.current.currentSelectedGameObject;
    //    choose.SetActive(false);  //선택한 보상박스 비활
    //    panel.SetActive(true);

    //    int rd = Random.Range(0, 3);
    //    if (rd == 0)
    //    {
    //        gaintext.text = "5코인을 획득했다!";
    //        bring_coin.coin += 5;
    //        bring_coin.coinNum.text = bring_coin.coin.ToString();
    //    }
    //    if (rd == 1)
    //    {
    //        gaintext.text = "7코인을 획득했다!";
    //        bring_coin.coin += 7;
    //        bring_coin.coinNum.text = bring_coin.coin.ToString();
    //    }
    //    if (rd == 2)
    //    {
    //        gaintext.text = "10코인을 획득했다!";
    //        bring_coin.coin += 10;
    //        bring_coin.coinNum.text = bring_coin.coin.ToString();
    //    }
    //}
}
