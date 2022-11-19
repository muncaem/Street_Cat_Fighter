using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    GameObject choose;
    public Text gaintext;
    GameObject panel;

    // Start is called before the first frame update
    void Start()
    {
        panel = GameObject.Find("GainTextCanvas").transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // �浹 ó�� �Լ�
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name.Contains("Player")) // �÷��̾�� �浹���� ��
        {
            Destroy(this.gameObject); // ��ü ����
        }
    }

    public void travelers_coin()
    {
        Player bring_coin = GameObject.Find("Player").GetComponent<Player>();

        choose = EventSystem.current.currentSelectedGameObject;
        choose.SetActive(false);  //������ ����ڽ� ��Ȱ
        panel.SetActive(true);

        int rd = Random.Range(0, 3);
        if (rd == 0)
        {
            gaintext.text = "5������ ȹ���ߴ�!";
            bring_coin.coin += 5;
            bring_coin.coinNum.text = bring_coin.coin.ToString();
        }
        if (rd == 1)
        {
            gaintext.text = "7������ ȹ���ߴ�!";
            bring_coin.coin += 7;
            bring_coin.coinNum.text = bring_coin.coin.ToString();
        }
        if (rd == 2)
        {
            gaintext.text = "10������ ȹ���ߴ�!";
            bring_coin.coin += 10;
            bring_coin.coinNum.text = bring_coin.coin.ToString();
        }
    }
}
