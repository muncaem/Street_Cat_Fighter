using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slotpopup : MonoBehaviour
{
    void Start()
    {
        GameObject.Find("자판기팝업").transform.GetChild(0).gameObject.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GameObject.Find("자판기팝업").transform.GetChild(0).gameObject.SetActive(true);
        }
    }
}
