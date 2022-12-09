using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinController : MonoBehaviour
{
    GameObject skinobj, select, player;
    SpriteRenderer selectImg;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        skinobj = GameObject.Find("SaveSkin");

        if(skinobj != null)
        {
            select = skinobj.transform.GetChild(0).gameObject;
            //select.SetActive(true);

            ChangingAppearance skindata = skinobj.GetComponent<ChangingAppearance>();

            selectImg = select.transform.GetComponent<SpriteRenderer>();
            selectImg.sprite = skindata.options[skindata.index];

            select.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            //select.transform.position = new Vector2(player.transform.position.x + 5.0f, player.transform.position.y + 1.0f);
            //select.transform.parent = player.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(skinobj!= null)
        {
            select.transform.position = new Vector2(player.transform.position.x + 0.5f, player.transform.position.y + 0.1f);
        }
    }
}
