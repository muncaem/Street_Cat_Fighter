using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRange : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy") // ��ѱ�� �浹 ��
        {
            //Debug.Log("��ѱ�� �浹 ��");
            //collision.gameObject.GetComponent<Enemy>().attackAvailable = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Enemy") // ��ѱ�� �浹 ��
        {
            //Debug.Log("��ѱ�� �浹 ��");
            //collision.gameObject.GetComponent<Enemy>().attackAvailable = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            //Debug.Log("��ѱⰡ �������� ���");
            //collision.gameObject.GetComponent<Enemy>().attackAvailable = false;
        }
    }
}
