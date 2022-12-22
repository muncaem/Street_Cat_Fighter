using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCtrl : MonoBehaviour
{
    public GameObject Player;
    Transform PlayerTransform;

    // Start is called before the first frame update
    void Start()
    {
        PlayerTransform = Player.transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = new Vector3(PlayerTransform.position.x, PlayerTransform.position.y + 1, transform.position.z);
    }
}
