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
}
