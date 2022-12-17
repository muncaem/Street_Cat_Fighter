using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class StoreOpen : MonoBehaviour
{
    GameObject chosenitem, itemcost;
    public GameObject itemsprite;
    public GameObject[] spriteImg = new GameObject[6];
    public string costbring;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BringCost()
    {
        chosenitem = EventSystem.current.currentSelectedGameObject;
        itemcost = chosenitem.transform.GetChild(0).gameObject;
        //itemsprite = chosenitem.transform.GetChild(1).gameObject;

        costbring = itemcost.GetComponent<Text>().text;

        //6�� ������ �� ���������� 4�� ������ �̱�
        List<int> itmNum = new List<int>() { 1, 2, 3, 4, 5, 6 };
        for(int i = 0; i < 5; i++)
        {
            int rand = Random.Range(1, itmNum.Count);
            print(itmNum[rand]);
            itmNum.RemoveAt(rand);
        }

        int itm1, itm2, itm3, itm4;

        itm1 = itmNum[0];
        itm2 = itmNum[1];
        itm3 = itmNum[2];
        itm4 = itmNum[3];

        //���̾��Ű���� sprite5,6 �߰��ؾ��� & ���ӿ�����Ʈ �迭�� ���� �̰͵� �����ؾ���.
        if (chosenitem.tag == "Item1")
        {
            itemsprite = spriteImg[itm1];
        }
        if (chosenitem.tag == "Item2")
        {
            itemsprite = spriteImg[itm2];
        }
        if (chosenitem.tag == "Item3")
        {
            itemsprite = spriteImg[itm3];
        }
        if (chosenitem.tag == "Item4")
        {
            itemsprite = spriteImg[itm4];
        }

        //print(itemsprite);
        //print(chosenitem);
        //print(itemcost);
        //print(costbring);
        //test
    }
}
