using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Itemdestroy : MonoBehaviour
{
    public AudioClip[] collisionSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player"|| collision.gameObject.tag == "Destroy") //�÷��̾��浹�Ǵ� �ٱ������� ����
        {
            AudioSource.PlayClipAtPoint(collisionSound[Random.Range(0, collisionSound.Length)], transform.position);

            Destroy(gameObject);

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
