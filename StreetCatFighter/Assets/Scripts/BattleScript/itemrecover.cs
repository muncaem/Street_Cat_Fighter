using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemrecover : MonoBehaviour
{
    public PlayerHp PlayerHp;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag =="itempower") // ȸ�������۰� �浹��
        {
            PlayerHp.GetComponent<PlayerHp>().currentHp += 1;
        }

    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
