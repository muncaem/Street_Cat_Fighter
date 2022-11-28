using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box_buff : MonoBehaviour
{
    //public Sprite fishImage;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") // 플레이어와 충돌했을 때
        {
            Destroy(this.gameObject); // 객체 삭제
        }
    }
}
