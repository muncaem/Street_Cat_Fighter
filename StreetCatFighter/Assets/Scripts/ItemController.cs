using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemController : MonoBehaviour
{
    string clickObj_name;
    bool power = false;
    bool speed = false;
    int p_count = 0;
    int s_count = 0;

    private void Start()
    {
        if(power == true)
        {
            InvokeRepeating("Potion", 0, 10); //바로 실행 10초마다 반복 -> 10초간 power 세짐.
        }
        if(speed == true)
        {
            InvokeRepeating("Potion", 0, 10);
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
    }

    //이미지 스프라이트 이름 다 변경.
    public void Potion()
    {
        Player playerProperty = GameObject.Find("Player").GetComponent<Player>();

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
            //적 인식 불가하도록 트리거를 없애버릴까..?
        }
        if (clickObj_name == "Power_Potion")
        {
            power = true;
            playerProperty.power = 10; //2배
            p_count++;

            if(p_count > 1)
            {
                CancelInvoke("potion");
                playerProperty.power = 5;
            }
        }
        if (clickObj_name == "Speed_Potion")
        {
            speed = true;
            playerProperty.speed = 6; //2배
            s_count++;

            if(s_count > 1)
            {
                CancelInvoke("potion");
                playerProperty.speed = 3;
            }
        }
        if (clickObj_name == "NoDamage_Potion")
        {
            //10초 무적(데미지 받지 않음)
        }
        if (clickObj_name == "Magnet_Potion")
        {
            //근방 자석 끌어당김
        }
    }
}
