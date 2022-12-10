using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Traveler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //transform.position = new Vector3(Random.Range(-3, 3), Random.Range(-4, 4), 0);
        mapicon = GameObject.Find("UI").transform.GetChild(13).gameObject;
    }

    // Update is called once per frame
    void Update()
    {

    }

    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    if (collision.tag == "Player")
    //    {
    //        GameObject.Find("---���׳׻���---").transform.GetChild(0).gameObject.SetActive(true);
    //    }
    //}

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.tag == "Player")
    //    {
    //        GameObject.Find("---���׳׻���---").transform.GetChild(0).gameObject.SetActive(false);
    //    }
    //}

    public GameObject map, mapicon, punch, txtcanvas;
    public Text getText;
    public void DrawCatFoot()
    {
        GameObject.Find("�ɹ���").gameObject.SetActive(false);
        GameObject.Find("�ɹ߿�").gameObject.SetActive(false);

        GameObject.Find("OpenCatHand").transform.GetChild(0).gameObject.SetActive(true);
        GameObject.Find("OpenCatHand").transform.GetChild(1).gameObject.SetActive(true);

        int rd = Random.Range(0, 2);
        print("������" + rd);

        if (rd == 0)
        {
            map.SetActive(true);
            txtcanvas.SetActive(true);
            getText.text = "������ ȹ���ߴ�!\n���� �������� Ȱ��ȭ�Ǿ����ϴ�.";
            mapicon.SetActive(true);
        }
        if (rd == 1)
        {
            Player p = GameObject.Find("Player").GetComponent<Player>();

            punch.SetActive(true);
            txtcanvas.SetActive(true);
            getText.text = "����ġ�� ���ߴ�!";

            p.playerHp -= 10;
            p.hpBarSprite.fillAmount = p.playerHp / 100f;
        }
    }

    public void normaltime()
    {
        Time.timeScale = 1;
        GameObject.Find("Traveler").gameObject.SetActive(false);
    }
}
