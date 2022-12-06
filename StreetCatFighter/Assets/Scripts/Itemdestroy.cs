using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Itemdestroy : MonoBehaviour
{
    //public AudioClip soundExplosion; //재생할 소리를 변수로 담습니다.
    //AudioSource myAudio; //AudioSorce 컴포넌트를 변수로 담습니다.
    //public static soundManager instance;  //자기자신을 변수로 담습니다.
    public AudioClip[] collisionSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") 
        {
            AudioSource.PlayClipAtPoint(collisionSound[Random.Range(0, collisionSound.Length)], transform.position);
            //myAudio.PlayOneShot(soundExplosion); //soundExplosion을 재생합니다.

            Destroy(gameObject);

        }

    }
    // Start is called before the first frame update
    void Start()
    {
        //myAudio = this.gameObject.GetComponent<AudioSource>(); //AudioSource 오브젝트를 변수로 담습니다.
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
