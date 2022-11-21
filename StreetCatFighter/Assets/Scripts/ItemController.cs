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
            InvokeRepeating("Potion", 0, 10); //�ٷ� ���� 10�ʸ��� �ݺ� -> 10�ʰ� power ����.
        }
        if(speed == true)
        {
            InvokeRepeating("Potion", 0, 10);
        }
    }

    public void Click()
    {
        //Ŭ���� ���� ������Ʈ�� �����ͼ� ����
        GameObject clickObj = EventSystem.current.currentSelectedGameObject;
        //Ŭ���� ��ư�� �̹��� �̸�(�����̸�) ��������
        clickObj_name = clickObj.GetComponent<Image>().sprite.name;

        Potion();
        print(clickObj_name);
    }

    //�̹��� ��������Ʈ �̸� �� ����.
    public void Potion()
    {
        Player playerProperty = GameObject.Find("Player").GetComponent<Player>();

        if (clickObj_name == "Strength_Potion")
        {
            //ü�� 30��ŭ plus
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
            //�� �ν� �Ұ��ϵ��� Ʈ���Ÿ� ���ֹ�����..?
        }
        if (clickObj_name == "Power_Potion")
        {
            power = true;
            playerProperty.power = 10; //2��
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
            playerProperty.speed = 6; //2��
            s_count++;

            if(s_count > 1)
            {
                CancelInvoke("potion");
                playerProperty.speed = 3;
            }
        }
        if (clickObj_name == "NoDamage_Potion")
        {
            //10�� ����(������ ���� ����)
        }
        if (clickObj_name == "Magnet_Potion")
        {
            //�ٹ� �ڼ� ������
        }
    }
}
