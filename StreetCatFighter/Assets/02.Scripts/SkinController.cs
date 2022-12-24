using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinController : MonoBehaviour
{
    GameObject savedata, weapondata, skindata, weaponselect, skinselect, player;
    SpriteRenderer wpselectImg, skselectImg;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        savedata = GameObject.Find("SaveSkin");
        weapondata = savedata.transform.GetChild(0).gameObject;
        skindata = savedata.transform.GetChild(1).gameObject;

        if(savedata != null)
        {
            //weapon choose
            weaponselect = weapondata.transform.GetChild(0).gameObject;
            ChangingAppearance wpsc = weapondata.GetComponent<ChangingAppearance>();
            wpselectImg = weaponselect.transform.GetComponent<SpriteRenderer>();
            wpselectImg.sprite = wpsc.options[wpsc.index];
            weaponselect.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);

            //skin choose
            skinselect = skindata.transform.GetChild(0).gameObject;
            ChangingAppearance sksc = skindata.GetComponent<ChangingAppearance>();
            skselectImg = skinselect.transform.GetComponent<SpriteRenderer>();
            GameObject player = GameObject.Find("player");
            SpriteRenderer playerimg = player.transform.GetComponent<SpriteRenderer>();
            playerimg.sprite = sksc.options[sksc.index];
            //skselectImg.sprite = sksc.options[sksc.index];
            skinselect.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(savedata != null)
        {
            weaponselect.transform.position = new Vector2(player.transform.position.x + 0.5f, player.transform.position.y + 0.1f);
            skinselect.transform.position = new Vector2(player.transform.position.x, player.transform.position.y);
        }
    }
}
