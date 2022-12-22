using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class StoreOpen : MonoBehaviour
{
    GameObject chosenitem, itemcost;
    public GameObject itemsprite;
    public GameObject spriteImg1, spriteImg2, spriteImg3, spriteImg4;
    public string costbring;
    public GameObject item1, item2, item3, item4;
    int itm1, itm2, itm3, itm4;
    List<int> itmNum = new List<int>();

    // Start is called before the first frame update
    void Start()
    {
        //for(int i = 0; i < 7; i++)
        //{
        //    itmNum.Add(Random.Range(1, 7));
        //}
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RandomItemStore()
    {
        //6개 아이템 중 랜덤생성될 4개 아이템 뽑기
        //for (int i = 0; i < 3; i++)
        //{
        //    int rand = Random.Range(0, itmNum.Count);
        //    //print(itmNum[rand]);
        //    itmNum.RemoveAt(rand);
        //}

        //print(itmNum);

        int curnum = Random.Range(1, 7);

        for (int i = 0; i < 7; )
        {
            if(itmNum.Contains(curnum))
            {
                curnum = Random.Range(1, 7);
            }
            else
            {
                itmNum.Add(curnum);
                i++;
            }
        }

        itm1 = itmNum[0];
        itm2 = itmNum[1];
        itm3 = itmNum[2];
        itm4 = itmNum[3];

        //item1.GetComponent<Image>().sprite = spriteImg[itm1].GetComponent<SpriteRenderer>().sprite;
        //itemname(item1);
        //item2.GetComponent<Image>().sprite = spriteImg[itm2].GetComponent<SpriteRenderer>().sprite;
        //itemname(item2);
        //item3.GetComponent<Image>().sprite = spriteImg[itm3].GetComponent<SpriteRenderer>().sprite;
        //itemname(item3);
        //item4.GetComponent<Image>().sprite = spriteImg[itm4].GetComponent<SpriteRenderer>().sprite;
        //itemname(item4);
    }

    public void BringCost()
    {
        chosenitem = EventSystem.current.currentSelectedGameObject;
        itemcost = chosenitem.transform.GetChild(0).gameObject;
        //itemsprite = chosenitem.transform.GetChild(1).gameObject;

        costbring = itemcost.GetComponent<Text>().text;

        //하이어라키에서 sprite5,6 추가해야함 & 게임오브젝트 배열로 만들어서 이것도 수정해야함.
        if (chosenitem.tag == "Item1")
        {
            itemsprite = spriteImg1;
        }
        if (chosenitem.tag == "Item2")
        {
            itemsprite = spriteImg2;
        }
        if (chosenitem.tag == "Item3")
        {
            itemsprite = spriteImg3;
        }
        if (chosenitem.tag == "Item4")
        {
            itemsprite = spriteImg4;
        }

        //print(itemsprite);
        //print(chosenitem);
        //print(itemcost);
        //print(costbring);
        //test
    }

    void itemname(GameObject item)
    {
        if(item.GetComponent<Image>().sprite.name == "Clear_Potion")
        {
            item.transform.GetChild(2).gameObject.GetComponent<Text>().text = "투명화포션";
        }
        if (item.GetComponent<Image>().sprite.name == "Magnet_Potion")
        {
            item.transform.GetChild(2).gameObject.GetComponent<Text>().text = "자화포션";
        }
        if (item.GetComponent<Image>().sprite.name == "NoDamage_Potion")
        {
            item.transform.GetChild(2).gameObject.GetComponent<Text>().text = "무적포션";
        }
        if (item.GetComponent<Image>().sprite.name == "Power_Potion")
        {
            item.transform.GetChild(2).gameObject.GetComponent<Text>().text = "공격력포션";
        }
        if (item.GetComponent<Image>().sprite.name == "Speed_Potion")
        {
            item.transform.GetChild(2).gameObject.GetComponent<Text>().text = "속도증가포션";
        }
        if (item.GetComponent<Image>().sprite.name == "Strength_Potion")
        {
            item.transform.GetChild(2).gameObject.GetComponent<Text>().text = "체력포션";
        }
    }
}
