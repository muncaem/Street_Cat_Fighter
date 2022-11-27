using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemController : MonoBehaviour
{
    string clickObj_name;
    bool power = false;
    bool speed = false;
    bool nodamg = false;
    bool mag = false;
    bool clear = false;
    //int p_count = 0;
    //int s_count = 0;
    //int n_count = 0;
    //int m_count = 0;
    //int c_count = 0;

    public GameObject magnet;
    public GameObject Effect;

    Player playerProperty;

    private void Start()
    {
        Effect = GameObject.Find("Effect");
        playerProperty = GameObject.Find("Player").GetComponent<Player>();
    }

    private void Update()
    {
        if (power == true)
        {
            playerProperty.power = 10; //2배
            Effect.transform.GetChild(0).gameObject.SetActive(true);

            StartCoroutine(PowerPotion()); //10초간 power 세짐.
        }
        if (speed == true)
        {
            playerProperty.speed = 6; //2배

            StartCoroutine(SpeedPotion());
        }
        if (nodamg == true)
        {
            Enemy enemyProperty = GameObject.Find("Pigeon(Clone)").GetComponent<Enemy>();
            enemyProperty.enemyAttackPower = 0; //적 공격력 -> 0

            StartCoroutine(NoDamgPotion());
        }
        if (mag == true)
        {
            magnet.SetActive(true);

            Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);
            float x = screenPos.x;

            magnet.transform.position = new Vector3(x, screenPos.y + 90, 0);

            StartCoroutine(MagnetPotion());
        }
        if (clear == true)
        {
            Enemy enemyProperty = GameObject.Find("Pigeon(Clone)").GetComponent<Enemy>();
            enemyProperty.speed = 0; //적 속도 -> 0

            StartCoroutine(ClearPotion());
        }
    }

    public void Click()
    {
        //클릭한 게임 오브젝트를 가져와서 저장
        GameObject clickObj = EventSystem.current.currentSelectedGameObject;
        //클릭한 버튼의 이미지 이름(포션이름) 가져오기
        clickObj_name = clickObj.GetComponent<Image>().sprite.name;

        Potion();
        print(clickObj_name);
        clickObj.GetComponent<Image>().sprite = null;
        clickObj.SetActive(false);
    }

    //이미지 스프라이트 이름 다 변경.
    public void Potion()
    {
        if (clickObj_name == "Strength_Potion")
        {
            //체력 30만큼 plus
            if(playerProperty.playerHp >= 70)
            {
                playerProperty.playerHp = 100;
            }
            else
            {
                playerProperty.playerHp += 30;
            }
        }
        if (clickObj_name == "Clear_Potion")
        {
            //Enemy enemyProperty = GameObject.Find("Pigeon(Clone)").GetComponent<Enemy>();
            clear = true;
            //enemyProperty.speed = 0; //적 속도 -> 0
            //c_count++;

            //if (c_count > 1)
            //{
            //    CancelInvoke("Potion");
            //    enemyProperty.speed = 2;
            //}
        }
        if (clickObj_name == "Power_Potion")
        {
            power = true;
        }
        if (clickObj_name == "Speed_Potion")
        {
            speed = true;
            //playerProperty.speed = 6; //2배
            //s_count++;

            //if(s_count > 1)
            //{
            //    CancelInvoke("Potion");
            //    playerProperty.speed = 3;
            //}
        }
        if (clickObj_name == "NoDamage_Potion")
        {
            //Enemy enemyProperty = GameObject.Find("Pigeon(Clone)").GetComponent<Enemy>();
            nodamg = true;
            //enemyProperty.enemyAttackPower = 0; //적 공격력 -> 0
            //n_count++;

            //if(n_count > 1)
            //{
            //    CancelInvoke("Potion");
            //    enemyProperty.enemyAttackPower = 10;
            //}
        }
        if (clickObj_name == "Magnet_Potion")
        {
            mag = true;
            //magnet.SetActive(true);
            //magnet.transform.position = new Vector3(playerProperty.transform.position.x, playerProperty.transform.position.y, 0);

            //Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);
            //float x = screenPos.x;

            //magnet.transform.position = new Vector3(x, screenPos.y + 90, 0);

            //m_count++;

            //if (m_count > 1)
            //{
            //    CancelInvoke("Potion");
            //    magnet.SetActive(false);
            //}
        }
    }

    IEnumerator PowerPotion()
    {
        //Debug.Log("test");
        yield return new WaitForSeconds(10.0f);
        power = false;
        playerProperty.power = 5;
        Effect.transform.GetChild(0).gameObject.SetActive(false);
    }
    IEnumerator ClearPotion()
    {
        yield return new WaitForSeconds(10.0f);
        clear = false;
        Enemy enemyProperty = GameObject.Find("Pigeon(Clone)").GetComponent<Enemy>();
        enemyProperty.speed = 2;
    }
    IEnumerator SpeedPotion()
    {
        yield return new WaitForSeconds(10.0f);
        speed = false;
        playerProperty.speed = 3;
    }
    IEnumerator NoDamgPotion()
    {
        yield return new WaitForSeconds(10.0f);
        nodamg = false;
        Enemy enemyProperty = GameObject.Find("Pigeon(Clone)").GetComponent<Enemy>();
        enemyProperty.enemyAttackPower = 10;
    }
    IEnumerator MagnetPotion()
    {
        yield return new WaitForSeconds(10.0f);
        mag = false;
    }
}
