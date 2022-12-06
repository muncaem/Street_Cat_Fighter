using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Itemdestroy : MonoBehaviour
{
    //public AudioClip soundExplosion; //����� �Ҹ��� ������ ����ϴ�.
    //AudioSource myAudio; //AudioSorce ������Ʈ�� ������ ����ϴ�.
    //public static soundManager instance;  //�ڱ��ڽ��� ������ ����ϴ�.
    public AudioClip[] collisionSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") 
        {
            AudioSource.PlayClipAtPoint(collisionSound[Random.Range(0, collisionSound.Length)], transform.position);
            //myAudio.PlayOneShot(soundExplosion); //soundExplosion�� ����մϴ�.

            Destroy(gameObject);

        }

    }
    // Start is called before the first frame update
    void Start()
    {
        //myAudio = this.gameObject.GetComponent<AudioSource>(); //AudioSource ������Ʈ�� ������ ����ϴ�.
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
